using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Reportes
{
    public partial class Reporte247 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new System.Uri("http://192.168.0.208/ReportServer");
                ReportViewer1.ServerReport.ReportPath = "/" + Session["Directorio"] + "/" + Session["NombreReporte"];
                int tieneParametros = (int)Session["Parameter"];
                if (tieneParametros == 1)
                    ReportViewer1.ServerReport.SetParameters((ReportParameter[])Session["ReportParameter"]);
                ReportViewer1.ShowCredentialPrompts = false;
            }
        }

        [Serializable]
        public sealed class ReportServerNetworkCredentials : IReportServerCredentials
        {
            #region IReportServerCredentials Members
            public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName,
                out string password, out string authority)
            {
                authCookie = null;
                userName = null;
                password = null;
                authority = null;

                return false;
            }
            public WindowsIdentity ImpersonationUser
            {
                get
                {
                    return null;
                }
            }
            public System.Net.ICredentials NetworkCredentials
            {
                get
                {
                    string userName = "administrador";
                    string domainName = "ALVARADO";
                    string password = "sistemas@2015*";

                    return new System.Net.NetworkCredential(userName, password, domainName);
                }
            }

            #endregion
        }
    }
}