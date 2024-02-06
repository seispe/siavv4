using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.GP
{
    public class AD_Compras
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbdynamics = null;
        private SqlConnection dbdynamicslocal = null;
        private SqlConnection dbwms = null;
        #endregion

        #region Constructor
        public AD_Compras(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
            dbdynamicslocal = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSlocal"].ConnectionString);
            dbwms = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMSiav"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetCostosDescarga(string empresa, string fechaInicial, string fechaFinal)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPVEC" || empresa == "GPVEC" || empresa == "GPACC")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_COM_Prpt_costodescarga", dbdynamics);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaInicial", Convert.ToDateTime(fechaInicial).ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@fechaFinal", Convert.ToDateTime(fechaFinal).ToString("yyyy-MM-dd"));
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tcostodescarga");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_COM_Prpt_costodescarga", dbdynamicslocal);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaInicial", fechaInicial);
                    da.SelectCommand.Parameters.AddWithValue("@fechaFinal", fechaFinal);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_DEV_Tcostodescarga");
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRendimientos(string empresa, string fecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_Prpt_recibimientos", dbdynamics);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_COM_Trecibimientos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetListaPreciosNOAsociados(string empresa, string proveedor, string codigo, string descripcion, string marca)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_LTP_PgetListaprecios", db);
                da.SelectCommand.Parameters.AddWithValue("@proveedor", proveedor);
                da.SelectCommand.Parameters.AddWithValue("@codigo", codigo);
                da.SelectCommand.Parameters.AddWithValue("@descripcion", descripcion);
                da.SelectCommand.Parameters.AddWithValue("@marca", marca);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tcostodescarga");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRecibimientoWMS(string empresa, string ordencompra)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("IAV_COM_Prpt_recibimientoWMS", dbwms);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@ordencompra", ordencompra);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tcostodescarga");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetOrdenCompraWMSGP(string empresa, string ordencompra)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("IAV_COM_PordenWMSGP", dbdynamics);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@ordencompra", ordencompra);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tcostodescarga");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetProveedores(string dato, int opcion)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_PRV_Pgetproveedores", db);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.Parameters.AddWithValue("@opcion", opcion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_PRV_Pgetproveedores");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRotacion(int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_Pgetrotacion", db);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_COM_Pgetrotacion");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPedidosCao()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_pedidosSIAV", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_COM_Pgetrotacion");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetalleFacturaDtos(int op, string dato)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_dtosMercaderia", db);
                da.SelectCommand.Parameters.AddWithValue("@op",op);
                da.SelectCommand.Parameters.AddWithValue("@dato", dato);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_dtosMercaderia");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public string InsDtosMercaderia(string secuencial, string ruc, string cliente, string factura, DateTime ffactura, string item, string descripcion, int cantingreso, 
                                         decimal porcentajeingreso, int cantfactura, decimal precioUnit, decimal dtoItem, decimal precioTotal, string codvend)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_dtosMercaderiaIns";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@secuencial", secuencial);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@factura", factura);
                cmd.Parameters.AddWithValue("@ffactura", ffactura);
                cmd.Parameters.AddWithValue("@item", item);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cantingreso", cantingreso);
                cmd.Parameters.AddWithValue("@porcentajeingreso", porcentajeingreso);
                cmd.Parameters.AddWithValue("@cantfactura", cantfactura);
                cmd.Parameters.AddWithValue("@precioUnit", precioUnit);
                cmd.Parameters.AddWithValue("@dtoItem", dtoItem);
                cmd.Parameters.AddWithValue("@precioTotal", precioTotal);
                cmd.Parameters.AddWithValue("@codvend", codvend);
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

        public string InsDtosMercaderiaCAL(string secuencial,string bodega, string ruc, string cliente, string factura, DateTime ffactura, string item, string descripcion, int cantingreso,
                                        decimal porcentajeingreso, int cantfactura, decimal precioUnit, decimal dtoItem, decimal precioTotal, string codvend)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_dtosMercaderiaIns";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@secuencial", secuencial);
                cmd.Parameters.AddWithValue("@bodega", bodega);
                cmd.Parameters.AddWithValue("@ruc", ruc);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@factura", factura);
                cmd.Parameters.AddWithValue("@ffactura", ffactura);
                cmd.Parameters.AddWithValue("@item", item);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@cantingreso", cantingreso);
                cmd.Parameters.AddWithValue("@porcentajeingreso", porcentajeingreso);
                cmd.Parameters.AddWithValue("@cantfactura", cantfactura);
                cmd.Parameters.AddWithValue("@precioUnit", precioUnit);
                cmd.Parameters.AddWithValue("@dtoItem", dtoItem);
                cmd.Parameters.AddWithValue("@precioTotal", precioTotal);
                cmd.Parameters.AddWithValue("@codvend", codvend);
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

        public string SecuencialDtoMercaderia(int op)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_dtosMercaderia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@op", op);
                cmd.Parameters.AddWithValue("@dato", "");
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

        public string CorreoDtoMercaderia(string secuencial)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "sp_dtosMercaderiaCorreo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@secuencial", secuencial);
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
        #endregion

        #region Delete
        #endregion
    }
}
