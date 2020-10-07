/****************************************************************
-- Titulo:  Acceso Datos a Orden Compra 
-- Author:  Gabriel Reyes
-- Fecha:   26/06/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoEntidades.Seguridad;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.OrdenCompra
{
    public class AD_OCL
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbAll = null;
        private SqlConnection dbdynamics = null;
        #endregion

        #region Constructor
        public AD_OCL()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString);
            dbAll = new SqlConnection(ConfigurationManager.ConnectionStrings["conGPALL"].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
        }
        #endregion

        #region Select
        /// <summary>
        /// Obtener los padres del menu
        /// </summary>
        /// <param name="empresa">Numero de Empresa</param>
        /// <param name="usuario">Nombre de Usuario</param>
        /// <returns></returns>
        public DataSet getFacturas(string empresa,string buscar)
        {
            string procedure = "GA_OCL_Pgetfacturas";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@buscar", buscar);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                db.Open();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                da.Dispose();
                ds.Dispose();
            }
            return ds;
        }

        public DataSet GetDetalleFac(string factura, string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_OCL_PCodAll", dbAll);
                da.SelectCommand.Parameters.AddWithValue("@factura", factura);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_OCL_PCodAll");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setFacturas()
        {
            using (SqlCommand cmd = new SqlCommand("GA_OCL_Psetfacturas", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    db.Close();
                }
            }
        }
        #endregion

        #region Insert
        public string setOrdenCompra(string empresa,string factura,string bodega,string usuariogp)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_OCL_PCrearOrdenCompraGP", dbAll))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@factura", factura);
                cmd.Parameters.AddWithValue("@bodega", bodega);
                cmd.Parameters.AddWithValue("@usuariogp", usuariogp);
                try
                {
                    dbAll.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbAll.Close();
                }
            }
        }
        #endregion
    }
}
