using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Ventas
{
    public partial class rpt_VtasxFechas : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Ventas an_ventas = null;
        public static string desde, hasta;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_ventas = new AN_Ventas(Request.Cookies["basesiav"].Value);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDesde.Text.Length > 0 && txtHasta.Text.Length > 0)
                {
                    desde = Convert.ToDateTime(txtDesde.Text.Trim()).ToString("yyyy-MM-dd");
                    hasta = Convert.ToDateTime(txtHasta.Text.Trim()).ToString("yyyy-MM-dd");
                    RptVtas();
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", " SELECCIONE UN RANGO DE FECHAS", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        private static PdfPCell CeldaTabla(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }

        private static PdfPCell CeldaTabla1(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }

        public partial class Footer : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document doc)

            {

                Paragraph footer = new Paragraph("VENTAS MARGEN UTILIDAD", FontFactory.GetFont(FontFactory.TIMES, 14, iTextSharp.text.Font.BOLD));
                footer.Alignment = Element.ALIGN_CENTER;
                PdfPTable footerTbl = new PdfPTable(1);
                footerTbl.TotalWidth = 300;
                footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell = new PdfPCell(footer);
                cell.Border = 0;
                cell.PaddingLeft = 10;
                footerTbl.AddCell(cell);
                footerTbl.WriteSelectedRows(0, -1, 285, 570, writer.DirectContent);

            }

        }

       protected void ExportToExcel(object sender, EventArgs e)
        {
            string fechadesde = "";
            string fechahasta = "";
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;

            fechadesde = Convert.ToDateTime(txtDesde.Text.Trim()).ToString("yyyy-MM-dd");
            fechahasta = Convert.ToDateTime(txtHasta.Text.Trim()).ToString("yyyy-MM-dd");

            GridView1.DataSource = an_ventas.GetVtasxFechaEx(fechadesde, fechahasta).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptVtasxFechasMU.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[2].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = "<style> .textmode { mso-number-format:\"\@\" } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        public void RptVtas()
        {
            int totalcantidad = 0;
            decimal totalcosto = 0, totalprecio = 0, totaldescuento = 0, totaliva = 0, totalsubtotal = 0, totaltotal = 0, totalmu = 0;
            string empresa = Request.Cookies["basesiav"].Value;
            DataTable dt = an_ventas.GetVtasxFecha(desde, hasta);
            Document document = new Document(PageSize.A4.Rotate(), -85, -85, 80f, 20f);
            Font NormalFont = FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                PdfPTable table1 = null;
                PdfPTable table3 = null;
                document.Open();
                writer.PageEvent = new Footer();
                table1 = new PdfPTable(14); //cantidad de columnas
                table1.TotalWidth = 200f;
                table1.LockedWidth = false;
                table1.SetWidths(new float[] { 0.15f, 0.28f, 0.2f, 0.3f, 0.2f, 0.4f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f }); //TAMAÑO DE COLUMNAS
                table1.SplitLate = false;

                table3 = new PdfPTable(14); //cantidad de columnas
                table3.TotalWidth = 200f;
                table3.LockedWidth = false;
                table3.SetWidths(new float[] { 0.15f, 0.28f, 0.2f, 0.3f, 0.2f, 0.4f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.15f }); //TAMAÑO DE COLUMNAS
                table3.SplitLate = false;

                table1.AddCell(CeldaTabla(new Phrase("FECHA", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("FACT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("RUC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("CLIENTE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("ITEM", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("DESCRIPCION", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("CANT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("COSTO", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("PRECIO", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("DESC.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("IVA", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("SUBTOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(CeldaTabla(new Phrase("MU", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                foreach (DataRow row in dt.Rows)
                {
                    totalcantidad += Convert.ToInt32(row["cantidad"].ToString());
                    totalcosto += Convert.ToDecimal(row["costo"].ToString());
                    totalprecio += Convert.ToDecimal(row["precio"].ToString());
                    totaldescuento += Convert.ToDecimal(row["descuento"].ToString());
                    totaliva += Convert.ToDecimal(row["iva"].ToString());
                    totalsubtotal += Convert.ToDecimal(row["subtotal"].ToString());
                    totaltotal += Convert.ToDecimal(row["total"].ToString());
                    totalmu += Convert.ToDecimal(row["mu"].ToString());
                    table1.AddCell(CeldaTabla(new Phrase(Convert.ToDateTime(row["fecha"].ToString()).ToShortDateString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["factura"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["ruc"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["cliente"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["item"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["descripcion"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["cantidad"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["costo"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["precio"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["descuento"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["iva"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["subtotal"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["total"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla(new Phrase(row["mu"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                }

                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase("TOTALES", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalcantidad), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalcosto), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalprecio), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totaldescuento), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totaliva), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalsubtotal), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totaltotal), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalmu), FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));

                document.Add(table1);
                document.Add(table3);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Context.Response.AddHeader("Content-Disposition", "inline; filename=rptVtasxFechasMU.pdf");
                //Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                //Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }

        }
        #endregion


    }
}