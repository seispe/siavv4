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

        public DataSet TiemposReposicion(int op,string ruc, string bodega, int tiempo)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_TOC_tiemposreposicion", db);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@ruc", ruc);
                da.SelectCommand.Parameters.AddWithValue("@bodega", bodega);
                da.SelectCommand.Parameters.AddWithValue("@tiempo", tiempo);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_TOC_tiemposreposicion");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TiemposReposicionUp(int op, string ruc, string bodega, int tiempo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_TOC_tiemposreposicion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@bodega", bodega);
                cmd.Parameters.AddWithValue("@tiempo", tiempo);
                cmd.Connection = db;
                try
                {
                    db.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception ex)
                {
                    return "ERROR";
                }
                finally
                {
                    db.Close();
                }
            }
        }
    }
}
