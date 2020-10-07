using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.TOC
{
    public class AD_TOC
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        private SqlConnection dbDynamics = null;
        #endregion

        #region Constructor
        public AD_TOC(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings[empresa].ConnectionString);
        }
        #endregion

        public DataSet GetRDisponibilidadABC(string buscar)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_r_disponibilidad_ABC", db);
                da.SelectCommand.Parameters.AddWithValue("f1", buscar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tr_r_disponibilidad");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
