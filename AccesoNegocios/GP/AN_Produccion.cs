using AccesoDatos.GP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AccesoNegocios.GP
{
    public class AN_Produccion
    {
        #region Variables Globales
        AD_Produccion ad_produccion = null;
        #endregion

        #region Constructor
        public AN_Produccion(string empresa)
        {
            ad_produccion = new AD_Produccion(empresa);
        }
        #endregion

        #region Funciones
        public GridView GetProdxMes(string empresa, string fechaDesde, string fechaHasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_produccion.GetProdxMes(empresa, fechaDesde, fechaHasta);

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
        #endregion
    }
}
