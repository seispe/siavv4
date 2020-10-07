/****************************************************************
-- Titulo:  Acceso Datos Despacho
-- Author:  Sebastian Pozo
-- Fecha:   03/05/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using AccesoEntidades.Despacho;
using System.Configuration;

namespace AccesoDatos.Despacho
{
    public class AD_DES
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_DES()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString);
        }
        #endregion

        #region Select
        /// <summary>
        /// Obtener los pedidos en estado packing
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public DataSet getPedidosPacking(string estado)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_PKG_Ppedidopack", db);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_PKG_Ppedidopack");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Consultar los pedidos en estado Cobranzas, Pedido, FacturaContabilizada, Packing
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public DataSet getPedidosEstado(string estado)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_PKG_Pconsultapedido", db);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_PKG_Pconsultapedido");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public string actinsGA_PKG_Tdetalle(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pactinsdet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle", ae_ga_pkg_tdetalle.iddetalle);
                cmd.Parameters.AddWithValue("@idproceso", ae_ga_pkg_tdetalle.idproceso);
                cmd.Parameters.AddWithValue("@idmaestro", ae_ga_pkg_tdetalle.idmaestro);
                cmd.Parameters.AddWithValue("@fechaInigestion", ae_ga_pkg_tdetalle.fechaInigestion);
                cmd.Parameters.AddWithValue("@fechaFingestion", ae_ga_pkg_tdetalle.fechaFingestion);
                cmd.Parameters.AddWithValue("@documento", ae_ga_pkg_tdetalle.documento);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_pkg_tdetalle.usuario);
                cmd.Parameters.AddWithValue("@observacion", "");
                cmd.Parameters.AddWithValue("@activo", ae_ga_pkg_tdetalle.activo);
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.ToString().Trim();
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string insertGA_PKG_Tdetalle(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {           
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pinsertdet";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle", ae_ga_pkg_tdetalle.iddetalle);
                cmd.Parameters.AddWithValue("@idproceso", ae_ga_pkg_tdetalle.idproceso);
                cmd.Parameters.AddWithValue("@idmaestro", ae_ga_pkg_tdetalle.idmaestro);
                cmd.Parameters.AddWithValue("@fechaInigestion", ae_ga_pkg_tdetalle.fechaInigestion);
                cmd.Parameters.AddWithValue("@fechaFingestion", ae_ga_pkg_tdetalle.fechaFingestion);
                cmd.Parameters.AddWithValue("@documento", ae_ga_pkg_tdetalle.documento);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_pkg_tdetalle.usuario);
                cmd.Parameters.AddWithValue("@observacion", ae_ga_pkg_tdetalle.observacion);
                cmd.Parameters.AddWithValue("@activo", ae_ga_pkg_tdetalle.activo);
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

        public string insertGA_PKG_Tmaestro(AE_GA_PKG_Tmaestro ae_ga_pkg_tmaestro)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pinsertmaest";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", ae_ga_pkg_tmaestro.descripcion);
                cmd.Parameters.AddWithValue("@ruc", ae_ga_pkg_tmaestro.ruc);
                cmd.Parameters.AddWithValue("@factura ", ae_ga_pkg_tmaestro.factura);
                cmd.Parameters.AddWithValue("@fechainicio", ae_ga_pkg_tmaestro.fechainicio);
                cmd.Parameters.AddWithValue("@fechafin", ae_ga_pkg_tmaestro.fechafin);
                cmd.Parameters.AddWithValue("@estadoinicial", ae_ga_pkg_tmaestro.estadoinicial);
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

        public string validaGA_PKG_TEstado(string factura, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pvalidaesta";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@factura ", factura);
                cmd.Parameters.AddWithValue("@opcion ", opcion);
                cmd.Connection = db;
                try
                {
                    db.Open();
                    string idFromString= cmd.ExecuteScalar().ToString();
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

        public string consultaGA_PKG_TEstado(string factura, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pconsultaestado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@factura ", factura);
                cmd.Parameters.AddWithValue("@opcion ", opcion);
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

        #endregion

        #region Update
        public string actGcliGA_PKG_Tdetalle(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_PKG_Pactgcli";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle", ae_ga_pkg_tdetalle.iddetalle);
                cmd.Parameters.AddWithValue("@fechaFingestion", ae_ga_pkg_tdetalle.fechaFingestion);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_pkg_tdetalle.usuario);
                cmd.Parameters.AddWithValue("@observacion", ae_ga_pkg_tdetalle.observacion);
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

        #region Delete

        #endregion
    }
}
