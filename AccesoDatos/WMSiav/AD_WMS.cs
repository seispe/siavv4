/****************************************************************
-- Titulo:  Acceso Datos WMS IAV
-- Author:  Sebastian Pozo
-- Fecha:   20/07/2017
-- Version: 1.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/
using AccesoEntidades.WMSiav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.WMSiav
{
    public class AD_WMS
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        private SqlConnection dbDynamics = null;
        #endregion

        #region Constructor
        public AD_WMS()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMScal"].ConnectionString);
            dbDynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetConspenxUsuario()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptPendientesxUsu", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_rptPendientesxUsu");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetBultosxUsuario(string usuario)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptBultosxUsuario", db);
                da.SelectCommand.Parameters.AddWithValue("@usuario", usuario);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_rptBultosxUsuario");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptVoids(string documento, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PReportesWMSIAV", db);
                da.SelectCommand.Parameters.AddWithValue("@documento", documento);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PReportesWMSIAV");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetActVoids(string documento, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptVoids", db);
                da.SelectCommand.Parameters.AddWithValue("@documento", documento);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptVoids");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptRecepcion(string filtro, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PReportesRecepcion", db);
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PReportesRecepcion");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPendxFamilia(int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptPendxFamilia", db);
                da.SelectCommand.Parameters.AddWithValue("@opcion", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptPendxFamilia");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE LAS CIUDADES Y TIPOS DE PEDIDOS POR EMPRESA
        /// </summary>
        /// <param empresa="empresa"></param>
        /// <param opcion="opcion"></param>
        /// <returns></returns>
        public DataSet GetConsolidado(string empresa, string dato, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetConsolidados", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetConsolidados");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE LAS CIUDADES Y TIPOS DE PEDIDOS POR EMPRESA
        /// </summary>
        /// <param empresa="empresa"></param>
        /// <param opcion="opcion"></param>
        /// <returns></returns>
        public DataSet Gettiposciudades(string empresa, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGettiposciucli", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGettiposciucli");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAreasBodega(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetAreasBodega", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetAreasBodega");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConteoCiclico(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetCC", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PGetCC");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMConteoCiclicoProdFam()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetMconteo", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PGetMconteo");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE TODOS LOS USUARIOS TABLA GA_WMS_TUsuario
        /// </summary>
        /// <param name="id_rol"></param>
        /// <returns></returns>
        public DataSet GetPicking(int id_rol, string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PUsurol", db);
                da.SelectCommand.Parameters.AddWithValue("@id_rol", id_rol);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PUsurol");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE TODOS LOS PEDIDOS NO ASIGNADOS A USUARIOS
        /// </summary>
        /// <returns></returns>
        public DataSet GetPedidosNoAsignados(string pedido, string ciudad, string tipo, string cliente, string empresa, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetpedidos", db);
                da.SelectCommand.CommandTimeout = 120;
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@ciudad", ciudad);
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@soc_cliente", cliente);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetpedidos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNE(string pedido, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetNE", db);
                da.SelectCommand.CommandTimeout = 240;
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetNE");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPackingList(string bd, string pedidos, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PImpresionNE_hist", db);
                da.SelectCommand.CommandTimeout = 240;
                da.SelectCommand.Parameters.AddWithValue("@empresa", bd);
                da.SelectCommand.Parameters.AddWithValue("@pedidos", pedidos);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetpedidos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetallePedidosLogistica(string bd, string pedidos, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptDetallepedidos", db);
                da.SelectCommand.Parameters.AddWithValue("@empresa", bd);
                da.SelectCommand.Parameters.AddWithValue("@pedidos", pedidos);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PDetalleped");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE TODOS LOS PEDIDOS ARMADOS PARA PROCEDER A INSERTAR EN EL ESTADO 5 LOGISTICA
        /// </summary>
        /// <returns></returns>
        public DataSet GetPedidosArmados(string pedido, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PDatosSuperLogi", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PDatosSuperLogi");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTENER DATOS MAESTRO DEL PEDIDO CONSULTADO (frm_reversapicking)
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public DataSet getPedidosReversa(string pedido, string empresa, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PReversas", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PReversas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTENER EL DETALLE DE LOS CONSOLIDADOS EN PICKING
        /// </summary>
        /// <param name="numconsolidado"></param>
        /// <returns></returns>
        public DataSet getCierrePicking(string dato, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetdatosPicking", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetdatosPicking");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTIENE EL DETALLE DE PICADO DE LOS ARTICULOS
        /// </summary>
        /// <returns></returns>
        public DataSet GetDetPicking(string consolidado, string pedido, string producto, string opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PReversasdet", db);
                da.SelectCommand.Parameters.AddWithValue("@consolidado", consolidado);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@producto", producto);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PReversasdet");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetCantReversa(string consolidado, string pedido, string producto, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PReversasDetCant";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@consolidado", consolidado);
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string getCoorPedvalida(string coordenada, string pedido, string tipocoor, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PCoorPedvalida";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coordenada", coordenada);
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@tipocoor", tipocoor);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string getConsolidadoMax(string empresa, string dato, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PGetConsolidados";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@dato", dato);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string getValidaarmado(string pedido, string producto, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PValidaarmado";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string AnulaPedidoV2(string pedido, string observacion, string usuario)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PanulapedidoV2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
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

        /// <summary>
        /// Obtener datos de codigos alternos de productos
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public DataSet GetCodAlt(string producto, string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_Pcodigosalternos", db);
                da.SelectCommand.Parameters.AddWithValue("@producto", producto);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_Pcodigosalternos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetallePed(string pedido)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetDetallePed", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetDetallePed");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CierreRecepcion(string orden, string producto, string usuario, string empresa, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PCierreRecepcion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orden", orden);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@usuario1", usuario);
                cmd.Parameters.AddWithValue("@empresa1", empresa);
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

        public DataSet GetWMSvsGP(int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptWMSvsGP", db);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptWMSvsGP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPedpenxFact(int anio, int mes)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptPedpenxFact", db);
                da.SelectCommand.Parameters.AddWithValue("@anio", anio);
                da.SelectCommand.Parameters.AddWithValue("@mes", mes);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_rptPedpenxFact");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetWMSvsGPIAV()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PgeneraWMSvsGP", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PgeneraWMSvsGP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMotivosReversa(int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_Pmotreversa", db);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_Pmotreversa");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCCReportes(string filtro, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PREPORTES", db);
                da.SelectCommand.Parameters.AddWithValue("@FILTRO", filtro);
                da.SelectCommand.Parameters.AddWithValue("@OP", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PREPORTES");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptReversas(string dato1, string dato2, int op, string pedido)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptReversas", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_rptReversas");
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

        public DataSet GetrptAnulaciones(string dato1, string dato2, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_rptAnulaciones", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_rptAnulaciones");
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

        /// Obtener datos de pedido RECIBIMIENTO LOGISTICA
        public DataSet GetPedidoLogistica(string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetpedido", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", dato);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetpedido");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetallePedidoLogistica(string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PGetTrans", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", 2);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetTrans");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public string InsRutaSugerida(string empresa, string usuario, string consolidado)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PgetRutaSugerida";
                cmd.CommandTimeout = 180;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@consolidado", consolidado);
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

        public string InsimpNE(string pedidos, string usuario, string empresa)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PInsimpNE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedidos", pedidos);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@empresa", empresa);
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

        public string InsCodAlt(AE_GA_WMS_Talterno ae_ga_wms_talterno)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PInsalternos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigoproducto", ae_ga_wms_talterno.codigoproducto);
                cmd.Parameters.AddWithValue("@codigoalterno", ae_ga_wms_talterno.codigoalterno);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_wms_talterno.usuario);
                cmd.Parameters.AddWithValue("@empresa", ae_ga_wms_talterno.empresa);
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

        public string InsGA_WMS_Tconsolidado(int id, AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario, string empresa)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Pinsconsolidados";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pedido", ae_ga_wms_tpedusuario.pedido);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_wms_tpedusuario.id_usuario);
                cmd.Parameters.AddWithValue("@empresa", empresa);
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

        public string InsGA_WMS_TPedusuario(AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PInspedusu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", ae_ga_wms_tpedusuario.pedido);
                cmd.Parameters.AddWithValue("@id_usuario", ae_ga_wms_tpedusuario.id_usuario);
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

        public string InsGA_WMS_Treversas(AE_GA_WMS_Treversas ae_ga_wms_treversas, string opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Pinsreversas";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@proceso", ae_ga_wms_treversas.proceso);
                cmd.Parameters.AddWithValue("@numconsolidado", ae_ga_wms_treversas.numconsolidado);
                cmd.Parameters.AddWithValue("@pedido", ae_ga_wms_treversas.pedido);
                cmd.Parameters.AddWithValue("@producto", ae_ga_wms_treversas.producto);
                cmd.Parameters.AddWithValue("@motivo", ae_ga_wms_treversas.motivo);
                cmd.Parameters.AddWithValue("@coor_destino", ae_ga_wms_treversas.coor_destino);
                cmd.Parameters.AddWithValue("@coor_sugerida", ae_ga_wms_treversas.coor_sugerida);
                cmd.Parameters.AddWithValue("@can_procesada", ae_ga_wms_treversas.can_procesada);
                cmd.Parameters.AddWithValue("@can_reversar", ae_ga_wms_treversas.can_reversar);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_wms_treversas.usuario);
                cmd.Parameters.AddWithValue("@linea", ae_ga_wms_treversas.linea);
                cmd.Parameters.AddWithValue("@opcion", opcion);

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

        public string InsGA_WMS_PReversaRecepcion(AE_GA_WMS_Treversas ae_ga_wms_treversas, string empresa)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PReversaRecepcion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numerodocumento", ae_ga_wms_treversas.pedido);
                cmd.Parameters.AddWithValue("@codigoproducto", ae_ga_wms_treversas.producto);
                cmd.Parameters.AddWithValue("@motivo", ae_ga_wms_treversas.motivo);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_wms_treversas.usuario);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;

                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string GetValidaProd(string alterno, string producto, string empresa, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PGetvalidaprod";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@codalterno", alterno);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string UpdatePedidoConsol(string numconsolidado, string pedido)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Pactconsolidados";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numconsolidado", numconsolidado);
                cmd.Parameters.AddWithValue("@pedido", pedido);
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

        public string InsConteoCiclico(int op, string tipo, string documento, int cantidad, string codigoproducto, string descripcion,
            string observacion, string origen, string empresa, int idcc, string usuario, string usuarioasigna)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PInsConteoCiclico";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@codigoproducto", codigoproducto);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@origen", origen);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@idMConteoCiclico", idcc);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@usuarioasigna", usuarioasigna);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string InsConteoCiclicoCuarentena(int op, string tipo, string documento, int cantidad, string codigoproducto, string descripcion,
            string observacion, string origen, string empresa, int idcc, string usuario, string usuarioasigna)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PInsConteoCiclicoCuarentena";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@codigoproducto", codigoproducto);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@origen", origen);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@idMConteoCiclico", idcc);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@usuarioasigna", usuarioasigna);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string ExportarGP(int maestro)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PProcesaCC";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maestro", maestro);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string ExportarGPCuarentena(int maestro)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PProcesaCCcuarentena";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maestro", maestro);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;
                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }
        //INGRESAR RECIBIMIENTO LOGISTICA
        public string InsRecibimientoLogistica(string pedido, string usuario)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PreciboLogistica";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@empresa", "GPIAV");
                cmd.Connection = db;

                try
                {
                    db.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }
        #endregion

        #region Update
        public string UpTlogistica(AE_GA_WMS_Tlogistica ae_ga_wms_tlogistica)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PCerrarlogistica";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", ae_ga_wms_tlogistica.pedido);
                cmd.Parameters.AddWithValue("@bulto", ae_ga_wms_tlogistica.bulto);
                cmd.Parameters.AddWithValue("@transportista", ae_ga_wms_tlogistica.transportista);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_wms_tlogistica.usuario);
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

        public string UpCerrarProd(string numconsolidado, string pedido, string producto, string coordenada, string observacion, string usuarioanula)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PCerrarpickingprod";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numconsolidado", numconsolidado);
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@coor_origen", coordenada);
                cmd.Parameters.AddWithValue("@observacion", observacion);
                cmd.Parameters.AddWithValue("@usuarioanula", usuarioanula);
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

        public string DarCoordenada(string producto, string empresa, string consolidado)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PrutaIndividual";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@consolidado", consolidado);
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

        public string AnulaPedido(string pedido, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Panulapedido";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string ReimpNE(string pedido)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PreimpNE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
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

        public string Claves(string modulo, string clave)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PGetClaves";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@modulo", modulo);
                cmd.Parameters.AddWithValue("@clave", clave);
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

        public DataSet GetEstadoPedido(string dato1, string dato2, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptEstadoPedidos", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptEstadoPedidos");
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

        public DataSet GetEstadoPedidoFecha(string dato1, string dato2, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptEstadoPedidosFecha", db);
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptEstadoPedidos");
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

        public DataSet GetKardex(string dato1, string dato2, string dato3, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptKardex", db);
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@dato3", dato3);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptKardex");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUbicaProducto(string dato, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PUbicaProducto", db);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PUbicaProducto");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUbicaProductoCuarentena(string dato, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PUbicaProductoCuarentena", db);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PUbicaProductoCuarentena");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptResumenDiario(string fdesde, string fhasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptResumenDiario", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@fdesde", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", fhasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptResumenDiario");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetrptResumenDiarioXProceso(string fdesde, string fhasta, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptResumenDiarioXProceso", db);
                da.SelectCommand.Parameters.AddWithValue("@fdesde", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", fhasta);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptResumenDiarioXProceso");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getRacksxArea(int idmaestrocc, string area, string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetRacksxArea", db);
                da.SelectCommand.Parameters.AddWithValue("@idmaestrocc", idmaestrocc);
                da.SelectCommand.Parameters.AddWithValue("@area", area);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PGetRacksxArea");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsAsigCCMaestro(AE_GA_CC_TMaestroCC ae_ga_cc_tmaestrocc, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PInsAsigCCMaestro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", ae_ga_cc_tmaestrocc.usuario);
                cmd.Parameters.AddWithValue("@empresa", ae_ga_cc_tmaestrocc.empresa);
                cmd.Parameters.AddWithValue("@observacion", ae_ga_cc_tmaestrocc.observacion);
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
                    return ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public string InsAsigCCDetalle(AE_GA_CC_TDetalleCC ae_ga_cc_tdetallecc, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PInsAsigCCDetalle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idmaestrocc", ae_ga_cc_tdetallecc.idMaestroCC);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_cc_tdetallecc.usuario);
                cmd.Parameters.AddWithValue("@area", ae_ga_cc_tdetallecc.area);
                cmd.Parameters.AddWithValue("@rack", ae_ga_cc_tdetallecc.rack);
                cmd.Parameters.AddWithValue("@percha", ae_ga_cc_tdetallecc.percha);
                cmd.Parameters.AddWithValue("@empresa", ae_ga_cc_tdetallecc.empresa);
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

        public DataSet GetDetConteo(string dato, string idmaestro, string empresa, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetDetalleConteo", db);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@idmaestrocc", idmaestro);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PGetConsolidados");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDifeConteo(int idmaestro, string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetDifeConteo", db);
                da.SelectCommand.Parameters.AddWithValue("@idmaestrocc", idmaestro);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PGetDifeConteo");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpVaciarCoordenada(string coordenada, int idmaestro, string producto, string empresa, int opcion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PVaciarCoordenada";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coordenada", coordenada);
                cmd.Parameters.AddWithValue("@idmaestrocc", idmaestro);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@opcion", opcion);
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

        public string InsGA_CC_PInsReconteoCab(AE_GA_CC_TReconteo ae_ga_cc_treconteo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PInsReconteoCab";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", ae_ga_cc_treconteo.producto);
                cmd.Parameters.AddWithValue("@cantconteo", ae_ga_cc_treconteo.cantconteo);
                cmd.Parameters.AddWithValue("@idmaestrocc", ae_ga_cc_treconteo.idMaestroCC);
                cmd.Parameters.AddWithValue("@usuario", ae_ga_cc_treconteo.usuario);
                cmd.Parameters.AddWithValue("@empresa", ae_ga_cc_treconteo.empresa);
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

        public string UpCantCoor(int dato, string coordenada, string producto, string usuario, string empresa, int idmaestro)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PActCanCoor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato", dato);
                cmd.Parameters.AddWithValue("@coordenada", coordenada);
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@idmaestrocc", idmaestro);
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

        public string AbrirCoor(string coordenada, string empresa, int idmaestro)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PAbrirCoor";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@coordenada", coordenada);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@idmaestrocc", idmaestro);
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

        public DataSet GetAvanceCCxUsuario(string filtro, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PREPORTES", db);
                da.SelectCommand.Parameters.AddWithValue("@FILTRO", filtro);
                da.SelectCommand.Parameters.AddWithValue("@OP", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PREPORTES");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRepConteo(string filtro, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PREPORTES", db);
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PREPORTES");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateTraspasos(string traspaso)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PUpdateTraspasos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TRASPASO", traspaso);
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

        public string UpdateTraspasosOUTLET(string traspaso)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PUpdateTraspasosOUTLET";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TRASPASO", traspaso);
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

        public string ValidaTraspasos(string traspaso)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PValidaTraspaso";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TRASPASO", traspaso);
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

        public string ArreglaNE(string pedido)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_ParreglarNE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ped", pedido);
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

        public string ForzarPed(string pedido)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PforzarPed";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ped", pedido);
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

        public string SubirPVC(string factura)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PsubirPVCtemp";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fac", factura);
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

        public string SubirNC(string devolucion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PsubirNCWMS";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fac", devolucion);
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

        public string SubirRecepcionOC(string orden)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PsubirRecepcionOC";
                cmd.CommandTimeout = 360;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orden", orden);
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

        public string InsObsCierre(string observacion)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Pinsproductoscerrados";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@observacion", observacion);
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

        public string InsItemRecepcion(string numerodocumento, string codigoproducto, int cantidad)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "ga_wms_pInsItemRecepcion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numerodocumento", numerodocumento);
                cmd.Parameters.AddWithValue("@codigoproducto", codigoproducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.Add("@msg", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
                cmd.Connection = db;

                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    string msg = Convert.ToString(cmd.Parameters["@msg"].Value);
                    return msg;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public DataSet GetCCproductofamilia(int op, string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_PGetCCproductofamilia", db);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_PGetCCproductofamilia");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUsuAsig(string dato, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_CC_Pasignados", db);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_CC_Pasignados");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNoStock(string dato1, string dato2, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptNOSTOCK", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptNOSTOCK");
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

        public DataSet GetComprometidos(string dato1, string dato2, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptComprometidos", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptComprometidos");
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

        public string ActVoids(int id, string codigo_void, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PActVoids";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@codigo_void", codigo_void);
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Connection = db;
                try
                {
                    db.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception)
                {
                    return "ERROR";
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public DataSet GetConteoDetallado(int op, string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptConteoCC", db);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptConteoCC");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetStock64()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptStock64", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptStpck64");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTiemposWMS(string fdesde, string fhasta, string prioridad, string ciudad, int items)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_tiempos_wms", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@fecha_ini", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fecha_fin", fhasta);
                da.SelectCommand.Parameters.AddWithValue("@prioridad", prioridad);
                da.SelectCommand.Parameters.AddWithValue("@ciudad", ciudad);
                da.SelectCommand.Parameters.AddWithValue("@items", items);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_tiempos_wms");
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

        public string InsArreglarArmado(string pedido, string codigoproducto, int cantidad)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_Parreglarempaque";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@producto", codigoproducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Connection = db;

                try
                {
                    db.Open();
                    string idFromString = cmd.ExecuteScalar().ToString();
                    return idFromString;
                }
                catch (Exception ex)
                {
                    return "ERROR" + ex.Message;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public DataSet GetRPT_PTiemposWMS(string fdesde, string fhasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_RPT_PTiemposWMS", db);
                da.SelectCommand.Parameters.AddWithValue("@fecha_ini", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fecha_FIN", fhasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_RPT_PTiemposWMS");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRPT_PTiemposWMSresumen(string fdesde, string fhasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_RPT_PTiemposWMSresumen", db);
                da.SelectCommand.Parameters.AddWithValue("@fecha_ini", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fecha_fin", fhasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_RPT_PTiemposWMSresumen");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AsigFamilia(string producto, string familia, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_CC_PAsigFamilia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", producto);
                cmd.Parameters.AddWithValue("@familia", familia);
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

        public string CerrarOC(string oc)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PcerrarOrden";
                cmd.CommandTimeout = 180;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numerodocumento", oc);
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

        public DataSet GetPendxEmpacar(string filtro, string area, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PPedEncProceso", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.SelectCommand.Parameters.AddWithValue("@area", area);
                da.SelectCommand.Parameters.AddWithValue("@op", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PPedEncProceso");
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

        public DataSet GetRecepcionNE(string desde, string hasta, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_REC_PrptRecepcionNE", db);
                da.SelectCommand.CommandTimeout = 360;
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@op", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_REC_PrptRecepcionNE");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ARTICULOS SIN STOCK DE IAVEC WMS CAL
        public DataSet Getstockiavec(string pedido)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_Pstockiavec", db);
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_Pstockiavec");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// OBTENER EL DETALLE DE LOS BULTOS POR PEDIDO PARA EL MODULO CONSOLIDADO DE BULTO
        /// </summary>
        public DataSet getBultosxPedido(string pedido, int idbulto, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PconsBultosDet", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.Parameters.AddWithValue("@idbulto", idbulto);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PconsBultosDet");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// CREAR CONSOLIDADOS DE BULTOS
        /// </summary>
        public string insConsolidadosBultos(string pedido, int idbulto, string usuario, int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_WMS_PconsBultos";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido", pedido);
                cmd.Parameters.AddWithValue("@idbulto", idbulto);
                cmd.Parameters.AddWithValue("@usuario", usuario);
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

        /// <summary>
        /// IMPRIMIR NOTA DE ENTREGA MODULO CONSOLIDADO DE BULTOS
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public DataSet GetPackingListConsBultos(string pedido)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PImpresionNEconsBultos", db);
                da.SelectCommand.CommandTimeout = 240;
                da.SelectCommand.Parameters.AddWithValue("@pedido", pedido);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PImpresionNEconsBultos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete

        #endregion
    }
}
