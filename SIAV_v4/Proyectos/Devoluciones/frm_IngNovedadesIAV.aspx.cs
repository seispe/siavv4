using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
using System.Web;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_IngNovedadesIAV : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Devolucion an_devolucion;
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
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
                table.Columns.Add("informedevolucion", typeof(string));
                table.Columns.Add("codigoproducto", typeof(string));
                table.Columns.Add("cantidad", typeof(string));
                table.Columns.Add("motivo", typeof(string));
                table.Columns.Add("observacion", typeof(string));
                table.Columns.Add("transporte", typeof(string));

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
                                fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                                fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : ""
                                );
                    }
                }
                int resultado = an_devolucion.cargarExcel(table);
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
                string tipo = "TR-DEV";
                string motivo = txtMotivo.Text.Trim();
                string resultado = an_devolucion.generaTraspasos(tipo, usuario, motivo);
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
        public string informedevolucion { get; set; }
        public string codigoproducto { get; set; }
        public string cantidad { get; set; }
        public string motivo { get; set; }
        public string observacion { get; set; }
        public string transporte { get; set; }

    }
}