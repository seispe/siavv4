using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Devoluciones
{
    public partial class frm_CartaServ : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Devolucion an_devolucion;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            an_devolucion = new AN_Devolucion(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (txtfactura.Text.Length > 0)
                {
                    VincularGrid(txtfactura.Text.Trim());
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR", "INGRESE UN NUMERO DE FACTURA", "rojo");
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                string factura = "", cliente = "", codigo = "", descripcion = "", guia = "", usuario = "", fcourier = "";
                int cant = 0;
                DateTime fdevolucion;
                foreach (GridViewRow row in gvItems.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            factura = (row.Cells[4].FindControl("lblfactura") as Label).Text.Trim();
                            descripcion = (row.Cells[2].FindControl("lbldescripcion") as Label).Text.Trim();
                            cant = Convert.ToInt32((row.Cells[3].FindControl("lblcantidad") as Label).Text.Trim());
                            cliente = (row.Cells[5].FindControl("lblcliente") as Label).Text.Trim();
                            codigo = (row.Cells[1].FindControl("lblcodigo") as Label).Text.Trim();
                            fdevolucion = Convert.ToDateTime((row.Cells[8].FindControl("lblfdev") as Label).Text.Trim());
                            guia = txtGuia.Text.Trim();
                            usuario = HttpContext.Current.User.Identity.Name;
                            fcourier = txtFecha.Text.Trim();
                            an_devolucion.InsCodCartServ(factura,cliente, codigo,descripcion,cant, guia, fcourier,fdevolucion, usuario, 2);
                        }
                    }
                }
                Carta(factura);
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void Carta(string factura)
        {
            DataTable dt = an_devolucion.GetFactCarta(factura);
            Document document = new Document(PageSize.A4, 88f, 88f, 50f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                PdfPTable table1 = null;
                PdfPTable table2 = null;
                PdfPTable table3 = null;
                PdfPTable table4 = null;
                PdfPTable table5 = null;
                PdfPTable table6 = null;
                PdfPTable tableDetalle = null;
                document.Open();
                table1 = new PdfPTable(1);
                table1.TotalWidth = 500f;
                table1.LockedWidth = true;
                table1.SetWidths(new float[] { 0.8f});

                table2 = new PdfPTable(1);
                table2.TotalWidth = 500f;
                table2.LockedWidth = true;
                table2.SetWidths(new float[] { 0.8f });

                table3 = new PdfPTable(1);
                table3.TotalWidth = 500f;
                table3.LockedWidth = true;
                table3.SetWidths(new float[] { 1.5f });

                tableDetalle = new PdfPTable(4); //CANT COLUMNAS
                tableDetalle.TotalWidth = 500f;
                tableDetalle.LockedWidth = true;
                tableDetalle.SetWidths(new float[] { 0.2f, 0.8f, 0.1f, 0.1f}); //TAMAÑO COLUMNAS

                table4 = new PdfPTable(1);
                table4.TotalWidth = 500f;
                table4.LockedWidth = true;
                table4.SetWidths(new float[] { 1.5f });

                table5 = new PdfPTable(1);
                table5.TotalWidth = 500f;
                table5.LockedWidth = true;
                table5.SetWidths(new float[] { 0.8f });

                table6 = new PdfPTable(1);
                table6.TotalWidth = 500f;
                table6.LockedWidth = true;
                table6.SetWidths(new float[] { 0.8f });

                table1.AddCell(PhraseCell(new Phrase("AMBATO, " + dt.Rows[0]["fecha"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table1.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table2.AddCell(PhraseCell(new Phrase("Sres.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table2.AddCell(PhraseCell(new Phrase("SERVIENTREGA", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table2.AddCell(PhraseCell(new Phrase("Presente", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table2.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table2.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                table3.AddCell(Celda1(new Phrase("Por medio de la presente pongo en su conocimiento de los inconvenientes suscitados en los envíos de repuestos hasta la ciudad de " +
                    dt.Rows[0]["ciudad"].ToString() + ", para el cliente " + dt.Rows[0]["cliente"].ToString() + ". Uno de los problemas se presenta en la guía " + dt.Rows[0]["guia"].ToString() +
                    " enviada el " + dt.Rows[0]["fcourier"].ToString() + " en la que se transporta los siguientes repuestos: ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)).SetLeading(0f, 1.8f);
                table3.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table3.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                tableDetalle.AddCell(CeldaTabla(new Phrase("CODIGO", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(CeldaTabla(new Phrase("DESCRIPCION", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(CeldaTabla(new Phrase("CANT", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(CeldaTabla(new Phrase("PVP UNIT", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                foreach (DataRow row in dt.Rows)
                {
                    tableDetalle.AddCell(CeldaTabla(new Phrase(row["codigo"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    tableDetalle.AddCell(CeldaTabla(new Phrase(row["decripcion"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    tableDetalle.AddCell(CeldaTabla(new Phrase(row["cant"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    tableDetalle.AddCell(CeldaTabla(new Phrase(row["precio"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                }
                
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                tableDetalle.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                table4.AddCell(Celda1(new Phrase("Según factura " + dt.Rows[0]["factura"].ToString() + " mismo que se envía en perfecto estado y revisado por personal de SERVIENTREGA QUITO, " +
                    "pero a su destino llega como GOLPEADO, particular que es detectado y notificado por el cliente, razón por la cual se solicita la respectiva indemnización.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED)).SetLeading(0f, 1.8f);
                table4.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table4.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                table5.AddCell(PhraseCell(new Phrase("Por la atención que se sirvan dar la presente, anticipo mis agradecimientos.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table5.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table5.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table5.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table5.AddCell(PhraseCell(new Phrase(" ", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                table6.AddCell(PhraseCell(new Phrase("Att.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table6.AddCell(PhraseCell(new Phrase("DEVOLUCIONES", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table6.AddCell(PhraseCell(new Phrase(dt.Rows[0]["usuario"].ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table6.AddCell(PhraseCell(new Phrase("Importadora Alvarado  Cía. Ltda.", FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                document.Add(table1);
                document.Add(table2);
                document.Add(table3);
                document.Add(tableDetalle);
                document.Add(table4);
                document.Add(table5);
                document.Add(table6);

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Context.Response.AddHeader("Content-Disposition", "inline; filename=Carta.pdf");
                //Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                //Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }

        public void VincularGrid(string factura)
        {
            try
            {
                gvItems.DataSource = an_devolucion.GetDetFactCarta(factura, "", "", DateTime.Now, "", 1).DataSource;
                gvItems.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR", ex.Message, "rojo");
            }
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

        private static PdfPCell Celda1(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            cell.FixedHeight = 100f;
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
        #endregion
    }
}