using AccesoNegocios.Alertas;
using AccesoNegocios.WMSiav;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.WMSiav
{
    public partial class rpt_ConspenxUsuario : System.Web.UI.Page
    {
        #region VariablesGlobales
        AN_WMS an_wms = new AN_WMS();
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region Funciones
        public void GridPendientes()
        {
            try
            {
                gvConsPendxUsu.DataSource = an_wms.GetConspenxUsuario().DataSource;
                gvConsPendxUsu.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        public void CrearDoc()
        {
            string filename = @"C:\PRUEBAS\rptPendxFamilia.xlsx";

            //MemoryStream ms = new MemoryStream();
            SpreadsheetDocument xl = SpreadsheetDocument.Create(filename, SpreadsheetDocumentType.Workbook);
            WorkbookPart wbp = xl.AddWorkbookPart();
            wbp.Workbook = new Workbook();
            Sheets sheets = xl.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            //First Sheet
            WorksheetPart wsp = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws = new Worksheet();
            SheetData sd = new SheetData();

            #region DatosEstadoCuenta
            Row row = new Row();
            row.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                //ConstructCell("ANULADO", CellValues.String)
                );
            sd.AppendChild(row);
            //Datos
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_wms.GetPendxFamilia(1).DataSource;
            GridView1.DataBind();

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                row = new Row();
                row.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    //ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[17].Text.Trim()), CellValues.String)
                    );
                sd.AppendChild(row);
            }
            #endregion

            ws.Append(sd);
            wsp.Worksheet = ws;
            wsp.Worksheet.Save();
            Sheet sheet = new Sheet();
            sheet.Name = "CAPOTS";
            sheet.SheetId = 1;
            sheet.Id = wbp.GetIdOfPart(wsp);
            sheets.Append(sheet);

            //Second Sheet
            WorksheetPart wsp2 = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws2 = new Worksheet();
            SheetData sd2 = new SheetData();

            #region Protestados
            Row row2 = new Row();
            row2.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                );
            sd2.AppendChild(row2);
            //Datos
            GridView GridView2 = new GridView();
            GridView2.AllowPaging = false;
            GridView2.DataSource = an_wms.GetPendxFamilia(2).DataSource;
            GridView2.DataBind();

            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                row2 = new Row();
                row2.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    );
                sd2.AppendChild(row2);
            }
            #endregion

            ws2.AppendChild(sd2);
            wsp2.Worksheet = ws2;
            wsp2.Worksheet.Save();
            Sheet sheet2 = new Sheet();
            sheet2.Name = "GUARDACHOQUE";
            sheet2.SheetId = 2;
            sheet2.Id = wbp.GetIdOfPart(wsp2);
            sheets.Append(sheet2);

            //Tercer Sheet
            WorksheetPart wsp3 = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws3 = new Worksheet();
            SheetData sd3 = new SheetData();

            #region PostFechados
            Row row3 = new Row();
            row3.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                );
            sd3.AppendChild(row3);
            //Datos
            GridView GridView3 = new GridView();
            GridView3.AllowPaging = false;
            GridView3.DataSource = an_wms.GetPendxFamilia(3).DataSource;
            GridView3.DataBind();

            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
                row3 = new Row();
                row3.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView3.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    );
                sd3.AppendChild(row3);
            }
            #endregion

            ws3.AppendChild(sd3);
            wsp3.Worksheet = ws3;
            wsp3.Worksheet.Save();
            Sheet sheet3 = new Sheet();
            sheet3.Name = "REFUERZOS";
            sheet3.SheetId = 3;
            sheet3.Id = wbp.GetIdOfPart(wsp3);
            sheets.Append(sheet3);

            //CUARTA Sheet
            WorksheetPart wsp4 = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws4 = new Worksheet();
            SheetData sd4 = new SheetData();

            #region PostFechados
            Row row4 = new Row();
            row4.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                );
            sd4.AppendChild(row4);
            //Datos
            GridView GridView4 = new GridView();
            GridView4.AllowPaging = false;
            GridView4.DataSource = an_wms.GetPendxFamilia(4).DataSource;
            GridView4.DataBind();

            for (int i = 0; i < GridView4.Rows.Count; i++)
            {
                row4 = new Row();
                row4.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView4.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    );
                sd4.AppendChild(row4);
            }
            #endregion

            ws4.AppendChild(sd4);
            wsp4.Worksheet = ws4;
            wsp4.Worksheet.Save();
            Sheet sheet4 = new Sheet();
            sheet4.Name = "SILVIN";
            sheet4.SheetId = 4;
            sheet4.Id = wbp.GetIdOfPart(wsp4);
            sheets.Append(sheet4);

            //QUINTA Sheet
            WorksheetPart wsp5 = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws5 = new Worksheet();
            SheetData sd5 = new SheetData();

            #region PostFechados
            Row row5 = new Row();
            row5.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                );
            sd5.AppendChild(row5);
            //Datos
            GridView GridView5 = new GridView();
            GridView5.AllowPaging = false;
            GridView5.DataSource = an_wms.GetPendxFamilia(5).DataSource;
            GridView5.DataBind();

            for (int i = 0; i < GridView5.Rows.Count; i++)
            {
                row5 = new Row();
                row5.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView5.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    );
                sd5.AppendChild(row5);
            }
            #endregion

            ws5.AppendChild(sd5);
            wsp5.Worksheet = ws5;
            wsp5.Worksheet.Save();
            Sheet sheet5 = new Sheet();
            sheet5.Name = "U RADIADOR";
            sheet5.SheetId = 5;
            sheet5.Id = wbp.GetIdOfPart(wsp5);
            sheets.Append(sheet5);

            //SEXTA Sheet
            WorksheetPart wsp6 = wbp.AddNewPart<WorksheetPart>();
            Worksheet ws6 = new Worksheet();
            SheetData sd6 = new SheetData();

            #region PostFechados
            Row row6 = new Row();
            row6.Append(
                ConstructCell("PEDIDO", CellValues.String),
                ConstructCell("CLIENTE", CellValues.String),
                ConstructCell("CIUDAD", CellValues.String),
                ConstructCell("CONSOLIDADO", CellValues.String),
                ConstructCell("PRODUCTO", CellValues.String),
                ConstructCell("DESCRIPCION", CellValues.String),
                ConstructCell("CANT PROCESADA", CellValues.String),
                ConstructCell("CANT FALTANTE", CellValues.String)
                );
            sd6.AppendChild(row6);
            //Datos
            GridView GridView6 = new GridView();
            GridView6.AllowPaging = false;
            GridView6.DataSource = an_wms.GetPendxFamilia(6).DataSource;
            GridView6.DataBind();

            for (int i = 0; i < GridView6.Rows.Count; i++)
            {
                row6 = new Row();
                row6.Append(
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[0].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[1].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[2].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[3].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[4].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[5].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[6].Text.Trim()), CellValues.String),
                    ConstructCell(HttpUtility.HtmlDecode(GridView6.Rows[i].Cells[7].Text.Trim()), CellValues.String)
                    );
                sd6.AppendChild(row6);
            }
            #endregion

            ws6.AppendChild(sd6);
            wsp6.Worksheet = ws6;
            wsp6.Worksheet.Save();
            Sheet sheet6 = new Sheet();
            sheet6.Name = "RADIADORES";
            sheet6.SheetId = 6;
            sheet6.Id = wbp.GetIdOfPart(wsp6);
            sheets.Append(sheet6);

            wbp.Workbook.Save();
            xl.Close();

            System.IO.FileInfo toDownload = new System.IO.FileInfo(filename);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
            HttpContext.Current.Response.AddHeader("Content-Length", toDownload.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.WriteFile(filename);
            HttpContext.Current.Response.End();


            //worksheetPart2.Worksheet.Save();

            /*Response.Clear();
            byte[] someData = ms.ToArray();
            string filename = "rptEstadoCuenta.xlsx";
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Dispostion", string.Format("attachment; filename={0}", filename));
            Response.BinaryWrite(someData);
            Response.End();*/
        }

        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = "";
                GridPendientes();
            }
            catch (Exception ex)
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", ex.Message, "rojo");
            }
        }

        protected void btnPendxEmpacar_Click(object sender, EventArgs e)
        {
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = an_wms.GetPendxEmpacar("", "09", 1).DataSource;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptPendxEmpacar3raEtapa.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnPendxFamilia_Click(object sender, EventArgs e)
        {
            CrearDoc();
        }
        #endregion


    }
}