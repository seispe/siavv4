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
        private SqlConnection dbwms = null;
        private SqlConnection dbwmsQ = null;
        private SqlConnection dbwmsG = null;
        #endregion

        #region Constructor
        public AD_Logistica()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString);
            dbwms = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMSiav"].ConnectionString);
            dbwmsQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMSiavQ"].ConnectionString);
            dbwmsG = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMSiavG"].ConnectionString);
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

        public DataSet GetConductores(int op, string placa, int idconductor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PasignaConductor", dbwms);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@placa", placa);
                da.SelectCommand.Parameters.AddWithValue("@idconductor", idconductor);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PasignaConductor");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CargaVehiculos(int op, string fecha, string placa, string bodega, int fr)
        {
            try
            {
                SqlConnection conn;
                switch (bodega)
                {
                    case "PVQ":
                        conn = dbwmsQ;
                        break;
                    case "PVG":
                        conn = dbwmsG;
                        break;
                    case "MATRIZ":
                        conn = dbwms;
                        break;
                    default:
                        conn = dbwms;
                        break;
                }
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_pcheckCargaVehiculos", conn);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                da.SelectCommand.Parameters.AddWithValue("@placa", placa);
                da.SelectCommand.Parameters.AddWithValue("@fr", fr);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_pcheckCargaVehiculos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ActualizaPlacaPedido(int op, string pedido, string placa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PactualizaPlacaPedido", dbwms);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@placa", placa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PactualizaPlacaPedido");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public string StringCargaVehiculos(int op, string fecha, string placa, string bodega, int fr)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection conn;
                switch (bodega)
                {
                    case "PVQ":
                        conn = dbwmsQ;
                        break;
                    case "PVG":
                        conn = dbwmsG;
                        break;
                    case "MATRIZ":
                        conn = dbwms;
                        break;
                    default:
                        conn = dbwms;
                        break;
                }
                cmd.CommandText = "GA_WMS_pcheckCargaVehiculos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@placa", placa);
                cmd.Parameters.AddWithValue("@fr", fr);
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception ex)
                {
                    return "ERROR";
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region Update
        public string UpConductores(int op, string placa, int idconductor)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PasignaConductor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@placa", placa);
                cmd.Parameters.AddWithValue("@idconductor", idconductor);
                cmd.Connection = dbwms;
                try
                {
                    dbwms.Open();
                    cmd.ExecuteNonQuery();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return "ERROR";
                }
                finally
                {
                    dbwms.Close();
                }
            }
        }

        public string UpPlacaPedido(int op, string pedido, string placa)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
               
                cmd.CommandText = "GA_WMS_PactualizaPlacaPedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@placa", placa);
                cmd.Connection = dbwms;
                try
                {
                    dbwms.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception ex)
                {
                    return "ERROR";
                }
                finally
                {
                    dbwms.Close();
                }
            }
        }
        #endregion

        #region Delete
        #endregion
    }
}
