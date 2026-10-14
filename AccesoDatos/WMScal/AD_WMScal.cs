using AccesoEntidades.WMScal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.WMScal
{
    public class AD_WMScal
    {
        #region VariablesGlobales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_WMScal()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMScal"].ConnectionString);
        }
        #endregion

        #region Select
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

        public DataSet GetPedsinStock()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_Ppedsinstock", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_Ppedsinstock");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConteoDetallado(int op, string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptConteoCC", db);
                da.SelectCommand.CommandTimeout = 180;
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
        #endregion

        #region Insert
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

        public DataSet GetConsoxUsu(string dato1, string dato2,string dato3, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_WMS_PrptConsxUsuVJ", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@dato3", dato3);
                da.SelectCommand.Parameters.AddWithValue("@op", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                db.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_WMS_PrptConsxUsuVJ");
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

        #region Update

        #endregion

        #region Delete

        #endregion
    }
}
