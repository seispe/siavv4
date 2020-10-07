using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.GP
{
    public class AD_Produccion
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbdynamics = null;
        private SqlConnection dbdynamicslocal = null;
        #endregion

        #region Constructor
        public AD_Produccion(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbdynamicslocal = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSlocal"].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetProdxMes(string empresa, string fechaDesde, string fechaHasta)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPALL" || empresa == "GPVEC" || empresa == "GPACC")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_PRD_ProdxMes", dbdynamics);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaDesde", Convert.ToDateTime(fechaDesde).ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@fechaHasta", Convert.ToDateTime(fechaHasta).ToString("yyyy-MM-dd"));
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_PRD_ProdxMes");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_PRD_ProdxMes", dbdynamicslocal);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_PRD_ProdxMes");
                    return ds;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
