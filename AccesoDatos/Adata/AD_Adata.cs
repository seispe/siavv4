using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Adata
{
    public class AD_Adata
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_Adata()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSI_CAO"].ConnectionString);
        }
        #endregion

        #region Select

        #endregion

        #region Insert
        public string InsCTR_TBL_Pruebas(string nombre, string email, string notas, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_insertPruebas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@notas", notas);
                cmd.Parameters.AddWithValue("@opcion", opcion);
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    return "OK";
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
        #endregion

        #region Update

        #endregion
    }
}
