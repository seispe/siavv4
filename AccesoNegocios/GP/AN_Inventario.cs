using AccesoDatos.GP;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.GP
{
    public class AN_Inventario
    {
        #region Variables Globales
        AD_Inventario ad_inventario = null;
        #endregion

        #region Constructor
        public AN_Inventario(string empresa)
        {
            ad_inventario = new AD_Inventario(empresa);
        }
        #endregion

        #region Funciones
        public GridView rpt_inventariofecha(string empresa, string fecha)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_inventario.GetInventarioFecha(empresa, fecha);

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
