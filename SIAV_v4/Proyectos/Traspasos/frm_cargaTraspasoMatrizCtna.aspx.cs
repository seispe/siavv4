using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System;
using System.IO;
using System.Web;

namespace SIAV_v4.Proyectos.Traspasos
{
    public partial class frm_cargaTraspasoMatrizCtna : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos 
        protected void Page_Load(object sender, EventArgs e)
        {

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
                table.Columns.Add("id_mov", typeof(string));
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
                int resultado = an_wms.cargarExcel(table);
                if (resultado == 1)
                {
                    grTabla.DataSource = table;
                    grTabla.DataBind();
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
                string usuario = HttpContext.Current.User.Identity.Name;
                string tipo = "TR-BAC";
                string motivo = txtMotivo.Text.Trim();
                string resultado = an_wms.generaTraspasos(tipo, usuario, motivo);
                if (resultado.Contains("GENERADO"))
                {
                    grTabla.Columns.Clear();
                    grTabla.DataSource = null;
                    grTabla.DataBind();
                    txtMotivo.Text = "";
                    lblError.Text = an_alertas.Mensaje("CORRECTO ", resultado, "verde");
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
        #endregion

        #region Funciones

        #endregion
    }

    public class Traspaso
    {
        public string id_mov { get; set; }
        public string codigoproducto { get; set; }
        public string cantidad { get; set; }
        
    }
}