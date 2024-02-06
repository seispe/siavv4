using AccesoNegocios.Devoluciones;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;

namespace SIAV_v4.Proyectos.Pruebas
{
    public partial class frm_subirExcel : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Devolucion an_devolucion;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
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
            table.Columns.Add("data1", typeof(string));
            table.Columns.Add("data2", typeof(string));
            table.Columns.Add("data3", typeof(string));
            table.Columns.Add("data4", typeof(string));

            if (hoja != null)
            {

                int cantidadfilas = hoja.LastRowNum;

                for (int i = 1; i <= cantidadfilas; i++)
                {
                    IRow fila = hoja.GetRow(i);


                    if (fila != null)
                        table.Rows.Add(
                            fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : "",
                            fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString() : "",
                            fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).DateCellValue.ToString("dd/MM/yyyy") : "",
                             fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK) != null ? fila.GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK).NumericCellValue.ToString() : ""
                            );
                }
            }
            an_devolucion.cargarExcel(table);
        }
        #endregion

        #region Funciones

        #endregion


    }
    public class informacion
    {
        public string data1 { get; set; }
        public string data2 { get; set; }
        public string data3 { get; set; }
        public string data4 { get; set; }
    }
}