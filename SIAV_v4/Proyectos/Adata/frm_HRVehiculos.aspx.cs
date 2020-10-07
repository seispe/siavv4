using AccesoNegocios.Adata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIAV_v4.Proyectos.Adata
{
    public partial class frm_HRVehiculos : System.Web.UI.Page
    {

        #region VariablesGlobales
        AN_Adata an_adata = new AN_Adata();
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.btnAceptar.Attributes.Add("OnClick", "javascript:return fnAceptar();");
        }
        
        #endregion

        #region Funciones
        [WebMethod]
        public static string SaveData(string[][] array)
        {
            //string result = string.Empty;
            //try
            //{
            //    //One thing to keep in mind Column Names of DataTable must be same as Table-Valued Type parameters//
            //    //Please refer commented queries in the bottom.Just execute all of them in the Database sequentially//
            //    //Then change Webconfig connectionstring according to you//

            //    DataTable dt = new DataTable();
            //    dt.Columns.Add("FirstName");
            //    dt.Columns.Add("LastName");
            //    dt.Columns.Add("Age");
            //    dt.Columns.Add("Address");
            //    dt.Columns.Add("comments");
            //    dt.Columns.Add("Course");
            //    dt.Columns.Add("Eligible");
            //    dt.Columns.Add("HFID");

            //    foreach (var arr in array)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["FirstName"] = arr[0];
            //        dr["LastName"] = arr[1];
            //        dr["Age"] = arr[2];
            //        dr["Address"] = arr[3];
            //        dr["comments"] = arr[4];
            //        dr["Course"] = arr[5];
            //        dr["Eligible"] = arr[6];
            //        dr["HFId"] = arr[7];
            //        dt.Rows.Add(dr);
            //    }

            //    SqlConnection cnn = new SqlConnection();
            //    cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conSI_CAO"].ToString();
            //    cnn.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "USPSaveDetails";
            //    cmd.Connection = cnn;
            //    cmd.Parameters.Add("@TableType", SqlDbType.Structured).SqlValue = dt;

            //    result = cmd.ExecuteNonQuery().ToString();
            //}
            //catch (Exception ex)
            //{
            //    result = ex.Message;
            //}
            //return result;
            string result = string.Empty;
            try
            {
                //One thing to keep in mind Column Names of DataTable must be same as Table-Valued Type parameters//
                //Please refer commented queries in the bottom.Just execute all of them in the Database sequentially//
                //Then change Webconfig connectionstring according to you//

                DataTable dt = new DataTable();
                dt.Columns.Add("nombre");
                dt.Columns.Add("email");
                dt.Columns.Add("notas");
                dt.Columns.Add("opcion");
                dt.Columns.Add("comentarios");

                foreach (var arr in array)
                {
                    DataRow dr = dt.NewRow();
                    dr["nombre"] = arr[0];
                    dr["email"] = arr[1];
                    dr["notas"] = arr[2];
                    dr["opcion"] = arr[3];
                    dr["comentarios"] = arr[4];
                    dt.Rows.Add(dr);
                }

                SqlConnection cnn = new SqlConnection();
                cnn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conSI_CAO"].ToString();
                cnn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_insertPruebas";
                cmd.Connection = cnn;
                cmd.Parameters.Add("@TableType", SqlDbType.Structured).SqlValue = dt;

                result = cmd.ExecuteNonQuery().ToString();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        
        #endregion




    }
}