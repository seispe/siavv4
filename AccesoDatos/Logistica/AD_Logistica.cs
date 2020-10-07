using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Logistica
{
    public class AD_Logistica
    {
        #region Variables Globales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_Logistica()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetTiemposLogistica(string empresa, string fechaInicio, string fechaFin)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_LOG_getTiempos", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@fechafin", fechaFin);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_LOG_Tiempos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
