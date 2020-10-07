using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Autorizaciones
{
    public class AD_AUT
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        private SqlConnection dbwms = null;
        private SqlConnection dbdynamics = null;
        #endregion

        #region Constructor
        public AD_AUT(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbwms = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMS"].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetFacturas(int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_PER_PgetFacturas", db);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_PER_PgetFacturas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAjustes(string ajuste, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_PER_Pgetajustes", db);
                da.SelectCommand.Parameters.AddWithValue("@ajuste", ajuste);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_PER_Pgetajustes");
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
        public string setAprobarFacturas(string factura, int opcion)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_PER_PsetAprobarFacturas", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@factura", factura);
                cmd.Parameters.AddWithValue("@opcion", opcion);
                try
                {
                    db.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string setAprobarAjustes(int id, string ajuste, int opcion)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_PER_Paprobarajustes", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ajuste", ajuste);
                cmd.Parameters.AddWithValue("@opcion", opcion);
                try
                {
                    db.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }
        #endregion

        #region Delete

        #endregion
    }
}
