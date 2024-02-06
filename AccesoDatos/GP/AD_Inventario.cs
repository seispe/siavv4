using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.GP
{
    public class AD_Inventario
    {
        #region Variables Globales
        private SqlConnection db = null;
        private SqlConnection dbdynamics = null;
        private SqlConnection dbdynamicslocal = null;
        private SqlConnection dbdynamicscao = null;
        #endregion

        #region Constructor
        public AD_Inventario(string empresa)
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["con" + empresa].ConnectionString);
            dbdynamics = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICS"].ConnectionString);
            dbdynamicslocal = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSlocal"].ConnectionString);
            dbdynamicscao = new SqlConnection(ConfigurationManager.ConnectionStrings["conDYNAMICSCAO"].ConnectionString);
        }
        #endregion

        #region Select
        public DataSet GetInventarioFecha(string empresa, string fecha)
        {
            try
            {
                if (empresa == "GPIAV" || empresa == "GPALL" || empresa == "GPVEC" || empresa == "GPACC")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_INV_Prpt_inventariofecha", dbdynamics);
                    da.SelectCommand.CommandTimeout = 180;
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecha).ToString("yyyy-MM-dd"));
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_INV_InventarioFecha");
                    return ds;
                }
                else if (empresa == "GPCAO" || empresa == "GPCSA" || empresa == "GPCTO" || empresa == "GPCSG" || empresa == "GPCPI" || empresa == "GPCTA" || empresa == "GPCUC" || empresa == "GPGRP" || empresa == "GPTET" || empresa == "GPGRO" || empresa == "GPTEX" || empresa == "GPCOP")
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_INV_Prpt_inventariofecha", dbdynamicscao);
                    da.SelectCommand.CommandTimeout = 180;
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_INV_InventarioFecha");
                    return ds;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("GA_INV_Prpt_inventariofecha", dbdynamicslocal);
                    da.SelectCommand.CommandTimeout = 180;
                    da.SelectCommand.Parameters.AddWithValue("@empresa", empresa);
                    da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "GA_INV_InventarioFecha");
                    return ds;
                }
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
