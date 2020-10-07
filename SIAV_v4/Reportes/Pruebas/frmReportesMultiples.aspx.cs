using iTextSharp.text.html.simpleparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.IO;

namespace SIAV_v4.Reportes.Pruebas
{
    public partial class frmReportesMultiples : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void HTMLaPDF()
        {
            Document document = new Document();
            try
            {
                PdfWriter.GetInstance(document, new FileStream("c:\\PRUEBAS\\my.pdf", FileMode.Create));
                document.Open();
                WebClient wc = new WebClient();
                string htmlText = wc.DownloadString("http://192.168.0.247/SIAV_v4/Recursos/rptHTML/rptPRUEBA.html");
                Response.Write(htmlText);
                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(htmlText), null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    document.Add((IElement)htmlarraylist[k]);
                }

                document.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void Example()
        {
            //DataRow dr = GetData("SELECT * FROM GA_WMS_TUsuario").Rows[0]; 
            DataTable dt = GetData("SELECT * FROM GA_WMS_TUsuario");
            Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                BaseColor color = null;

                document.Open();

                foreach (DataRow row in dt.Rows)
                {
                    //Header Table
                    table = new PdfPTable(2);
                    table.TotalWidth = 500f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.3f, 0.7f });

                    //Company Logo
                    //cell = ImageCell("~/images/northwindlogo.gif", 30f, PdfPCell.ALIGN_CENTER);
                    //table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("Microsoft Northwind Traders Company\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
                    phrase.Add(new Chunk("107, Park site,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Salt Lake Road,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk("Seattle, USA", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);

                    //Separater Line
                    color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                    DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                    document.Add(table);

                    table = new PdfPTable(2);
                    table.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.SetWidths(new float[] { 0.3f, 1f });
                    table.SpacingBefore = 20f;

                    //Employee Details
                    cell = PhraseCell(new Phrase("Employee Record", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    table.AddCell(cell);
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 30f;
                    table.AddCell(cell);

                    //Photo
                    //cell = ImageCell(string.Format("~/photos/{0}.jpg", dr["EmployeeId"]), 25f, PdfPCell.ALIGN_CENTER);
                    //table.AddCell(cell);

                    //Name
                    phrase = new Phrase();
                    phrase.Add(new Chunk(row["usuario"] + " " + row["clave"] + " " + row["nombre"] + "\n", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
                    //phrase.Add(new Chunk("(" + dr["Title"].ToString() + ")", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                    document.Add(table);

                    DrawLine(writer, 160f, 80f, 160f, 690f, BaseColor.BLACK);
                    DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, BaseColor.BLACK);

                    table = new PdfPTable(2);
                    table.SetWidths(new float[] { 0.5f, 2f });
                    table.TotalWidth = 340f;
                    table.LockedWidth = true;
                    table.SpacingBefore = 20f;
                    table.HorizontalAlignment = Element.ALIGN_RIGHT;

                    //Employee Id
                    table.AddCell(PhraseCell(new Phrase("Employee code:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase("000" + row["usuario"], FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    cell.Colspan = 2;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);


                    //Address
                    //table.AddCell(PhraseCell(new Phrase("Address:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    //phrase = new Phrase(new Chunk(dr["nombre"] + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
                    //phrase.Add(new Chunk(dr["usuario"] + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
                    //phrase.Add(new Chunk(dr["clave"] + " " + dr["usuario"] + " " + dr["clave"], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)));
                    //table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                    //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    //cell.Colspan = 2;
                    //cell.PaddingBottom = 10f;
                    //table.AddCell(cell);

                    //Date of Birth
                    //table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    //table.AddCell(PhraseCell(new Phrase(Convert.ToDateTime(dr["BirthDate"]).ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    //cell.Colspan = 2;
                    //cell.PaddingBottom = 10f;
                    //table.AddCell(cell);

                    //Phone
                    //table.AddCell(PhraseCell(new Phrase("Phone Number:", FontFactory.GetFont("Arial", 8, Font.BOLD, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    //table.AddCell(PhraseCell(new Phrase(dr["HomePhone"] + " Ext: " + dr["Extension"], FontFactory.GetFont("Arial", 8, Font.NORMAL, Color.BLACK)), PdfPCell.ALIGN_LEFT));
                    //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                    //cell.Colspan = 2;
                    //cell.PaddingBottom = 10f;
                    //table.AddCell(cell);

                    //Addtional Information
                    table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(PhraseCell(new Phrase(row["usuario"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                    document.Add(table);
                    //Nueva Pagina
                    document.NewPage();
                }
               
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=Employee.pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            Example();
        }
    }
}