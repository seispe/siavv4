using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using AccesoNegocios.GP;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Compras
{
    public partial class frm_ReservaStockAllparts : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Compras an_compras;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_compras = new AN_Compras(Request.Cookies["basesiav"].Value);
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string ruta_carpeta = Server.MapPath("~/Recursos/excel/");
                //GUARDAMOS EL ARCHIVO EN LOCAL
                var ruta_guardado = Path.Combine(ruta_carpeta, FileUpload1.FileName);
                FileUpload1.SaveAs(ruta_guardado);

                IWorkbook MiExcel = null;
                FileStream fs = new FileStream(ruta_guardado, FileMode.Open, FileAccess.Read);

                if (Path.GetExtension(ruta_guardado) == ".xlsx")
                    MiExcel = new XSSFWorkbook(fs);
                else
                    MiExcel = new HSSFWorkbook(fs);


                ISheet hoja = MiExcel.GetSheetAt(0);
                DataTable table = new DataTable();
                table.Columns.Add("recibimiento", typeof(string));
                table.Columns.Add("codigoproducto", typeof(string));
                table.Columns.Add("cantidad", typeof(string));
                
                if (hoja != null)
                {

                    int cantidadfilas = hoja.LastRowNum;

                    for (int i = 1; i <= cantidadfilas; i++)
                    {
                        IRow fila = hoja.GetRow(i);


                        if (fila != null)
                            table.Rows.Add(
                                fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : ""
                                );
                    }
                }
                string resultado = an_compras.cargarReservaAllxlsx(table);
                if (resultado == "Ok")
                {
                    grTabla.DataSource = table;
                    grTabla.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string resultado = an_compras.reservaStockAllparts("", HttpContext.Current.User.Identity.Name, 1);
                if (resultado.Contains("Ok"))
                {
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
                    grTabla.DataSource = null;
                    grTabla.DataBind();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                    grTabla.DataSource = null;
                    grTabla.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtRecibo.Text.Length > 0)
                {
                    string resultado = an_compras.reservaStockAllparts(txtRecibo.Text.Trim(), HttpContext.Current.User.Identity.Name, 2);
                    if (resultado.Contains("Ok"))
                    {
                        lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
                        txtRecibo.Text = "";
                        grTabla.DataSource = null;
                        grTabla.DataBind();
                    }
                    else
                    {
                        lblError.Text = an_alertas.Mensaje("ERROR ", resultado, "rojo");
                        grTabla.DataSource = null;
                        grTabla.DataBind();
                    }
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "# recibo vacio", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        #endregion

        #region Funciones

        #endregion


    }
}