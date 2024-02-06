using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.GP
{
    public class AD_Ventas
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbdynamics = null;
        private SqlConnection dbBI = null;
        private SqlConnection dbdynamicslocal = null;
        #endregion

        #region Constructor
        public AD_Ventas(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
            dbBI = new SqlConnection(ConfigurationManager.ConnectionStrings["conBI"].ConnectionString);
            dbdynamicslocal = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSlocal"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet Getventas_vendedorlinea(string empresa, string fecha1, string fecha2, string vendedor, string linea, int tipo)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SIAV_resumen_ventas_vendedor", dbBI);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fecha1", fecha1);
                da.SelectCommand.Parameters.AddWithValue("@fecha2", fecha2);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
                da.SelectCommand.Parameters.AddWithValue("@linea", linea);
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "SIAV_resumen_ventas_vendedor");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetLineas(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SIAV_lineas", dbBI);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "SIAV_lineas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_Ventas_vendedor_linea_mensual(string empresa, string fecha)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_SIAV_ventas_vendedor_linea", dbBI);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_SIAV_ventas_vendedor_linea");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetClientes_con_deuda(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_clientes_contado_con_deuda", db);
                //da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_clientes_contado_con_deuda");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetClientes_cupos(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_clientes_cupos", db);
                //da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "sp_clientes_cupos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPorDespachar(string empresa)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VEN_Ppordespachar", dbdynamics);
                da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VEN_Ppordespachar");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasxItems(string empresa, string fechaDesde, string fechaHasta)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPALL" || empresa == "GPVEC" || empresa == "GPACC")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_VEN_VtasxItems", dbdynamics);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaDesde", Convert.ToDateTime(fechaDesde).ToString("yyyy-MM-dd"));
                    da.SelectCommand.Parameters.AddWithValue("@fechaHasta", Convert.ToDateTime(fechaHasta).ToString("yyyy-MM-dd"));
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_VEN_VtasxItems");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_VEN_VtasxItems", dbdynamicslocal);
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                    da.SelectCommand.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_VEN_VtasxItems");
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasxLineas(string fdesde, string fhasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_reporte_venta_clientes_lineas", db);
                da.SelectCommand.CommandTimeout = 180;
                da.SelectCommand.Parameters.AddWithValue("@fecha_ini", fdesde);
                da.SelectCommand.Parameters.AddWithValue("@fecha_fin", fhasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VEN_VtasxItems");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVenSup(string dato1, string dato2, string dato3, int op, string dato4)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VEN_PgetVenSup", db);
                da.SelectCommand.Parameters.AddWithValue("@dato1", dato1);
                da.SelectCommand.Parameters.AddWithValue("@dato2", dato2);
                da.SelectCommand.Parameters.AddWithValue("@dato3", dato3);
                da.SelectCommand.Parameters.AddWithValue("@dato4", dato4);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VEN_PgetVenSup");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasxFecha(string desde, string hasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VTA_Prpt_vtasxfechas", db);
                da.SelectCommand.CommandTimeout = 1000;
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VTA_Prpt_vtasxfechas");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasxCliVen(string ruc, string desde, string hasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VTA_rptVtasCliVen", db);
                da.SelectCommand.CommandTimeout = 1000;
                da.SelectCommand.Parameters.AddWithValue("@ruc", ruc);
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VTA_rptVtasCliVen");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasCostoLogistico(string desde, string hasta, string bodega, string cliente)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VTA_rptCostoLogisticoTODO", db);
                da.SelectCommand.CommandTimeout = 1800;
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@bodega", bodega);
                da.SelectCommand.Parameters.AddWithValue("@cliente", cliente);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VTA_rptCostoLogistico");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetVtasCostoLogisticoPVG(string desde, string hasta)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_VTA_rptCostoLogisticoPVG", db);
                da.SelectCommand.CommandTimeout = 1800;
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_VTA_rptCostoLogisticoPVG");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert
        public string GetPerSup(string dato1, string dato2, string dato3, int op, string dato4)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "GA_VEN_PgetVenSup";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dato1", dato1);
                cmd.Parameters.AddWithValue("@dato2", dato2);
                cmd.Parameters.AddWithValue("@dato3", dato3);
                cmd.Parameters.AddWithValue("@dato4", dato4);
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
                    throw ex;
                }
                finally
                {
                    db.Close();
                }
            }
        }

        public DataSet GetRecepcionNE(string desde, string hasta, int op)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_REC_PrptRecepcionNE", db);
                da.SelectCommand.Parameters.AddWithValue("@fdesde", desde);
                da.SelectCommand.Parameters.AddWithValue("@fhasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@op", op);
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
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion
    }
}
