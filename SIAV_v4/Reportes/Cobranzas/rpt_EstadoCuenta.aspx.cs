using AccesoNegocios.Alertas;
using AccesoNegocios.GP;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Cobranzas
{
    public partial class rpt_EstadoCuenta : System.Web.UI.Page
    {
        #region Variables Globales
        AN_Alertas an_alertas = new AN_Alertas();
        AN_Cobranzas an_cobranzas = null;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            an_cobranzas = new AN_Cobranzas(Request.Cookies["basesiav"].Value);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            VincularGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(),txtFechaEmision.Text.Trim(),txtFechaVencimiento.Text.Trim());
        }

        #region Funciones Agregadas
        public void VincularGrid(string cliente,string vendedor,string ciudad,string fechaEmision, string fechaVencimiento)
        {
            gvEstadoCuenta.DataSource = an_cobranzas.LlenarGrid(cliente, vendedor, ciudad, fechaEmision, fechaVencimiento, 1).DataSource;
            gvEstadoCuenta.DataBind();
        }

        protected void gvEstadoCuenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEstadoCuenta.PageIndex = e.NewPageIndex;
            VincularGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim());
        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            CrearDoc();
            ////Create a dummy GridView
            //GridView GridView1 = new GridView();
            //GridView1.AllowPaging = false;
            //GridView1.DataSource = an_cobranzas.LlenarGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim()).DataSource;
            //GridView1.DataBind();

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition",
            // "attachment;filename=Facturas.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    //GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
            //    GridView1.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
            //}
            //GridView1.RenderControl(hw);

            ////style to format numbers to string
            ////string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            ////Response.Write(style);
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();
        }

        //protected void ExportToCSV(object sender, EventArgs e)
        //{
        //    //Get the data from database into datatable
        //    DataTable dt = an_cobranzas.generarCSV(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim()).Tables[0];

        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=rptEstadoCuenta.csv");
        //    Response.Charset = "";
        //    Response.ContentType = "application/text";


        //    StringBuilder sb = new StringBuilder();
        //    for (int k = 0; k < dt.Columns.Count; k++)
        //    {
        //        //add separator
        //        sb.Append(dt.Columns[k].ColumnName + ',');
        //    }
        //    //append new line
        //    sb.Append("\r\n");
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        for (int k = 0; k < dt.Columns.Count; k++)
        //        {
        //            //add separator
        //            sb.Append(dt.Rows[i][k].ToString().Replace(",", ";") + ',');
        //        }
        //        //append new line
        //        sb.Append("\r\n");
        //    }
        //    Response.Output.Write(sb.ToString());
        //    Response.Flush();
        //    Response.End();
        //}

        public void CrearDoc()
        {
            if (Request.Cookies["basesiav"].Value == "GPTRA" || Request.Cookies["basesiav"].Value == "GPTEC")
            {
                //Create a dummy GridView
                GridView GridViewTRA = new GridView();
                GridViewTRA.AllowPaging = false;
                GridViewTRA.DataSource = an_cobranzas.LlenarGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim(), 1).DataSource;
                GridViewTRA.DataBind();

                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition",
                 "attachment;filename=EstadoCuenta.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                for (int i = 0; i < GridViewTRA.Rows.Count; i++)
                {
                    //GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                    GridViewTRA.Rows[i].Cells[0].Attributes.Add("style", @"mso-number-format:\@");
                    GridViewTRA.Rows[i].Cells[7].Attributes.Add("style", @"mso-number-format:\@");
                    GridViewTRA.Rows[i].Cells[9].Attributes.Add("style", @"mso-number-format:\@");
                }
                GridViewTRA.RenderControl(hw);

                //style to format numbers to string
                //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                //Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
            else
            {
                string filename = @"C:\PRUEBAS\rptEstadoCuenta.xlsx";

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
                    ConstructCell("RUC", CellValues.String),
                    ConstructCell("CLIENTE", CellValues.String),
                    ConstructCell("NOM_COMERCIAL", CellValues.String),
                    ConstructCell("CIUDAD", CellValues.String),
                    ConstructCell("TIPO", CellValues.String),
                    ConstructCell("VEN_CODIGO_TAR", CellValues.String),
                    ConstructCell("DIRECCION", CellValues.String),
                    ConstructCell("TELEFONO", CellValues.String),
                    ConstructCell("TIPO_DOC", CellValues.String),
                    ConstructCell("FACTURA", CellValues.String),
                    ConstructCell("F_EMISION", CellValues.String),
                    ConstructCell("F_VENCIMIENTO", CellValues.String),
                    ConstructCell("VEN_CODIGO_DOC", CellValues.String),
                    ConstructCell("COND_PAGO", CellValues.String),
                    ConstructCell("MONTO_DOC", CellValues.String),
                    ConstructCell("PENDIENTE", CellValues.String),
                    ConstructCell("DIAS_VENCIDO", CellValues.String)
                    //ConstructCell("ANULADO", CellValues.String)
                    );
                sd.AppendChild(row);
                //Datos
                GridView GridView1 = new GridView();
                GridView1.AllowPaging = false;
                GridView1.DataSource = an_cobranzas.LlenarGrid(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim(), 1).DataSource;
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
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[7].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[8].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[9].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[10].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[11].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[12].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[13].Text.Trim()), CellValues.String),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[14].Text.Trim()), CellValues.Number),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[15].Text.Trim()), CellValues.Number),
                        ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[16].Text.Trim()), CellValues.Number)
                        //ConstructCell(HttpUtility.HtmlDecode(GridView1.Rows[i].Cells[17].Text.Trim()), CellValues.String)
                        );
                    sd.AppendChild(row);
                }
                #endregion

                ws.Append(sd);
                wsp.Worksheet = ws;
                wsp.Worksheet.Save();
                Sheet sheet = new Sheet();
                sheet.Name = "Facturas";
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
                    ConstructCell("RUC", CellValues.String),
                    ConstructCell("NOM_COMERCIAL", CellValues.String),
                    ConstructCell("NOTA", CellValues.String),
                    ConstructCell("FECHA", CellValues.String),
                    ConstructCell("MNT_ORIG", CellValues.String),
                    ConstructCell("MNT_PEND", CellValues.String),
                    ConstructCell("MOTIVO", CellValues.String)
                    );
                sd2.AppendChild(row2);
                //Datos
                GridView GridView2 = new GridView();
                GridView2.AllowPaging = false;
                GridView2.DataSource = an_cobranzas.GridChqProtestados(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim(), 1).DataSource;
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
                        ConstructCell(HttpUtility.HtmlDecode(GridView2.Rows[i].Cells[6].Text.Trim()), CellValues.String)
                        );
                    sd2.AppendChild(row2);
                }
                #endregion

                ws2.AppendChild(sd2);
                wsp2.Worksheet = ws2;
                wsp2.Worksheet.Save();
                Sheet sheet2 = new Sheet();
                sheet2.Name = "ChequesProtestados";
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
                    ConstructCell("RUC", CellValues.String),
                    ConstructCell("NOM_COMERCIAL", CellValues.String),
                    ConstructCell("BANCO", CellValues.String),
                    ConstructCell("CHEQUE", CellValues.String),
                    ConstructCell("F_EMISION", CellValues.String),
                    ConstructCell("F_VENCIMIENTO", CellValues.String),
                    ConstructCell("MONTO_DOC", CellValues.String),
                    ConstructCell("DIAS_VENCIDO", CellValues.String)
                    );
                sd3.AppendChild(row3);
                //Datos
                GridView GridView3 = new GridView();
                GridView3.AllowPaging = false;
                GridView3.DataSource = an_cobranzas.GetEstadoCuenta_chqPosfVenc(txtCliente.Text.Trim(), txtVendedor.Text.Trim(), txtCiudad.Text.Trim(), txtFechaEmision.Text.Trim(), txtFechaVencimiento.Text.Trim()).DataSource;
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
                sheet3.Name = "ChequesPostFechados";
                sheet3.SheetId = 3;
                sheet3.Id = wbp.GetIdOfPart(wsp3);
                sheets.Append(sheet3);
                wbp.Workbook.Save();
                xl.Close();

                System.IO.FileInfo toDownload = new System.IO.FileInfo(filename);

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + toDownload.Name);
                HttpContext.Current.Response.AddHeader("Content-Length", toDownload.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(filename);
                HttpContext.Current.Response.End();
            }
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
    }
}