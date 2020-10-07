using AccesoNegocios.Alertas;
using AccesoNegocios.TOC;
using System;

namespace SIAV_v4.Reportes.TOC
{
    public partial class rpt_DisponibilidadABC : System.Web.UI.Page
    {
        #region Variables Globales
        AN_TOC an_teoriaRestricciones = new AN_TOC("conTOC_ALL");
        AN_Alertas an_alertas = new AN_Alertas();
        #endregion

        #region VincularGrid
        public void VincularGrid()
        {
            gvBuffer.DataSource = an_teoriaRestricciones.GetRDisponibilidadABC(txtFechaInicio.Text.Trim()).DataSource;
            gvBuffer.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VincularGrid();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            VincularGrid();
        }

    }
}