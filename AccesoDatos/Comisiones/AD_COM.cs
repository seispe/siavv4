/****************************************************************
-- Titulo:  Acceso Datos Comisiones
-- Author:  Gabriel Reyes
-- Fecha:   26/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoEntidades.Comisiones;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Comisiones
{
    public class AD_COM
    {
        #region Variables Globales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_COM(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con"+empresa].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetConfigComi()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_Pgetconfig", db);
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

        public DataSet GetConfigVendedor(string vendedor)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_Pgetconfigven", db);
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

        public DataSet GetComision(string vendedor,string mes, string año,string tipo)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_PgetComision", db);
                da.SelectCommand.Parameters.AddWithValue("@vendedor", vendedor);
                da.SelectCommand.Parameters.AddWithValue("@mes", mes);
                da.SelectCommand.Parameters.AddWithValue("@año", año);
                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
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

        public DataSet GetVendedores()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_COM_PgetVendedores", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_DEV_Tvendedores");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getExisteRegistro(string vendedor,string mes,string año)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_COM_PgetExisteConfig", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vendedor", vendedor.Trim());
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@año", año);
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

        public string getExisteComision(string vendedor, string mes, string año)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_COM_PgetExisteComision", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vendedor", vendedor.Trim());
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@año", año);
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

        public string setComision(string vendedor, string mes, string año)
        {
            string resultado = "";
            using (SqlCommand cmd = new SqlCommand("GA_COM_PsetComision", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vendedor", vendedor.Trim());
                cmd.Parameters.AddWithValue("@mes", mes);
                cmd.Parameters.AddWithValue("@año", año);
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

        #region Insert
        public string putNuevoCalculo(AE_GA_COM_Tpagada_calc ae_ga_com_tpagada_calc)
        {
            using (SqlCommand cmd = new SqlCommand("GA_COM_Pputconfig", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVendedor", ae_ga_com_tpagada_calc.idVendedor);
                cmd.Parameters.AddWithValue("@mes", ae_ga_com_tpagada_calc.mes);
                cmd.Parameters.AddWithValue("@año", ae_ga_com_tpagada_calc.año);
                cmd.Parameters.AddWithValue("@cupo", ae_ga_com_tpagada_calc.cupo);
                cmd.Parameters.AddWithValue("@neto", ae_ga_com_tpagada_calc.neto);
                cmd.Parameters.AddWithValue("@porceAlcanzado", ae_ga_com_tpagada_calc.porceAlcanzado);
                cmd.Parameters.AddWithValue("@porceComi", ae_ga_com_tpagada_calc.porceComi);
                cmd.Parameters.AddWithValue("@porceComisionar", ae_ga_com_tpagada_calc.porceComisionar);
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

        public string editCalculo(AE_GA_COM_Tpagada_calc ae_ga_com_tpagada_calc)
        {
            using (SqlCommand cmd = new SqlCommand("GA_COM_Peditconfig", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idVendedor", ae_ga_com_tpagada_calc.idVendedor);
                cmd.Parameters.AddWithValue("@mes", ae_ga_com_tpagada_calc.mes);
                cmd.Parameters.AddWithValue("@año", ae_ga_com_tpagada_calc.año);
                cmd.Parameters.AddWithValue("@cupo", ae_ga_com_tpagada_calc.cupo);
                cmd.Parameters.AddWithValue("@neto", ae_ga_com_tpagada_calc.neto);
                cmd.Parameters.AddWithValue("@porceAlcanzado", ae_ga_com_tpagada_calc.porceAlcanzado);
                cmd.Parameters.AddWithValue("@porceComi", ae_ga_com_tpagada_calc.porceComi);
                cmd.Parameters.AddWithValue("@porceComisionar", ae_ga_com_tpagada_calc.porceComisionar);
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
        #endregion

        #region Update
        public void setComiConfig(string idconfig,string valor)
        {
            using (SqlCommand cmd = new SqlCommand("GA_COM_Psetconfig", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idconfig", idconfig);
                cmd.Parameters.AddWithValue("@valor", valor);
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
