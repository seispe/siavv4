using AccesoDatos.Logistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

//using DotNet.Highcharts;
//using DotNet.Highcharts.Helpers;
//using DotNet.Highcharts.Enums;
//using DotNet.Highcharts.Options;

namespace AccesoNegocios.Logistica
{
    public class AN_Logistica
    {
        #region Variables Globales
        AD_Logistica ad_logistica = new AD_Logistica();
        #endregion

        #region Constructor
        /*public AN_Logistica(string empresa)
        { 
        }*/
        #endregion

        #region Funciones
        public GridView rpt_tiemposlogistica(string empresa, string fechaInicio, string fechaFin)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_logistica.GetTiemposLogistica(empresa, fechaInicio, fechaFin);

            if (dsp.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dsp;
                gv.DataBind();
            }
            else
            {
                dsp.Tables[0].Rows.Add(dsp.Tables[0].NewRow());
                gv.DataSource = dsp;
                gv.DataBind();
                int columncount = gv.Rows[0].Cells.Count;
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }
        /*
        public string getBasicaLinea()
        {
            Highcharts chart = new Highcharts("BasicaLinea")
                .InitChart(new Chart
                {
                    DefaultSeriesType = ChartTypes.Line,
                    MarginRight = 130,
                    MarginBottom = 25,
                    ClassName = "chart"
                })
                .SetTitle(new Title
                {
                    Text = "Monthly Average Temperature",
                    X = -20
                })
                .SetSubtitle(new Subtitle
                {
                    Text = "Source: WorldClimate.com",
                    X = -20
                })
                .SetXAxis(new XAxis { Categories = AD_HighChart.Categories })
                .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle { Text = "Temperature (°C)" },
                    PlotLines = new[]
                                          {
                                              new YAxisPlotLines
                                              {
                                                  Value = 0,
                                                  Width = 1,
                                                  Color = ColorTranslator.FromHtml("#808080")
                                              }
                                          }
                })
                .SetTooltip(new Tooltip
                {
                    Formatter = @"function() {
                                        return '<b>'+ this.series.name +'</b><br/>'+
                                    this.x +': '+ this.y +'°C';
                                }"
                })
                .SetLegend(new Legend
                {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Right,
                    VerticalAlign = VerticalAligns.Top,
                    X = -10,
                    Y = 100,
                    BorderWidth = 0
                })
                .SetSeries(new[]
                           {
                               new Series { Name = "Tokyo", Data = new Data(AD_HighChart.TokioData) },
                               new Series { Name = "New York", Data = new Data(AD_HighChart.NewYorkData) },
                               new Series { Name = "Berlin", Data = new Data(AD_HighChart.BerlinData) },
                               new Series { Name = "London", Data = new Data(AD_HighChart.LondonData) }
                           }
                );

            return chart.ToHtmlString();
        }*/
        #endregion
    }
}
