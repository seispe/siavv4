using AccesoDatos.TOC;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.TOC
{
    public class AN_TOC
    {
        #region Variables Globales
        AD_TOC ad_toc = null;
        #endregion

        #region Constructor
        public AN_TOC(string empresa)
        {
            ad_toc = new AD_TOC(empresa);
        }
        #endregion

        #region Funciones
        public GridView GetRDisponibilidadABC(string buscar)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_toc.GetRDisponibilidadABC(buscar);

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
