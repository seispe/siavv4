using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BorderStyle = NPOI.SS.UserModel.BorderStyle;

namespace SIAV_v4.Reportes.Devoluciones
{
    public partial class rpt_CtrlCalidad : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                ExportToExcel();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }
        #endregion

        #region Funciones
        public void ExportToExcel()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();

            ISheet sheet = workbook.CreateSheet("Control Calidad");

            sheet.RepeatingRows = new CellRangeAddress(0, 4, -1, -1);

            //=====================================================
            // CONFIGURACIÓN DE PÁGINA
            //=====================================================

            XSSFSheet xSheet = (XSSFSheet)sheet;

            xSheet.PrintSetup.Landscape = true;
            xSheet.PrintSetup.PaperSize = (short)PaperSize.A4;

            sheet.FitToPage = true;
            sheet.PrintSetup.FitWidth = 1;
            sheet.PrintSetup.FitHeight = 0;

            sheet.SetMargin(MarginType.LeftMargin, 0.20);
            sheet.SetMargin(MarginType.RightMargin, 0.20);
            sheet.SetMargin(MarginType.TopMargin, 0.30);
            sheet.SetMargin(MarginType.BottomMargin, 0.30);

            //-----------------------------------------------------
            // FUENTES
            //-----------------------------------------------------

            IFont fuenteTitulo = workbook.CreateFont();
            fuenteTitulo.FontHeightInPoints = 14;
            fuenteTitulo.IsBold = true;
            fuenteTitulo.FontName = "Calibri";

            IFont fuenteNormal = workbook.CreateFont();
            fuenteNormal.FontHeightInPoints = 10;
            fuenteNormal.FontName = "Calibri";

            IFont fuenteNegrita = workbook.CreateFont();
            fuenteNegrita.FontHeightInPoints = 10;
            fuenteNegrita.IsBold = true;
            fuenteNegrita.FontName = "Calibri";

            //-----------------------------------------------------
            // ESTILO TITULO
            //-----------------------------------------------------

            ICellStyle estiloTitulo = workbook.CreateCellStyle();

            estiloTitulo.Alignment = HorizontalAlignment.Center;
            estiloTitulo.VerticalAlignment = VerticalAlignment.Center;
            estiloTitulo.SetFont(fuenteTitulo);

            //-----------------------------------------------------
            // ESTILO CUADRO DERECHO
            //-----------------------------------------------------

            ICellStyle estiloDerecha = workbook.CreateCellStyle();

            estiloDerecha.BorderBottom = BorderStyle.Thin;
            estiloDerecha.BorderTop = BorderStyle.Thin;
            estiloDerecha.BorderLeft = BorderStyle.Thin;
            estiloDerecha.BorderRight = BorderStyle.Thin;

            estiloDerecha.SetFont(fuenteNegrita);

            estiloDerecha.VerticalAlignment = VerticalAlignment.Center;

            //-----------------------------------------------------
            // ESTILO NORMAL
            //-----------------------------------------------------

            ICellStyle estiloNormal = workbook.CreateCellStyle();

            estiloNormal.SetFont(fuenteNormal);
            estiloNormal.VerticalAlignment = VerticalAlignment.Center;

            IRow fila1 = sheet.CreateRow(0);
            IRow fila2 = sheet.CreateRow(1);
            IRow fila3 = sheet.CreateRow(2);
            IRow fila4 = sheet.CreateRow(3);

            fila1.HeightInPoints = 15;
            fila2.HeightInPoints = 15;
            fila3.HeightInPoints = 15;
            fila4.HeightInPoints = 15;

            // Logo
            CellRangeAddress regionLogo = new CellRangeAddress(0, 3, 0, 1);

            sheet.AddMergedRegion(regionLogo);

            RegionUtil.SetBorderTop((int)BorderStyle.Thin, regionLogo, sheet);
            RegionUtil.SetBorderBottom((int)BorderStyle.Thin, regionLogo, sheet);
            RegionUtil.SetBorderLeft((int)BorderStyle.Thin, regionLogo, sheet);
            RegionUtil.SetBorderRight((int)BorderStyle.Thin, regionLogo, sheet);

            //Titulo
            CellRangeAddress regionTitulo = new CellRangeAddress(0, 3, 2, 9);

            sheet.AddMergedRegion(regionTitulo);

            RegionUtil.SetBorderTop((int)BorderStyle.Thin, regionTitulo, sheet);
            RegionUtil.SetBorderBottom((int)BorderStyle.Thin, regionTitulo, sheet);
            RegionUtil.SetBorderLeft((int)BorderStyle.Thin, regionTitulo, sheet);
            RegionUtil.SetBorderRight((int)BorderStyle.Thin, regionTitulo, sheet);

            ICell celdaTitulo = fila1.CreateCell(2);

            celdaTitulo.SetCellValue("INSPECCIÓN FALLAS EN BAHÍAS");
            celdaTitulo.CellStyle = estiloTitulo;

            fila1.CreateCell(10).SetCellValue("CÓDIGO:");
            fila1.CreateCell(11).SetCellValue("GBM-AB-RG-08");

            fila2.CreateCell(10).SetCellValue("FECHA:");
            fila2.CreateCell(11).SetCellValue("13-07-2026");

            fila3.CreateCell(10).SetCellValue("VERSIÓN:");
            fila3.CreateCell(11).SetCellValue("00");

            fila4.CreateCell(10).SetCellValue("CÓDIGO:");
            fila4.CreateCell(11).SetCellValue("GBM-AB-RG-06");

            // Combinar las celdas de los valores (L:N)
            CellRangeAddress regionValor1 = new CellRangeAddress(0, 0, 11, 12);
            CellRangeAddress regionValor2 = new CellRangeAddress(1, 1, 11, 12);
            CellRangeAddress regionValor3 = new CellRangeAddress(2, 2, 11, 12);
            CellRangeAddress regionValor4 = new CellRangeAddress(3, 3, 11, 12);

            sheet.AddMergedRegion(regionValor1);
            sheet.AddMergedRegion(regionValor2);
            sheet.AddMergedRegion(regionValor3);
            sheet.AddMergedRegion(regionValor4);

            ICellStyle estiloValor = workbook.CreateCellStyle();

            estiloValor.BorderBottom = BorderStyle.Thin;
            estiloValor.BorderTop = BorderStyle.Thin;
            estiloValor.BorderLeft = BorderStyle.Thin;
            estiloValor.BorderRight = BorderStyle.Thin;

            estiloValor.SetFont(fuenteNormal);

            estiloValor.Alignment = HorizontalAlignment.Left;
            estiloValor.VerticalAlignment = VerticalAlignment.Center;

            estiloDerecha.Alignment = HorizontalAlignment.Left;

            for (int f = 0; f < 4; f++)
            {
                IRow fila = sheet.GetRow(f);

                if (fila.GetCell(10) == null)
                    fila.CreateCell(10);

                if (fila.GetCell(11) == null)
                    fila.CreateCell(11);

                fila.GetCell(10).CellStyle = estiloDerecha;
                fila.GetCell(11).CellStyle = estiloValor;
            }

            CellRangeAddress[] regionesValores =
            {
                regionValor1,
                regionValor2,
                regionValor3,
                regionValor4
            };

            foreach (var region in regionesValores)
            {
                RegionUtil.SetBorderTop((int)BorderStyle.Thin, region, sheet);
                RegionUtil.SetBorderBottom((int)BorderStyle.Thin, region, sheet);
                RegionUtil.SetBorderLeft((int)BorderStyle.Thin, region, sheet);
                RegionUtil.SetBorderRight((int)BorderStyle.Thin, region, sheet);
            }

            string rutaLogo = Server.MapPath("~/Recursos/logos/LogoIAV.png");

            byte[] bytes = File.ReadAllBytes(rutaLogo);

            int pictureIdx = workbook.AddPicture(bytes, PictureType.PNG);

            IDrawing drawing = sheet.CreateDrawingPatriarch();

            IClientAnchor anchor = workbook.GetCreationHelper().CreateClientAnchor();

            anchor.Col1 = 0;
            anchor.Row1 = 0;

            anchor.Col2 = 2;
            anchor.Row2 = 4;
            // Márgenes internos
            anchor.Dx1 = Units.ToEMU(6);
            anchor.Dy1 = Units.ToEMU(4);

            anchor.Dx2 = Units.ToEMU(-6);
            anchor.Dy2 = Units.ToEMU(-4);

            drawing.CreatePicture(anchor, pictureIdx);

            //TABLA
            IRow filaCabecera = sheet.CreateRow(4);
            string[] columnas =
            {
                "PEDIDO",
                "CIUDAD",
                "TRANSPORTE",
                "PRODUCTO",
                "DESCRIPCIÓN",
                "VOID ANT",
                "VOID NUE",
                "MOTIVO",
                "CANTIDAD",
                "OBSERVACIÓN 1",
                "OBSERVACIÓN 2",
                "DESTINO",
                "FECHA"
            };

            ICellStyle estiloTablaWrap = workbook.CreateCellStyle();

            estiloTablaWrap.BorderTop = BorderStyle.Thin;
            estiloTablaWrap.BorderBottom = BorderStyle.Thin;
            estiloTablaWrap.BorderLeft = BorderStyle.Thin;
            estiloTablaWrap.BorderRight = BorderStyle.Thin;

            estiloTablaWrap.SetFont(fuenteNormal);

            estiloTablaWrap.VerticalAlignment = VerticalAlignment.Top;
            estiloTablaWrap.WrapText = true;

            ICellStyle estiloCabeceraTabla = workbook.CreateCellStyle();

            estiloCabeceraTabla.BorderTop = BorderStyle.Thin;
            estiloCabeceraTabla.BorderBottom = BorderStyle.Thin;
            estiloCabeceraTabla.BorderLeft = BorderStyle.Thin;
            estiloCabeceraTabla.BorderRight = BorderStyle.Thin;

            estiloCabeceraTabla.SetFont(fuenteNegrita);

            estiloCabeceraTabla.Alignment = HorizontalAlignment.Center;
            estiloCabeceraTabla.VerticalAlignment = VerticalAlignment.Center;
            estiloCabeceraTabla.WrapText = true;

            for (int i = 0; i < columnas.Length; i++)
            {
                ICell celda = filaCabecera.CreateCell(i);
                celda.SetCellValue(columnas[i]);
                celda.CellStyle = estiloCabeceraTabla;
            }
            sheet.SetColumnWidth(0, 15 * 256); // Pedido
            sheet.SetColumnWidth(1, 15 * 256); // Ciudad
            sheet.SetColumnWidth(2, 9 * 256); // Transporte
            sheet.SetColumnWidth(3, 13 * 256); // Producto
            sheet.SetColumnWidth(4, 45 * 256); // Descripción
            sheet.SetColumnWidth(5, 10 * 256); // Void Ant
            sheet.SetColumnWidth(6, 10 * 256); // Void Nue
            sheet.SetColumnWidth(7, 20 * 256); // Motivo
            sheet.SetColumnWidth(8, 7 * 256); // Cantidad
            sheet.SetColumnWidth(9, 25 * 256); // Observación 1
            sheet.SetColumnWidth(10, 12 * 256); // Observación 2
            sheet.SetColumnWidth(11, 12 * 256); // Destino
            sheet.SetColumnWidth(12, 16 * 256); // Fecha

            DataSet ds = an_wms.GetrptCtrlCalidad(txtfdesde.Text.Trim(), txtfhasta.Text.Trim(), 1);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                // Aquí puedes mostrar un mensaje al usuario
                return;
            }

            DataTable dt = ds.Tables[0];
            int filaExcel = 5;

            foreach (DataRow dr in dt.Rows)
            {
                IRow fila = sheet.CreateRow(filaExcel++);

                ICell celdaPedido = fila.CreateCell(0);
                celdaPedido.SetCellValue(dr["pedido"].ToString());
                celdaPedido.CellStyle = estiloTablaWrap;

                ICell celdaCiudad = fila.CreateCell(1);
                celdaCiudad.SetCellValue(dr["ciudad"].ToString());
                celdaCiudad.CellStyle = estiloTablaWrap;

                ICell celdaTransporte = fila.CreateCell(2);
                celdaTransporte.SetCellValue(dr["transporte"].ToString());
                celdaTransporte.CellStyle = estiloTablaWrap;
                
                ICell celdaProducto = fila.CreateCell(3);
                celdaProducto.SetCellValue(dr["producto"].ToString());
                celdaProducto.CellStyle = estiloTablaWrap;

                ICell celdaDescripcion = fila.CreateCell(4);
                celdaDescripcion.SetCellValue(dr["descripcion"].ToString());
                celdaDescripcion.CellStyle = estiloTablaWrap;

                ICell celdaVoidAnt = fila.CreateCell(5);
                celdaVoidAnt.SetCellValue(dr["voidAnt"].ToString());
                celdaVoidAnt.CellStyle = estiloTablaWrap;

                ICell celdaVoidNue = fila.CreateCell(6);
                celdaVoidNue.SetCellValue(dr["voidNue"].ToString());
                celdaVoidNue.CellStyle = estiloTablaWrap;

                ICell celdaMotivo = fila.CreateCell(7);
                celdaMotivo.SetCellValue(dr["motivo"].ToString());
                celdaMotivo.CellStyle = estiloTablaWrap;

                ICell celdaCantidad = fila.CreateCell(8);
                if (dr["cantidad"] != DBNull.Value)
                    celdaCantidad.SetCellValue(Convert.ToDouble(dr["cantidad"]));
                else
                    celdaCantidad.SetCellValue("");
                celdaCantidad.CellStyle = estiloTablaWrap;

                ICell celdaObservacion1 = fila.CreateCell(9);
                celdaObservacion1.SetCellValue(dr["observacion1"].ToString());
                celdaObservacion1.CellStyle = estiloTablaWrap;

                ICell celdaObservacion2 = fila.CreateCell(10);
                celdaObservacion2.SetCellValue(dr["observacion2"].ToString());
                celdaObservacion2.CellStyle = estiloTablaWrap;

                ICell celdaDestino = fila.CreateCell(11);
                celdaDestino.SetCellValue(dr["destino"].ToString());
                celdaDestino.CellStyle = estiloTablaWrap;

                ICell celdaFecha = fila.CreateCell(12);
                if (dr["fecha"] != DBNull.Value)
                    celdaFecha.SetCellValue(Convert.ToDateTime(dr["fecha"]).ToString("dd/MM/yyyy HH:mm"));
                else
                    celdaFecha.SetCellValue("");
                celdaFecha.CellStyle = estiloTablaWrap;
            }

            //Footer
            int filaFooter = filaExcel;
            IRow footer1 = sheet.CreateRow(filaFooter);
            IRow footer2 = sheet.CreateRow(filaFooter + 1);
            IRow footer3 = sheet.CreateRow(filaFooter + 2);
            //IRow footer4 = sheet.CreateRow(filaFooter + 3);
            //sheet.SetRowBreak(filaFooter);
            for (int i = 0; i < 3; i++)
            {
                sheet.GetRow(filaFooter + i).HeightInPoints = 15;
            }

            ICellStyle estiloFooter = workbook.CreateCellStyle();

            estiloFooter.SetFont(fuenteNegrita);

            estiloFooter.Alignment = HorizontalAlignment.Left;
            estiloFooter.VerticalAlignment = VerticalAlignment.Center;

            estiloFooter.WrapText = true;
            
            CellRangeAddress regionTextoFooter =
            new CellRangeAddress(filaFooter, filaFooter + 3, 0, 9);

            sheet.AddMergedRegion(regionTextoFooter);

            CellRangeAddress regionImagenFooter =
            new CellRangeAddress(filaFooter, filaFooter + 3, 10, 12);

            sheet.AddMergedRegion(regionImagenFooter);

            RegionUtil.SetBorderTop((int)BorderStyle.Thin, regionTextoFooter, sheet);
            RegionUtil.SetBorderBottom((int)BorderStyle.Thin, regionTextoFooter, sheet);
            RegionUtil.SetBorderLeft((int)BorderStyle.Thin, regionTextoFooter, sheet);
            RegionUtil.SetBorderRight((int)BorderStyle.Thin, regionTextoFooter, sheet);


            RegionUtil.SetBorderTop((int)BorderStyle.Thin, regionImagenFooter, sheet);
            RegionUtil.SetBorderBottom((int)BorderStyle.Thin, regionImagenFooter, sheet);
            RegionUtil.SetBorderLeft((int)BorderStyle.Thin, regionImagenFooter, sheet);
            RegionUtil.SetBorderRight((int)BorderStyle.Thin, regionImagenFooter, sheet);

            ICell celdaFooter = footer1.CreateCell(0);

            celdaFooter.SetCellValue(
                "Todos los derechos reservados por IAV. Prohibida su reproduccion parcial o total sin autorizacion de IAV. Documento controlado por el SGC."
            );
            
            celdaFooter.CellStyle = estiloFooter;

            string rutaFooter = Server.MapPath("~/Recursos/logos/selloSGCiav.png");

            byte[] bytesFooter = File.ReadAllBytes(rutaFooter);

            int pictureFooter = workbook.AddPicture(
                bytesFooter,
                PictureType.PNG
            );

            IDrawing drawingFooter = sheet.CreateDrawingPatriarch();

            IClientAnchor anchorFooter = workbook.GetCreationHelper()
                .CreateClientAnchor();

            anchorFooter.Col1 = 10;
            anchorFooter.Row1 = filaFooter;

            anchorFooter.Col2 = 13;
            anchorFooter.Row2 = filaFooter + 4;

            // margen interno
            anchorFooter.Dx1 = Units.ToEMU(6);
            anchorFooter.Dy1 = Units.ToEMU(4);
            anchorFooter.Dx2 = Units.ToEMU(-6);
            anchorFooter.Dy2 = Units.ToEMU(-4);

            drawingFooter.CreatePicture(anchorFooter, pictureFooter);

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);

                Response.Clear();
                Response.Buffer = true;

                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("Content-Disposition", "attachment; filename=rptCtrlCalidad.xlsx");
                Response.BinaryWrite(ms.ToArray());

                Response.End();
            }
        }
        #endregion

    }
}