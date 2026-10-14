using AccesoNegocios.Logistica;
using AccesoNegocios.Alertas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Image = iTextSharp.text.Image;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;

namespace SIAV_v4.Proyectos.Logistica
{
    public partial class pdfCargaVehiculos : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Logistica an_logistica = new AN_Logistica();
        string fecha;
        string placa;
        int fr;
        string frecuencia;
        string bodega;
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fecha"] != null && Session["placa"] != null && Session["frecuencia"] != null)
            {
                fecha = Session["fecha"].ToString();
                placa = Session["placa"].ToString();
                fr = Convert.ToInt32(Session["frecuencia"]);
                switch (Request.Cookies["empresasiav"].Value)
                {
                    case "18":
                        bodega = "PVG";
                        break;
                    case "19":
                        bodega = "PVQ";
                        break;
                    case "1":
                        bodega = "MATRIZ";
                        break;
                    default:
                        bodega = "MATRIZ";
                        break;
                }
                if (fr == 1) frecuencia = "FRECUENCIA 1";
                if (fr == 2) frecuencia = "FRECUENCIA 2";
                if (fr == 3) frecuencia = "FRECUENCIA 3";
                GenerarPDf();
            }
        }
        #endregion

        #region Funciones
        public void GenerarPDf()
        {
            try
            {
                lblError.Text = "";
                string datosGenerales = an_logistica.StringCargaVehiculos(3, fecha, placa, bodega, fr);
                if (datosGenerales == "")
                {
                    lblError.Text = an_alertas.Mensaje("ERROR ", "Placa sin carga", "rojo");
                }
                else
                {
                    string[] datosGeneralesSplit = datosGenerales.Split('-');
                    string totalbultos = datosGeneralesSplit[0];
                    string totalpedidos = datosGeneralesSplit[1];
                    string conductor = datosGeneralesSplit[2];
                    Document document = new Document(PageSize.A4, 20, 20, 46, 20); // Horizontal
                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                        Font smallFont = FontFactory.GetFont(FontFactory.HELVETICA, 8);
                        Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                        Font footerFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 7);
                        #region Cabecera
                        // CABECERA
                        PdfPTable headerTable = new PdfPTable(3) { WidthPercentage = 100 };
                        headerTable.SetWidths(new float[] { 1, 2, 1 });

                        // Logo (izquierda)
                        string imagePath = Server.MapPath("~/Recursos/logos/LogoIAV.png");
                        Image logo = Image.GetInstance(imagePath);
                        logo.ScaleToFit(120f, 100f);

                        PdfPCell logoCell = new PdfPCell(logo)
                        {
                            Border = Rectangle.BOX,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        headerTable.AddCell(logoCell);

                        // Título (centro)
                        PdfPCell titleCell = new PdfPCell(new Phrase("CARGA DE VEHICULOS", titleFont))
                        {
                            Border = Rectangle.BOX,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        headerTable.AddCell(titleCell);

                        // Datos de documento (derecha)
                        PdfPTable infoTable = new PdfPTable(1);
                        infoTable.AddCell(new PdfPCell(new Phrase("CÓDIGO: GLO-LI-RG-02", smallFont)) { Border = Rectangle.BOTTOM_BORDER });
                        infoTable.AddCell(new PdfPCell(new Phrase("FECHA: 11-07-2025", smallFont)) { Border = Rectangle.BOTTOM_BORDER });
                        infoTable.AddCell(new PdfPCell(new Phrase("VERSIÓN: 02", smallFont)) { Border = Rectangle.BOTTOM_BORDER });

                        PdfPCell infoCell = new PdfPCell(infoTable)
                        {
                            Border = Rectangle.BOX,
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        headerTable.AddCell(infoCell);
                        #endregion

                        #region Footer
                        // FOOTER
                        PdfPTable footerTable = new PdfPTable(2) { WidthPercentage = 100 };
                        footerTable.SetWidths(new float[] { 6, 1 });

                        // Texto
                        PdfPCell titlefCell = new PdfPCell(new Phrase("Todos los derechos reservados por IAV. Prohibida su reproducción parcial o total sin autorización de IAV. Documento controlado por el SGC.", footerFont))
                        {
                            Border = Rectangle.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        footerTable.AddCell(titlefCell);

                        // Logo (derecha)
                        string imagefPath = Server.MapPath("~/Recursos/logos/selloSGCiav.png");
                        Image logof = Image.GetInstance(imagefPath);
                        logof.ScaleToFit(120f, 40f);

                        PdfPCell logofCell = new PdfPCell(logof)
                        {
                            Border = Rectangle.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        footerTable.AddCell(logofCell);
                        #endregion

                        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                        CabeceraPiePaginaRepetible pageEvent = new CabeceraPiePaginaRepetible(headerTable, footerTable);
                        writer.PageEvent = pageEvent;
                        document.Open();

                        #region Bloque de Datos
                        PdfPTable bloqueTable = new PdfPTable(6) { WidthPercentage = 100 };
                        bloqueTable.SetWidths(new float[] { 1.5f, 2, 1.5f, 2, 1.5f, 2 });

                        // Fila 1
                        bloqueTable.AddCell(new PdfPCell(new Phrase("CONDUCTOR:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase(conductor, smallFont)) { HorizontalAlignment = Element.ALIGN_LEFT });
                        bloqueTable.AddCell(new PdfPCell(new Phrase("DESTINO (RUTA):", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        bloqueTable.AddCell(new PdfPCell(new Phrase("PLACA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase(placa, normalFont)) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE });

                        // Fila 2
                        bloqueTable.AddCell(new PdfPCell(new Phrase("FECHA DE CARGA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase(fecha, normalFont)) { HorizontalAlignment = Element.ALIGN_LEFT, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase("HORA INICIO CARGA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        bloqueTable.AddCell(new PdfPCell(new Phrase("HORA FINALIZACION CARGA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");

                        // Fila 3
                        bloqueTable.AddCell(new PdfPCell(new Phrase("FECHA REALIZACIÓN RUTA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        bloqueTable.AddCell(new PdfPCell(new Phrase("HORA DE SALIDA A RUTA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        bloqueTable.AddCell(new PdfPCell(new Phrase("KM DE SALIDA A RUTA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");

                        // Fila 4
                        bloqueTable.AddCell(new PdfPCell(new Phrase("PORCENTAJE DE OCUPACION DEL VEHICULO:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        bloqueTable.AddCell(new PdfPCell(new Phrase("RUTA:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase(frecuencia, normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell(new PdfPCell(new Phrase("GUIA DE REMISIÓN:", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        bloqueTable.AddCell("");
                        //document.Add(new Paragraph("\n"));
                        #endregion

                        #region DetalleCombustible
                        PdfPTable combustible1Table = new PdfPTable(1) { WidthPercentage = 100 };
                        combustible1Table.SetWidths(new float[] { 5 });

                        combustible1Table.AddCell(new PdfPCell(new Phrase("DETALLE DE COMBUSTIBLE", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                        PdfPTable combustible2Table = new PdfPTable(5) { WidthPercentage = 100 };
                        combustible2Table.SetWidths(new float[] { 1.5f, 2, 4, 1.5f, 2 });

                        combustible2Table.AddCell(new PdfPCell(new Phrase("TICKET #", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
                        combustible2Table.AddCell("");

                        // Datos de combustible (centro)
                        PdfPTable infocombusTable = new PdfPTable(1);
                        infocombusTable.AddCell(new PdfPCell(new Phrase("NIVEL DE COMBUSTIBLE", smallFont)) { Border = Rectangle.BOTTOM_BORDER, BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        infocombusTable.AddCell(new PdfPCell(new Phrase("[   ]25%[   ]50%[   ]75%[   ]100%", normalFont)) { Border = Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                        PdfPCell infocombusCell = new PdfPCell(infocombusTable)
                        {
                            Border = Rectangle.BOX,
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        combustible2Table.AddCell(infocombusCell);

                        combustible2Table.AddCell("");
                        combustible2Table.AddCell("");
                        #endregion

                        #region EstadoVehiculo
                        PdfPTable estado1Table = new PdfPTable(1) { WidthPercentage = 100 };
                        estado1Table.SetWidths(new float[] { 5 });

                        estado1Table.AddCell(new PdfPCell(new Phrase("ESTADO Y CARACTERÍSTICAS DEL VEHÍCULO (CONTROL)", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                        PdfPTable estado2Table = new PdfPTable(6) { WidthPercentage = 100 };
                        estado2Table.SetWidths(new float[] { 2, 1.5f, 2, 1.5f, 2.2f, 1.5f });

                        // Fila 1
                        estado2Table.AddCell(new PdfPCell(new Phrase("BOTIQUIN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("LUCES DELANTERAS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("LLANTA DE EMERGENCIA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));

                        // Fila 2
                        estado2Table.AddCell(new PdfPCell(new Phrase("GATA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("LUCES POSTERIORES", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("PITO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));

                        // Fila 3
                        estado2Table.AddCell(new PdfPCell(new Phrase("EXTINTOR", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("DIRECCIONALES", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("PITO DE RETRO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));

                        // Fila 4
                        estado2Table.AddCell(new PdfPCell(new Phrase("TRIANGULOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("ESPEJOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("CINTURONES DE SEG", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));

                        // Fila 5
                        estado2Table.AddCell(new PdfPCell(new Phrase("LIQUIDOS Y FLUIDOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("VIDRIOS Y PARABRISAS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("PLUMAS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));

                        // Fila 6
                        estado2Table.AddCell(new PdfPCell(new Phrase("HERRAMIENTAS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell(new PdfPCell(new Phrase("ESTADOS DE LLANTAS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY });
                        estado2Table.AddCell(new PdfPCell(new Phrase("[   ]SI    [   ]NO", FontFactory.GetFont(FontFactory.HELVETICA, 9))));
                        estado2Table.AddCell("");
                        estado2Table.AddCell("");
                        #endregion

                        #region ControlCarga
                        PdfPTable carga1Table = new PdfPTable(1) { WidthPercentage = 100 };
                        carga1Table.SetWidths(new float[] { 5 });

                        carga1Table.AddCell(new PdfPCell(new Phrase("CONTROL DE CARGA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                        PdfPTable carga2Table = new PdfPTable(6) { WidthPercentage = 100 };
                        carga2Table.SetWidths(new float[] { 2, 2, 2, 2, 2, 2 });

                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("PEDIDO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("PEDIDO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("PEDIDO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                        DataTable dt = an_logistica.TablaCargaVehiculos(2, fecha, placa, bodega, fr);
                        foreach (DataRow row in dt.Rows)
                        {
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["bultos1"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["pedido1"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["bultos2"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["pedido2"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["bultos3"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                            carga2Table.AddCell(new PdfPCell(new Phrase(row["pedido3"].ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 7))) { HorizontalAlignment = Element.ALIGN_CENTER });
                        }

                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("GUIA DE REMISIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("GUIA DE REMISIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("#BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga2Table.AddCell(new PdfPCell(new Phrase("GUIA DE REMISIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });

                        for (int i = 0; i <= 5; i++)
                        {
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                            carga2Table.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                        }

                        PdfPTable carga3Table = new PdfPTable(4) { WidthPercentage = 100 };
                        carga3Table.SetWidths(new float[] { 2, 2, 2, 6 });

                        carga3Table.AddCell(new PdfPCell(new Phrase("TOTAL SOBRES", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga3Table.AddCell(new PdfPCell(new Phrase("TOTAL PEDIDOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga3Table.AddCell(new PdfPCell(new Phrase("TOTAL G.REMISIÓN", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga3Table.AddCell(new PdfPCell(new Phrase("TOTAL BULTOS", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        carga3Table.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                        carga3Table.AddCell(new PdfPCell(new Phrase(totalpedidos, smallFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        carga3Table.AddCell(new PdfPCell(new Phrase("  ", FontFactory.GetFont(FontFactory.HELVETICA, 7))));
                        carga3Table.AddCell(new PdfPCell(new Phrase(totalbultos, smallFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        #endregion

                        #region Novedades
                        PdfPTable novedadesTable = new PdfPTable(1) { WidthPercentage = 100 };
                        novedadesTable.SetWidths(new float[] { 12 });

                        novedadesTable.AddCell(new PdfPCell(new Phrase("NOVEDADES DURANTE LA CARGA Y RUTA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9))) { BackgroundColor = BaseColor.LIGHT_GRAY, HorizontalAlignment = Element.ALIGN_CENTER });
                        for (int i = 0; i <= 6; i++)
                        {
                            novedadesTable.AddCell(new PdfPCell(new Phrase(" ")));
                        }
                        #endregion

                        #region Firmas
                        PdfPTable firmasTable = new PdfPTable(3) { WidthPercentage = 100 };
                        firmasTable.SetWidths(new float[] { 4, 4, 4 });

                        firmasTable.AddCell(new PdfPCell(new Phrase(" ")) { Border = Rectangle.LEFT_BORDER });
                        firmasTable.AddCell(new PdfPCell(new Phrase(" ")) { Border = Rectangle.NO_BORDER });
                        firmasTable.AddCell(new PdfPCell(new Phrase(" ")) { Border = Rectangle.RIGHT_BORDER });

                        firmasTable.AddCell(new PdfPCell(new Phrase("___________________")) { Border = Rectangle.LEFT_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        firmasTable.AddCell(new PdfPCell(new Phrase("___________________")) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        firmasTable.AddCell(new PdfPCell(new Phrase("________________________")) { Border = Rectangle.RIGHT_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });

                        firmasTable.AddCell(new PdfPCell(new Phrase("FIRMA CHOFER", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { Border = Rectangle.LEFT_BORDER | Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        firmasTable.AddCell(new PdfPCell(new Phrase("NOMBRE AYUT. CHOFER", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { Border = Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        if (bodega == "PVG")
                        {
                            firmasTable.AddCell(new PdfPCell(new Phrase("AUXILIAR ADMINISTRATIVO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { Border = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        }
                        else
                        {
                            firmasTable.AddCell(new PdfPCell(new Phrase("JEFE/ASISTENTE DE LOGISTICA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8))) { Border = Rectangle.RIGHT_BORDER | Rectangle.BOTTOM_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
                        }

                        #endregion

                        //document.Add(new Paragraph("\n"));
                        //Agregar bloque de datos
                        document.Add(bloqueTable);
                        //Agregar tabla de combustible
                        document.Add(combustible1Table);
                        document.Add(combustible2Table);
                        //Agregar estado de vehiculo
                        document.Add(estado1Table);
                        document.Add(estado2Table);
                        //Agregar control de carga
                        document.Add(carga1Table);
                        document.Add(carga2Table);
                        document.Add(carga3Table);
                        //Novedades
                        document.Add(novedadesTable);
                        //Firmas
                        document.Add(firmasTable);

                        document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Context.Response.AddHeader("Content-Disposition", "inline; filename=CheckList.pdf");
                        //Response.AddHeader("Content-Disposition", "inline; filename=Pedido.pdf");
                        //Response.ContentType = "application/pdf";
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();

                        Session.Remove("fecha");
                        Session.Remove("placa");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion



    }

    /*public class CabeceraRepetible : PdfPageEventHelper
    {
        private PdfPTable headerTable;

        public CabeceraRepetible(PdfPTable table)
        {
            headerTable = table;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            headerTable.WriteSelectedRows(
                0, -1,
                document.LeftMargin,
                document.PageSize.Height - 10, // posición vertical
                writer.DirectContent);
        }
    }

    public class PieDePaginaRepetible : PdfPageEventHelper
    {
        private PdfPTable footerTable;

        public PieDePaginaRepetible(PdfPTable table)
        {
            footerTable = table;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            footerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;

            footerTable.WriteSelectedRows(
                0, -1,
                document.LeftMargin,
                document.BottomMargin - 5, // posición vertical (ligeramente por debajo del margen inferior)
                writer.DirectContent);
        }
    }*/
    public class CabeceraPiePaginaRepetible : PdfPageEventHelper
    {
        private readonly PdfPTable _headerTable;
        private readonly PdfPTable _footerTable;

        public CabeceraPiePaginaRepetible(PdfPTable headerTable, PdfPTable footerTable)
        {
            _headerTable = headerTable;
            _footerTable = footerTable;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfContentByte cb = writer.DirectContent;

            // HEADER
            if (_headerTable != null)
            {
                _headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                _headerTable.WriteSelectedRows(
                    0, -1,
                    document.LeftMargin,
                    document.PageSize.Height - 10, // posición vertical desde arriba
                    cb);
            }

            // FOOTER
            if (_footerTable != null)
            {
                _footerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                _footerTable.WriteSelectedRows(
                    0, -1,
                    document.LeftMargin,
                    document.BottomMargin + 25, // posición vertical desde abajo
                    cb);
            }
        }
    }
}