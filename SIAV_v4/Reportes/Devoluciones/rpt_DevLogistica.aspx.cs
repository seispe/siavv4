using AccesoNegocios.Alertas;
using AccesoNegocios.Devoluciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes.Devoluciones
{
    public partial class rpt_DevLogistica : System.Web.UI.Page
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
            if (txtNumDevol.Text != "")
            {
                VincularGrid(txtNumDevol.Text.Trim(), "", 1);
            }
            else if (txtFechaDesde.Text != "" && txtFechaHasta.Text != "")
            {
                VincularGrid(txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim(), 1);
            }
            else
            {
                lblError.Text = an_alertas.Mensaje("ERROR ", " INGRESE FECHAS O NUM DEVOLUCION", "rojo");
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            if (txtNumDevol.Text != "")
            {
                GridView1.DataSource = an_devolucion.Getrpt_picadaslog(txtNumDevol.Text.Trim(),"",1).DataSource;
            }
            else if (txtFechaDesde.Text != "" && txtFechaHasta.Text != "")
            {
                GridView1.DataSource = an_devolucion.Getrpt_picadaslog(txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim(), 1).DataSource;
            }
            else
            {
                GridView1.DataSource = an_devolucion.Getrpt_picadaslog(txtFechaDesde.Text.Trim(), txtFechaHasta.Text.Trim(),1 ).DataSource;
            }
            
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition",
             "attachment;filename=rptDevLogisticaPicadas.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //GridView1.Rows[i].Attributes.Add("style", @"mso-number-format:\@");
                GridView1.Rows[i].Cells[1].Attributes.Add("style", @"mso-number-format:\@");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            //string style = "<style> .textmode { mso-number-format:\"\@\" } </style>";
            //Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        #endregion

        #region Funciones
        public void VincularGrid(string dato1, string dato2, int op)
        {
            gvDev.DataSource = an_devolucion.Getrpt_picadaslog(dato1, dato2, op).DataSource;
            gvDev.DataBind();
        }
        #endregion


    }
}