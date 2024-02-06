/****************************************************************
-- Titulo:  Acceso Datos Devoluciones
-- Author:  Gabriel Reyes
-- Fecha:   02/05/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoEntidades.Devoluciones;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Devoluciones
{
    public class AD_DEV
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbwms = null;
        private SqlConnection dbwmscal = null;
        private SqlConnection dbdynamics = null;
        #endregion

        #region Constructor
        public AD_DEV(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbwms = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMSiav"].ConnectionString);
            dbwmscal = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMScal"].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetrptVoids(string documento, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PrptVoids", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@documento", documento);  
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PrptVoids");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptVoidsPVQ(string documento, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PrptVoidsPVQ", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@documento", documento);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PrptVoidsPVQ");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetItemDV(string iddevolucion, string producto, string empresa, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PcierreItem", db);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
                da.SelectCommand.Parameters.AddWithValue("@producto", producto);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PcierreItem");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDevoluciones(string empresa, string estado, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdevoluciones", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@estado", estado);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
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

        public DataSet Getrpt_porretirar(string empresa, string fechaDesde, string fechaHasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_porretirar", dbdynamics);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
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

        public DataSet Getrpt_estado(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion, string vendedor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_estado", dbdynamics);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
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

        public DataSet Getrpt_pormotivo(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_pormotivo", dbdynamics);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
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

        public DataSet Getrpt_pormotivoNC(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_pormotivoNC", dbdynamics);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Prpt_pormotivoNC");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Getrpt_pordia(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prpt_pordia", dbdynamics);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
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

        public DataSet Getrpt_picadaslog(string dato1, string dato2, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PrptLogisticapicadas", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PrptLogisticapicadas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Getrpt_devrechazadas(string dato1, string dato2, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdevrechazadas", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Pdevrechazadas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMotivos()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PgetMotivos", db);
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

        public DataSet GetDevoluciones(string empresa, int iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Piddevoluciones", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
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

        public DataSet GetDetalleDevoluciones(string empresa, string iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdetalledevol", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@iddevolucion", iddevolucion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tdetalledevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetalleDevolucionesRechazadas(string iddevolucion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdevrechazadas", db);
                da.SelectCommand.Parameters.AddWithValue("@dato1", iddevolucion);
                da.SelectCommand.Parameters.AddWithValue("@dato2", "");
                da.SelectCommand.Parameters.AddWithValue("@op", 2);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Pdevrechazadas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetalleFactura(string idweb)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdetallefactura", db);
                da.SelectCommand.Parameters.AddWithValue("@idweb", idweb);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Pdetallefactura");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetalleFactura(string empresa, string factura)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pdetallefact", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@factura", factura);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tdetallefactura");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetFactCarta(string factura, string codigo, string guia, DateTime fcourier, string usuario, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PcartaServ", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@fact", factura);
                da.SelectCommand.Parameters.AddWithValue("@cliente", "");
                da.SelectCommand.Parameters.AddWithValue("@codigo", codigo);
                da.SelectCommand.Parameters.AddWithValue("@descripcion", "");
                da.SelectCommand.Parameters.AddWithValue("@cant", 1);
                da.SelectCommand.Parameters.AddWithValue("@guia", guia);
                da.SelectCommand.Parameters.AddWithValue("@fcourier", fcourier);
                da.SelectCommand.Parameters.AddWithValue("@fdevolucion", fcourier);
                da.SelectCommand.Parameters.AddWithValue("@usuario", usuario);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PcartaServ");
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
        public string EnvioLogistica(string devolucion, string usuario, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_DEV_Pdevrechazadas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato1", devolucion);
                cmd.Parameters.AddWithValue("@dato2", usuario);
                cmd.Parameters.AddWithValue("@op", op);
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

        public void setDevolucionEstado(string empresa, string iddevolucion, string estado, string usuario, string observacion)
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_Pupdateestado", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@id", iddevolucion);
                cmd.Parameters.AddWithValue("@observacion", observacion.Trim());
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

        public void setDevolucionWMS(string empresa)
        {
            using (SqlCommand cmd = new SqlCommand("IAV_INSERTAR_DEVWMS", dbwms))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@baseGP", empresa);
                try
                {
                    dbwms.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbwms.Close();
                }
            }
        }

        public string setDevolucionGP(string iddevolucion)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("sp_CrearDevolucionGP_v3", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", iddevolucion);
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

        public string getDevolucionGPCorreo(string empresa, string iddevolucion)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("sp_CorreoDevolucion", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", iddevolucion);
                cmd.Parameters.AddWithValue("@empresa", empresa);
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

        public void actualizarDetalle(AE_GA_DEV_Tdevoldetalle ae_ga_dev_tdevoldetalle)
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_Pupdatedetalle", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle", ae_ga_dev_tdevoldetalle.iddetalle);
                cmd.Parameters.AddWithValue("@cantidadReal", ae_ga_dev_tdevoldetalle.cantidadReal);
                cmd.Parameters.AddWithValue("@motivoReal", ae_ga_dev_tdevoldetalle.motivoReal);
                cmd.Parameters.AddWithValue("@observacion", ae_ga_dev_tdevoldetalle.observacion);
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

        public void setUpdateMotivos()
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_PsetMotivos", db))
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

        public void setUpdateEstados()
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_Pdevoluciones_wms", db))
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

        public string setCierreItemDV(string iddevolucion, string producto, string empresa, int opcion)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_DEV_PcierreItem", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddevolucion", iddevolucion);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@empresa", empresa);
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

        public DataSet GetDV64(string dato1, string dato2, string empresa, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prptdevoluciones", dbwms);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Prptdevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDV64Unamuncho(string dato1, string dato2, string empresa, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Prptdevoluciones", dbwmscal);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Prptdevoluciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsCodCartServ(string factura, string cliente, string codigo, string descripcion, int cantidad, string guia, string fcourier, DateTime fdev, string usuario, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_DEV_PcartaServ";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fact", factura);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@guia", guia);
                cmd.Parameters.AddWithValue("@fcourier", fcourier);
                cmd.Parameters.AddWithValue("@fdevolucion", fdev);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@op", op);
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

        public DataSet GetDVCourierTRA(string dato1, string dato2, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PrptCourier", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@op", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PrptCourier");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDVEliminadas(string dato1, string dato2)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_rptEliminadas", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@finicio", dato1);
                da.SelectCommand.Parameters.AddWithValue("@ffin", dato2);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_rptEliminadas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //SUBIR ARCHIVO DE EXCEL A SQL
        public int cargarExcel(DataTable tabla)
        {
            int resultado = 0;
            using (SqlCommand cmd = new SqlCommand("GA_WMS_PcargaTraspasosExcel", dbwms))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("EstructuraCarga", SqlDbType.Structured).Value = tabla;
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                try
                {
                    dbwms.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dbwms.Close();
                }
            }
            return resultado;
        }

        public DataSet GetDVCompensaciones(int devolucion, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_Pcompensaciones", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@devolucion", devolucion);
                da.SelectCommand.Parameters.AddWithValue("@articulo", "");
                da.SelectCommand.Parameters.AddWithValue("@cantCompensada", 0);
                da.SelectCommand.Parameters.AddWithValue("@observacionCompensada", "");
                da.SelectCommand.Parameters.AddWithValue("@cantNoCompensada", 0);
                da.SelectCommand.Parameters.AddWithValue("@observacionNoCompensada", 0);
                da.SelectCommand.Parameters.AddWithValue("@usuario", "");
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Pcompensaciones");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setDVCompensaciones(int devolucion, string articulo, int cantCompensada, 
                string observacionCompensada, int cantNoCompensada, string observacionNoCompensada, string usuario, int op)
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_Pcompensaciones", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@devolucion", devolucion);
                cmd.Parameters.AddWithValue("@articulo", articulo);
                cmd.Parameters.AddWithValue("@cantCompensada", cantCompensada);
                cmd.Parameters.AddWithValue("@observacionCompensada", observacionCompensada);
                cmd.Parameters.AddWithValue("@cantNoCompensada", cantNoCompensada);
                cmd.Parameters.AddWithValue("@observacionNoCompensada", observacionNoCompensada);
                cmd.Parameters.AddWithValue("@usuario", usuario);
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

        public string generaTraspasos(string tipodocumento, string usuario, string motivo)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_WMS_PgenerarTraspasos", dbwms))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipodocumento", tipodocumento);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@motivo", motivo);
                try
                {
                    dbwms.Open();
                    resultado = cmd.ExecuteScalar().ToString();
                    return resultado;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    dbwms.Close();
                }
            }
        }

        public DataSet GetrptTraspasos(int op, string dato1, string dato2)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptTraspasos", dbwms);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptTraspasos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDVingresoMotivos(int devolucion, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_DEV_PingresoMotivos", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@devolucion", devolucion);
                da.SelectCommand.Parameters.AddWithValue("@articulo", "");
                da.SelectCommand.Parameters.AddWithValue("@cantFallaFabrica", 0);
                da.SelectCommand.Parameters.AddWithValue("@observacionFallaFabrica", "");
                da.SelectCommand.Parameters.AddWithValue("@cantCuarentena", 0);
                da.SelectCommand.Parameters.AddWithValue("@observacionCuarentena", 0);
                da.SelectCommand.Parameters.AddWithValue("@usuario", "");
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_PingresoMotivos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setDVingresoMotivos(int devolucion, string articulo, int cantFallaFabrica,
               string observacionFallaFabrica, int cantCuarentena, string observacionCuarentena, string usuario, int op)
        {
            using (SqlCommand cmd = new SqlCommand("GA_DEV_PingresoMotivos", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@devolucion", devolucion);
                cmd.Parameters.AddWithValue("@articulo", articulo);
                cmd.Parameters.AddWithValue("@cantFallaFabrica", cantFallaFabrica);
                cmd.Parameters.AddWithValue("@observacionFallaFabrica", observacionFallaFabrica);
                cmd.Parameters.AddWithValue("@cantCuarentena", cantCuarentena);
                cmd.Parameters.AddWithValue("@observacionCuarentena", observacionCuarentena);
                cmd.Parameters.AddWithValue("@usuario", usuario);
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
        #endregion

        #region Delete
        #endregion
    }
}
