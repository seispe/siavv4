using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.WMSiav
{
    public partial class frm_consBultos : System.Web.UI.Page
    {
        #region Variables
        AN_Alertas an_alertas = new AN_Alertas();
        AN_WMS an_wms = new AN_WMS();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnConsolidar.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (txtpedido.Text.Length > 0)
            {
                GridDetalleArmado();
                btnConsolidar.Visible = true;
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE PEDIDO", "rojo");
            }
        }

        protected void gvDetalleArmado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblError.Text = "";
                if (e.CommandName == "detBulto")
                {
                    string[] argumentos = new string[2];
                    argumentos = e.CommandArgument.ToString().Split(';');
                    string pedido = argumentos[0];
                    string idbulto = argumentos[1];
                    //Llenar la tabla
                    lbldetallebulto.Text = an_wms.getDetBultosxPedido(pedido, Convert.ToInt32(idbulto));
                    //Abrir el modal
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#detBulto').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ArticuloModalScript", sb.ToString(), false);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        protected void btnConsolidar_Click(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                string pedido = "";
                string idbulto = "";
          
                foreach (GridViewRow row in gvDetalleArmado.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                        if (chkRow.Checked)
                        {
                            pedido = (row.Cells[3].FindControl("lblpedido") as Label).Text.Trim();
                            idbulto = (row.Cells[1].FindControl("lblidbulto") as Label).Text.Trim();
                            res += an_wms.insConsolidadosBultos(pedido, Convert.ToInt32(idbulto), HttpContext.Current.User.Identity.Name, 1);
                        }
                    }
                }
                an_wms.insConsolidadosBultos("", 0, "", 2);
                if (res.Contains("OK"))
                {
                    lblError.Text = an_alertas.Mensaje("", "CORRECTO", "verde");
                }
                else
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "EL PEDIDO AUN NO TERMINA EL ARMADO", "rojo");
                }
                GridDetalleArmado();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            if (txtpedido.Text.Length > 0)
            {
                NotaEntrega(txtpedido.Text.Trim());
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", "INGRESE UN NUMERO DE PEDIDO", "rojo");
            }
        }
        #endregion

        #region Funciones
        public void GridDetalleArmado()
        {
            try
            {
                //btnCerrar.Text = Txt_consolidado.Text.Trim();
                gvDetalleArmado.DataSource = an_wms.getBultosxPedido(txtpedido.Text.Trim(),0, 1).DataSource;
                gvDetalleArmado.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void NotaEntrega(string pedidos)
        {
            string empresa = Request.Cookies["basesiav"].Value;
            //string concatena = "P-GPIAV-";
            //string desdeped = concatena + txtDesde.Text.Trim();
            //string hastaped = concatena + txtHasta.Text.Trim();
            string usuario = HttpContext.Current.User.Identity.Name;
            string pedido, pedidoActual;
            decimal subtotal = 0;
            DataTable dt = an_wms.GetPackingListConsBultos(pedidos);
            Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                PdfPTable table1 = null;
                PdfPTable tableDetalle = null;
                BaseColor color = null;
                pedidoActual = "";
                pedido = "";
                document.Open();
                foreach (DataRow valores in dt.Rows)
                {
                    subtotal += Convert.ToDecimal(valores["PVP"]);
                }

                foreach (DataRow row in dt.Rows)
                {
                    /*string p = row["DOCUMENTO"].ToString();
                    p = p.Replace("-", "");*/
                    //########################################
                    //Iniciacion de DATAMATRIX
                    //########################################
                    DataMatrix.net.DmtxImageEncoder Encoder = new DataMatrix.net.DmtxImageEncoder();
                    System.Drawing.Bitmap bmp = Encoder.EncodeImage(row["DOCUMENTO"].ToString().Trim());
                    string ruta = Server.MapPath("~/Recursos/upload/") + row["DOCUMENTO"].ToString() + ".png";
                    bmp.Save(ruta);//, System.Drawing.Imaging.ImageFormat.Png);
                    //System.Drawing.Image image = System.Drawing.Image.FromFile(@"C:\PLANOS\" + row["Documento"].ToString().Trim() + ".png");
                    //########################################
                    //Fin Iniciacion de DATAMATRIX
                    //########################################

                    //########################################
                    //Iniciacion de BARCODE
                    //########################################
                    /*BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                    System.Drawing.Image img = b.Encode(BarcodeLib.TYPE.CODE128, "R" + p, System.Drawing.Color.Black, System.Drawing.Color.White, 500, 50);
                    string rutab = Server.MapPath("~/Recursos/upload/barcode") + usuario.Trim() + ".png";
                    img.Save(rutab);*/
                    //########################################
                    //Fin Iniciacion de BARCODE
                    //########################################

                    if (empresa == "GPIAV") empresa = "IMPORTADORA ALVARADO";
                    if (empresa == "GPCAL") empresa = "CORPORACION ALVARADO CIA. LTDA.";
                    if (empresa == "GPTRA") empresa = "RECTIMA INDUSTRY CIA. LTDA.";

                    pedido = row["DOCUMENTO"].ToString().Trim();
                    //Grabamos la informacion en cada hoja
                    if (pedidoActual != pedido && pedidoActual != "")
                    {
                        document.Add(table);
                        document.Add(tableDetalle);
                        document.Add(table1);
                        //Nueva Pagina
                        document.NewPage();
                    }
                    //Llenamos lo basico
                    if (pedidoActual == "" || pedidoActual != pedido)
                    {
                        pedidoActual = row["DOCUMENTO"].ToString().Trim();

                        //Tabla Header
                        table = new PdfPTable(4);
                        table.TotalWidth = 500f;
                        table.LockedWidth = true;
                        table.SetWidths(new float[] { 0.3f, 0.7f, 0.3f, 0.7f });

                        //Tabla Productos
                        tableDetalle = new PdfPTable(6); //CANT COLUMNAS
                        tableDetalle.TotalWidth = 500f;
                        tableDetalle.LockedWidth = true;
                        tableDetalle.SetWidths(new float[] { 0.2f, 0.8f, 0.1f, 0.1f, 0.2f, 0.20f }); //TAMAÑO COLUMNAS

                        //Tabla Footer
                        table1 = new PdfPTable(4);
                        table1.TotalWidth = 500f;
                        table1.LockedWidth = true;
                        table1.SetWidths(new float[] { 0.3f, 0.7f, 0.3f, 0.7f });

                        //DATAMATRIX
                        //cell = ImageCell(@"~\Recursos\upload\"+ row["Documento"].ToString().Trim() + ".png", 40f, PdfPCell.ALIGN_CENTER);
                        //table.AddCell(cell);

                        //Titulo
                        cell = PhraseCell(new Phrase("NOTA DE ENTREGA", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 4;
                        table.AddCell(cell);
                        cell = PhraseCell(new Phrase(empresa, FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 4;
                        cell.PaddingBottom = 30f;
                        table.AddCell(cell);

                        //Cabecera Usuario
                        table.AddCell(PhraseCell(new Phrase("Usuario:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(usuario, FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Fecha Impresion:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(DateTime.Now.ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Empaque:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["USUARIO_EMPACO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Consolidado:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["NUMCONSOLIDADO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase("_____________________________________________________________________", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 4;
                        cell.PaddingBottom = 10f;
                        table.AddCell(cell);

                        //Cabecera
                        table.AddCell(PhraseCell(new Phrase("Bodega:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["BODEGA"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("N° Documento:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["DOCUMENTO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Ruta:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["RUTA"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("F. Inicio:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["Fecha_Inicio"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Teléfonos::", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["TELEFONOS"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("F. Fin:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["Fecha_Fin"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Cliente:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["CLIENTE"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                        cell = ImageCodigo(@"~\Recursos\upload\" + row["DOCUMENTO"].ToString() + ".png", 40f, PdfPCell.ALIGN_LEFT);
                        cell.Rowspan = 4;
                        cell.Colspan = 1;
                        table.AddCell(cell);

                        table.AddCell(PhraseCell(new Phrase("      ", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                        //table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Ruc:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["RUC"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("      ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Dirección:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["DIRECCION"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //table.AddCell(PhraseCell(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("      ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Razon Social:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["RAZON_SOCIAL"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("      ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Ciudad:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["CIUDAD"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase("Tipo Pedido:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(PhraseCell(new Phrase(row["TIPO_PEDIDO"].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(CeldaEspaciosBottom(new Phrase("Parroquia:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(CeldaEspaciosBottom(new Phrase(row["PARROQUIA"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(CeldaEspaciosBottom(new Phrase("", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table.AddCell(CeldaEspaciosBottom(new Phrase("", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                        //Detalle de Articulos
                        tableDetalle.AddCell(CeldaTabla(new Phrase("CODIGO", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase("DESCRIPCION", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase("PVP", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase("CANT", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase("BULTO", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase("OBSERVACION", FontFactory.GetFont("Arial", 7, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["CODIGO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["DESCRIPCION"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["PVP"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["CANT"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["BULTO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["OBSERVACION"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));

                        table1.AddCell(CeldaEspaciosTop(new Phrase("Total Bultos:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase(row["TOTAL_BULTOS"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("Subtotal:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase(subtotal.ToString(), FontFactory.GetFont("Arial", 10, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("Observación:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase(row["OBSPEDIDO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("Recibido, Revisado, Conforme:", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("__________________", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("C.I.:", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(CeldaEspaciosTop(new Phrase("__________________", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("   ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("   ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("   ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("   ", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("Nombre:", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("__________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("Hora:", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        table1.AddCell(PhraseCell(new Phrase("__________________", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                        cell.Colspan = 4;
                        cell.PaddingBottom = 10f;
                        table1.AddCell(cell);

                    }
                    else
                    {
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["CODIGO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //tableDetalle.AddCell(CeldaTabla(new Phrase(row["cod_anterior"].ToString(), FontFactory.GetFont("Arial", 7, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        //tableDetalle.AddCell(CeldaTabla(new Phrase(row["cod_original"].ToString(), FontFactory.GetFont("Arial", 6, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["DESCRIPCION"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["PVP"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["CANT"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["BULTO"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                        tableDetalle.AddCell(CeldaTabla(new Phrase(row["OBSERVACION"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                    }
                }

                if (pedidoActual == pedido)
                {
                    document.Add(table);
                    document.Add(tableDetalle);
                    document.Add(table1);
                    //Nueva Pagina
                    //document.NewPage();
                }

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";
                Context.Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                //Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                //Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
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

        private static PdfPCell CeldaEspaciosBottom(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 20f;
            cell.PaddingTop = 0f;
            return cell;
        }

        private static PdfPCell CeldaEspaciosTop(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 30f;
            return cell;
        }

        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            image.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 15f;
            return cell;
        }

        private static PdfPCell ImageCodigo(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            image.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.HorizontalAlignment = align;
            return cell;
        }
        #endregion

        
    }
}