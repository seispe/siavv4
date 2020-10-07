using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Cobranzas
{
    public partial class rpt_Recaudacion : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        public static string desde,hasta;
        public static string CUSTNMBR, RazonSocial, VEN_CODIGO;
        #endregion

        #region Funciones
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

                Paragraph footer = new Paragraph("DESDE: " + desde + "        " + "HASTA: " + hasta, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
                footer.Alignment = Element.ALIGN_RIGHT;
                PdfPTable footerTbl = new PdfPTable(1);
                footerTbl.TotalWidth = 300;
                footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                PdfPCell cell = new PdfPCell(footer);
                cell.Border = 0;
                cell.PaddingLeft = 10;
                footerTbl.AddCell(cell);
                footerTbl.WriteSelectedRows(0, -1, 435, 540, writer.DirectContent);

            }

        }

        public void Recaudaciones()
        {
            decimal totalaplicado = 0, totalcheques = 0, totaldiferencia = 0;
            string empresa = Request.Cookies["basesiav"].Value;
            DataTable dt = an_cobranzas.GetRecaudacionesV1(desde, hasta, empresa);
            Document document = new Document(PageSize.A4.Rotate(), -50, -50, 80f, 20f);
            Font NormalFont = FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                PdfPTable table = null;
                PdfPTable table1 = null;
                PdfPTable table2 = null;
                PdfPTable table3 = null;
                document.Open();
                //HEADER EN CADA PAGINA
                writer.PageEvent = new Footer();
                //TABLA MAESTRA
                table = new PdfPTable(5); //cantidad de columnas
                table.TotalWidth = 200f;
                table.LockedWidth = false;
                table.SetWidths(new float[] { 0.1f, 1.2f, 0.09f, 0.80f, 0.09f }); //TAMAÑO DE COLUMNAS
                table.SplitLate = false;
                //TABLA FOOTER TOTALES GENERALES
                table3 = new PdfPTable(5); //cantidad de columnas
                table3.TotalWidth = 200f;
                table3.LockedWidth = false;
                table3.SetWidths(new float[] { 0.1f, 1.2f, 0.09f, 0.75f, 0.1f }); //TAMAÑO DE COLUMNAS
                table3.SplitLate = false;

                foreach (DataRow row in dt.Rows)
                {
                    int contador = 0;
                    ////TABLA DEL SUBREPORTE V3
                    table1 = new PdfPTable(9); //cantidad de columnas
                    table1.TotalWidth = 380f;
                    table1.LockedWidth = true;
                    table1.SetWidths(new float[] { 0.05f, 0.18f, 0.2f, 0.2f, 0.15f, 0.15f, 0.1f, 0.15f, 0.1f }); //TAMAÑO DE COLUMNAS
                    table1.SplitLate = false;
                    ////TABLA DEL SUBREPORTE V2
                    table2 = new PdfPTable(5); //cantidad de columnas
                    table2.TotalWidth = 245f;
                    table2.LockedWidth = true;
                    table2.SetWidths(new float[] { 0.25f, 0.2f, 0.2f, 0.2f, 0.2f }); //TAMAÑO DE COLUMNAS
                    table2.SplitLate = false;
                    //HEADER DEL SUBREPORTE V3
                    table1.AddCell(CeldaTabla1(new Phrase("VE", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("RUC", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("Razon Social", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("# Factura", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("F. INGRE", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("F. FACT.", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("VALOR", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("APLICADO", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table1.AddCell(CeldaTabla1(new Phrase("SALDO", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    //HEADER DEL SUBREPORTE V2
                    table2.AddCell(CeldaTabla1(new Phrase("BANCO", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table2.AddCell(CeldaTabla1(new Phrase("# CUENTA", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table2.AddCell(CeldaTabla1(new Phrase("# CHEQUE", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table2.AddCell(CeldaTabla1(new Phrase("F. VENCIM", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table2.AddCell(CeldaTabla1(new Phrase("VALOR CHQ.", FontFactory.GetFont("Arial", 6, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    ////TRAER DATOS SUBREPORTE RECAUDACIONES V3
                    DataTable dt1 = an_cobranzas.GetRecaudacionesV3(row["CUSTNMBR"].ToString(), desde, hasta, empresa);
                    ////CREAR TABLA DEL SUBREPORTE RECAUDACIONES V3
                    foreach (DataRow row1 in dt1.Rows)
                    {
                        if (contador == 0) CUSTNMBR = row1["CUSTNMBR"].ToString();
                        if (contador == 0) RazonSocial = row1["RazonSocial"].ToString();
                        if (contador == 0) VEN_CODIGO = row1["VEN_CODIGO"].ToString();
                        string APTODCNM = row1["APTODCNM"].ToString();
                        string APTODCDT = Convert.ToDateTime(row1["APTODCDT"].ToString()).ToShortDateString();
                        string Apply_To_Due_Date = Convert.ToDateTime(row1["Apply_To_Due_Date"].ToString()).ToShortDateString();
                        string DOCAMNT = row1["DOCAMNT"].ToString();
                        string Aplicado = row1["Aplicado"].ToString();
                        string FaltaAplicado = row1["FaltaAplicado"].ToString();
                        if (APTODCDT == "01/01/1900") APTODCDT = "";
                        if (Apply_To_Due_Date == "01/01/1900") Apply_To_Due_Date = "TOTAL";
                        //CUERPO DEL SUBREPORTE V3
                        table1.AddCell(CeldaTabla1(new Phrase(VEN_CODIGO, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(CUSTNMBR, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(RazonSocial, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(APTODCNM, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(APTODCDT, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(Apply_To_Due_Date, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(DOCAMNT, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(Aplicado, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaTabla1(new Phrase(FaltaAplicado, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //SOLO PRIMERA FILA: VENDEDOR, RUC, FACTURA
                        if ((CUSTNMBR != "") && (RazonSocial != "") && (VEN_CODIGO != ""))
                        {
                            CUSTNMBR = "";
                            RazonSocial = "";
                            VEN_CODIGO = "";
                            contador = 1;
                        }
                        //SUMA DE VALORES APLICADOS
                        if (Apply_To_Due_Date == "TOTAL") totalaplicado += Convert.ToDecimal(Aplicado);
                    }
                    ////TRAER DATOS SUBREPORTE RECAUDACIONES V2
                    DataTable dt2 = an_cobranzas.GetRecaudacionesV2(row["CUSTNMBR"].ToString(), desde, hasta, empresa);
                    ////CREAR TABLA DEL SUBREPORTE RECAUDACIONES V2
                    foreach (DataRow row2 in dt2.Rows)
                    {
                        string BANKID = row2["BANKID"].ToString();
                        string BNKACTNM = row2["BNKACTNM"].ToString();
                        string CHEKNMBR = row2["CHEKNMBR"].ToString();
                        string CHEKDATE = Convert.ToDateTime(row2["CHEKDATE"].ToString()).ToShortDateString();
                        string ORTRXAMT = row2["ORTRXAMT"].ToString();
                        if (CHEKDATE == "01/01/1900") CHEKDATE = "TOTAL";
                        //CUERPO DEL SUBREPORTE V3
                        table2.AddCell(CeldaTabla1(new Phrase(BANKID, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table2.AddCell(CeldaTabla1(new Phrase(BNKACTNM, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table2.AddCell(CeldaTabla1(new Phrase(CHEKNMBR, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table2.AddCell(CeldaTabla1(new Phrase(CHEKDATE, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table2.AddCell(CeldaTabla1(new Phrase(ORTRXAMT, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //SUMA DE CHEQUES
                        if (CHEKDATE == "TOTAL") totalcheques += Convert.ToDecimal(ORTRXAMT);
                        
                    }
                    string diferencia = row["Diferencia"].ToString();
                    totaldiferencia += Convert.ToDecimal(diferencia);
                    //TABLA MAESTRA
                    

                    table.AddCell(CeldaTabla(new Phrase(row["Factura"].ToString(), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(table1);
                    table.AddCell(CeldaTabla(new Phrase(row["Cheque"].ToString(), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    table.AddCell(table2);
                    table.AddCell(CeldaTabla(new Phrase(diferencia, FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                }
                //TABLA FOOTER TOTALES GENERALES
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalaplicado), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase("", FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totalcheques), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                table3.AddCell(CeldaTabla1(new Phrase(Convert.ToString(totaldiferencia), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_RIGHT));
                //GRABAMOS LA INFO EN LA HOJA

                document.Add(table);
                document.Add(table3);
                //Nueva Pagina
                //document.NewPage();
                

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Context.Response.AddHeader("Content-Disposition", "inline; filename=Recaudaciones.pdf");
                //Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                //Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtDesde.Text.Length > 0 && txtHasta.Text.Length > 0)
                {
                    desde = txtDesde.Text.Trim();
                    hasta = txtHasta.Text.Trim();
                    Recaudaciones();
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


    }
}