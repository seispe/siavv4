using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.GP
{
    public class AD_Cobranzas
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbdynamics = null;
        private SqlConnection dbdynamicslocal = null;
        private SqlConnection dbdynamicscao = null;
        #endregion

        #region Constructor
        public AD_Cobranzas(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con"+empresa].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
            dbdynamicslocal = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSlocal"].ConnectionString);
            dbdynamicscao = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSCAO"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetListadoDoc(int idsolicitud, string dato1, string tipo, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COB_PingresoDoc", db);
                da.SelectCommand.Parameters.AddWithValue("@idsolicitud", idsolicitud);
                da.SelectCommand.Parameters.AddWithValue("@ruc", dato1);
                da.SelectCommand.Parameters.AddWithValue("@cliente", dato1);
                da.SelectCommand.Parameters.AddWithValue("@ven", "");
                da.SelectCommand.Parameters.AddWithValue("@documento", "");
                da.SelectCommand.Parameters.AddWithValue("@usuario", "");
                da.SelectCommand.Parameters.AddWithValue("@observaciones", "");
                da.SelectCommand.Parameters.AddWithValue("@fsolicitud", "");
                da.SelectCommand.Parameters.AddWithValue("@frecibo", "");
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_COB_PingresoDoc");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEstadoCuenta(string cliente, string vendedor, string ciudad, string fechaEmision, string fechaVencimiento)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_Pestadocuenta", db);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
                da.SelectCommand.Parameters.AddWithValue("@ciudad", ciudad);
                da.SelectCommand.Parameters.AddWithValue("@fechaEmision", fechaEmision);
                da.SelectCommand.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tdevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetChqPostfechados(string cliente, string vendedor, string ciudad, string fechaEmision, string fechaVencimiento)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_Pchqpostfechados", db);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
                da.SelectCommand.Parameters.AddWithValue("@ciudad", ciudad);
                da.SelectCommand.Parameters.AddWithValue("@fechaEmision", fechaEmision);
                da.SelectCommand.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tdevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetChqProtestados(string cliente, string vendedor, string ciudad, string fechaEmision, string fechaVencimiento)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_Pchqprotestados", db);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
                da.SelectCommand.Parameters.AddWithValue("@ciudad", ciudad);
                da.SelectCommand.Parameters.AddWithValue("@fechaEmision", fechaEmision);
                da.SelectCommand.Parameters.AddWithValue("@fechaVencimiento", fechaVencimiento);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tdevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCuentasxCobrar(string empresa, string fecha)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPALL" || empresa == "GPVEC" || empresa == "GPACC")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxcobrar", dbdynamics);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
                else if (empresa == "GPCAO" || empresa == "GPCSA" || empresa == "GPCTO" || empresa == "GPCSG" || empresa == "GPCPI" || empresa == "GPCTA" || empresa == "GPCUC" || empresa == "GPGRP" || empresa == "GPTET" || empresa == "GPGRO" || empresa == "GPTEX")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxcobrar", dbdynamicscao);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxcobrar", dbdynamicslocal);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCuentasxPagar(string empresa, string fecha)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPALL" || empresa == "GPVEC" || empresa == "GPACC" || empresa == "GPTRA")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxpagar", dbdynamics);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
                else if (empresa == "GPCAO" || empresa == "GPCSA" || empresa == "GPCTO" || empresa == "GPCSG" || empresa == "GPCPI" || empresa == "GPCTA" || empresa == "GPCUC" || empresa == "GPGRP" || empresa == "GPTET" || empresa == "GPGRO" || empresa == "GPTEX")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxpagar", dbdynamicscao);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_cuentasxpagar", dbdynamicslocal);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tdevoluciones");
                    return ds;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// REPORTE DE RECAUDACIONES CABECERA, DETALLE DE CLIENTES
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataSet GetRecaudacionesV1(string desde, string hasta, string bases)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_RecuperarRecaudacionesV1_SP", dbdynamics);
                da.SelectCommand.CommandTimeout = 1000;
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Base", bases);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_RecuperarRecaudacionesV1_SP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REPORTE DE RECAUDACIONES, DETALLE CHEQUES INGRESADOS POR CLIENTE
        /// </summary>
        /// <param name="ruc"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataSet GetRecaudacionesV2(string ruc, string desde, string hasta, string bases)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_RecuperarRecaudaciones_detalleV2_SP", dbdynamics);
                da.SelectCommand.CommandTimeout = 1000;
                da.SelectCommand.Parameters.AddWithValue("@RUC", ruc);
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Base", bases);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_RecuperarRecaudaciones_detalleV2_SP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// REPORTE DE RECAUDACIONES, DETALLE DE FACTURAS APLICADAS
        /// </summary>
        /// <param name="ruc"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataSet GetRecaudacionesV3(string ruc, string desde, string hasta, string bases)
        {
            try
            {
                
                SqlDataAdapter da = new SqlDataAdapter("sp_RecuperarRecaudaciones_detalleV3_1_SP", dbdynamics);
                da.SelectCommand.CommandTimeout = 1000;
                da.SelectCommand.Parameters.AddWithValue("@RUC", ruc);
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Base", bases);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_RecuperarRecaudaciones_detalleV3_1_SP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Getrpt_chequesProt(string empresa, string fechai, string fechaf)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CXC_Prpt_chequesProt", dbdynamics);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaI", fechai);
                da.SelectCommand.Parameters.AddWithValue("@fechaF", fechaf);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CXC_Prpt_chequesProt");
                return ds;
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

        public DataSet Getrpt_chequesPosfNoDepo(string empresa, string fechai, string fechaf)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CXC_Prpt_chequesPosfNoDepo", dbdynamics);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaI", fechai);
                da.SelectCommand.Parameters.AddWithValue("@fechaF", fechaf);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CXC_Prpt_chequesPosfNoDepo");
                return ds;
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

        public DataSet Getrpt_chequesPosfDepo(string empresa, string fechai, string fechaf)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CXC_Prpt_chequesPosfDepo", dbdynamics);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaI", fechai);
                da.SelectCommand.Parameters.AddWithValue("@fechaF", fechaf);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CXC_Prpt_chequesPosfDepo");
                return ds;
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
        #endregion

        #region Insert
        public void insDocumentos(int idcliente, string ruc, string cliente, string ven, int documento, string usuario,string observacion, int op)
        {
            using (SqlCommand cmd = new SqlCommand("GA_COB_PingresoDoc", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsolicitud", idcliente);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@ven", ven);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@observaciones", observacion);
                cmd.Parameters.AddWithValue("@fsolicitud", "");
                cmd.Parameters.AddWithValue("@frecibo", "");
                cmd.Parameters.AddWithValue("@tipo", "");
                cmd.Parameters.AddWithValue("@op", op);
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

        public string insClientesDoc(int idsolicitud, string ruc, string cliente, string ven, DateTime fsolicitud, DateTime frecibo, string usuario, string observacion, int op)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_COB_PingresoDoc", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsolicitud", idsolicitud);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@ven", ven);
                cmd.Parameters.AddWithValue("@documento", "");
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@observaciones", observacion);
                cmd.Parameters.AddWithValue("@fsolicitud", fsolicitud);
                cmd.Parameters.AddWithValue("@frecibo", frecibo);
                cmd.Parameters.AddWithValue("@tipo", "");
                cmd.Parameters.AddWithValue("@op", op);
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

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
