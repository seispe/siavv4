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
            dbwms = new SqlConnection(ConfigurationManager.ConnectionStrings["conWMS"].ConnectionString);
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
        #endregion

        #region Insert
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
