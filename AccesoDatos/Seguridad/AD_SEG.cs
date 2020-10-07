/****************************************************************
-- Titulo:  Acceso Datos a Seguridad 
-- Author:  Gabriel Reyes
-- Fecha:   26/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoEntidades.Seguridad;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Seguridad
{
    public class AD_SEG
    {
        #region Variables Globales
        private SqlConnection db = null;
        #endregion

        #region Constructor
        public AD_SEG()
        {
            db = new SqlConnection(ConfigurationManager.ConnectionStrings["conSIAV"].ConnectionString);
        }
        #endregion

        #region Select
        /// <summary>
        /// Obtener los padres del menu
        /// </summary>
        /// <param name="empresa">Numero de Empresa</param>
        /// <param name="usuario">Nombre de Usuario</param>
        /// <returns></returns>
        public DataTable getPadresMenu(string empresa, string usuario)
        {
            string procedure = "GA_SEG_Ppadremenu";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@empresa", empresa);            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                db.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                da.Dispose();
                ds.Dispose();
                dt.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// Obtener los hijos del menu segun el padre
        /// </summary>
        /// <param name="padre">Numero de Codigo de Padre</param>
        /// <param name="empresa">Numero de Empresa</param>
        /// <param name="usuario">Nombre de Usuario</param>
        /// <param name="hijo">Numero de Nivel 2 o 3</param>
        /// <returns></returns>
        public DataTable gethijosMenu(string padre, string empresa, string usuario, string hijo) 
        {
            string procedure = "GA_SEG_Phijomenu";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@padre", padre);
            cmd.Parameters.AddWithValue("@hijo", hijo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                db.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                da.Dispose();
                ds.Dispose();
                dt.Dispose();
            }
            return dt;
        }

        public DataTable getnietoMenu(string padre, string empresa, string usuario, string hijo)
        {
            string procedure = "GA_SEG_Phijonieto";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@empresa", empresa);
            cmd.Parameters.AddWithValue("@padre", padre);
            cmd.Parameters.AddWithValue("@hijo", hijo);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                db.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                da.Dispose();
                ds.Dispose();
                dt.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// Obtejer Acronido de Empresas
        /// </summary>
        /// <param name="empresa">Numero de Empresa</param>
        /// <returns></returns>
        public string getacronimoEmpresas(string empresa)
        {
            try
            {
                string procedure = "GA_SEG_Pacronimoemp";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getconvendedor(string usuario)
        {
            try
            {
                string procedure = "GA_SEG_Pcodvendedor";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getusuariogp(string usuario)
        {
            try
            {
                string procedure = "GA_SEG_Pgetusuariogp";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener la base de la empresa
        /// </summary>
        /// <param name="empresa">Numero de Empresa</param>
        /// <returns></returns>
        public string getbaseEmpresas(string empresa)
        {
            try
            {
                string procedure = "GA_SEG_Pbaseemp";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtejer nombres de Empresas
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public DataSet getnombreEmpresas()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_PnombreempTotal", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_SEG_Pnombreemp");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtener empresa a la que tiene acceso el usuario que intenta logearse
        /// </summary>
        /// <param name="cod_empresa">Numero de Empresa</param>
        /// <param name="usuario">Numero de Empresa</param>
        /// <returns></returns>
        public string getusuarioEmpresa(string usuario, string cod_emp)
        {
            try
            {
                string procedure = "GA_SEG_Pusuarioemp";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@cod_emp", cod_emp);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConfigNivel1()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_PgetConfigNivel1", db);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_SEG_Tnivel1");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConfigNivel2(string buscar)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_PgetConfigNivel2", db);
                da.SelectCommand.Parameters.AddWithValue("@buscar", buscar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_SEG_Tnivel2");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUsuarioVentana(string buscar)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_PgetUsuarioVentana", db);
                da.SelectCommand.Parameters.AddWithValue("@buscar", buscar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_SEG_Tpermisos");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConfigNivel3(string buscar)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("GA_SEG_PgetConfigNivel3", db);
                da.SelectCommand.Parameters.AddWithValue("@buscar", buscar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "GA_SEG_Tnivel3");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetNumero()
        {
            int numero = 0;
            try
            {
                string sql = "select MAX(id_menu_opcion) from GA_SEG_TMenu";
                SqlCommand cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.Text;
                db.Open();
                numero = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                return numero;
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
        public DataSet GetUsuarioEmpresa(string usuario)
        {
            try
            {
                string select = "select cod_emp,cod_usu from GA_SEG_Tusuempresa where cod_usu = '" + usuario + "'";
                SqlDataAdapter da = new SqlDataAdapter(select, db);
                DataSet ds = new DataSet();
                da.Fill(ds, "SEG_UsuarioEmpresa");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmpleados()
        {
            try
            {
                string select = "select empleado from ga_seg_tEmpleados";
                SqlDataAdapter da = new SqlDataAdapter(select, db);
                DataSet ds = new DataSet();
                da.Fill(ds, "seg_Empleados");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmpresas()
        {
            try
            {
                string select = "select cod_emp, empresa from ga_seg_tempresa";
                SqlDataAdapter da = new SqlDataAdapter(select, db);
                DataSet ds = new DataSet();
                da.Fill(ds, "seg_empresa");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEmpresas(string usuario)
        {
            try
            {
                string select = "select cod_emp,empresa from ga_SEG_tEmpresa where cod_emp IN (select cod_emp from ga_seg_tusuempresa where cod_usu = '" + usuario + "') ";
                SqlDataAdapter da = new SqlDataAdapter(select, db);
                DataSet ds = new DataSet();
                da.Fill(ds, "seg_empresa");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable nivel1(string empresa)
        {
            string select = "SELECT id_menu_opcion, descripcion, id_padre_menu_opcion, url,nivel,hijos,icono FROM ga_SEG_tMenu where nivel = '1' and id_menu_opcion in (select cod_men from GA_SEG_Tempremenu where cod_emp = " + empresa + " )and id_menu_opcion NOT IN (1,11) order by id_padre_menu_opcion";
            SqlCommand scSqlCommand = new SqlCommand(select, db);
            SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
            DataSet dsDataSet = new DataSet();
            DataTable dtDataTable = null;
            try
            {
                db.Open();
                sdaSqlDataAdapter.Fill(dsDataSet);
                dtDataTable = dsDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                sdaSqlDataAdapter.Dispose();
                dsDataSet.Dispose();
                dtDataTable.Dispose();
            }
            return dtDataTable;
        }

        public DataTable nivel2(string padre, string empresa)
        {
            string select = "SELECT id_menu_opcion, descripcion, id_padre_menu_opcion, url,nivel,hijos,icono FROM ga_SEG_tMenu where nivel = '2' and id_padre_menu_opcion = '" + padre + "' and id_menu_opcion in (select cod_men from GA_SEG_Tempremenu where cod_emp = " + empresa + " ) order by id_padre_menu_opcion";
            SqlCommand scSqlCommand = new SqlCommand(select, db);
            SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
            DataSet dsDataSet = new DataSet();
            DataTable dtDataTable = null;
            try
            {
                db.Open();
                sdaSqlDataAdapter.Fill(dsDataSet);
                dtDataTable = dsDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                sdaSqlDataAdapter.Dispose();
                dsDataSet.Dispose();
                dtDataTable.Dispose();
            }
            return dtDataTable;
        }

        public DataTable nivel3(string padre, string empresa)
        {
            string select = "SELECT id_menu_opcion, descripcion, id_padre_menu_opcion, url,nivel,hijos,icono FROM ga_SEG_tMenu where nivel = '3' and id_padre_menu_opcion = '" + padre + "' and id_menu_opcion in (select cod_men from GA_SEG_Tempremenu where cod_emp = " + empresa + " ) order by id_padre_menu_opcion";
            SqlCommand scSqlCommand = new SqlCommand(select, db);
            SqlDataAdapter sdaSqlDataAdapter = new SqlDataAdapter(scSqlCommand);
            DataSet dsDataSet = new DataSet();
            DataTable dtDataTable = null;
            try
            {
                db.Open();
                sdaSqlDataAdapter.Fill(dsDataSet);
                dtDataTable = dsDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                sdaSqlDataAdapter.Dispose();
                dsDataSet.Dispose();
                dtDataTable.Dispose();
            }
            return dtDataTable;
        }

        public DataSet GetUsuarioVentana(string usuario, string empresa, string modulo)
        {
            try
            {
                string select = "select cod_ven,cod_usu from GA_SEG_Tusuventana where cod_usu = '" + usuario + "' and cod_emp = " + empresa + " and cod_mod =" + modulo;
                SqlDataAdapter da = new SqlDataAdapter(select, db);
                DataSet ds = new DataSet();
                da.Fill(ds, "SEG_UsuarioVentana");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string validarUsuarioVenta(string usuario, string empresa, string ventana)
        {
            try
            {
                string procedure = "GA_SEG_Pusuventana";
                SqlCommand cmd = new SqlCommand(procedure, db);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@ventana", ventana);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    db.Open();
                    procedure = cmd.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    db.Close();
                }
                return procedure;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAutLoginVentana(string usuario, string empresa)
        {
            string procedure = "GA_SEG_PgetAutLoginVentana";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@empresa", empresa);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                db.Open();
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.Close();
                da.Dispose();
                ds.Dispose();
                dt.Dispose();
            }
            return dt;
        }

        public string GetVentanaIcono(string buscar)
        {
            string select = "select icono from GA_SEG_Tventana where ventana = '" + buscar + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(select, db);
                db.Open();
                select = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                db.Close();
            }
            return select;
        }

        public string GetVentana(string buscar)
        {
            string select = "select nombre from GA_SEG_Tventana where ventana = '" + buscar + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(select, db);
                db.Open();
                select = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                return "";
            }
            finally
            {
                db.Close();
            }
            return select;
        }

        public string getPermisos(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            string procedure = "GA_SEG_Ppermisos";
            SqlCommand cmd = new SqlCommand(procedure, db);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@usuario", ae_ga_seg_tpermisos.usuario);
            cmd.Parameters.AddWithValue("@empresa", ae_ga_seg_tpermisos.empresa);
            cmd.Parameters.AddWithValue("@proyecto", ae_ga_seg_tpermisos.proyecto);
            cmd.Parameters.AddWithValue("@ventana", ae_ga_seg_tpermisos.ventana);
            cmd.Parameters.AddWithValue("@permiso", ae_ga_seg_tpermisos.permiso);
           
            try
            {
                db.Open();
                procedure = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.Close();
            }
            return procedure;
        }
        #endregion

        #region Insert
        public void InsertGlobal(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.Text;
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

        public void InsertNewPadre(AE_GA_SEG_TmenuNivel1 ae_seg_tmenunivel1)
        {
            try
            {
                ae_seg_tmenunivel1.id_menu_option = GetNumero().ToString();
                ae_seg_tmenunivel1.nivel = "1";
                string update = "INSERT INTO GA_SEG_TMENU(id_menu_opcion,descripcion,id_padre_menu_opcion,url,nivel,hijos,icono) " +
                                "VALUES (" + ae_seg_tmenunivel1.id_menu_option + ",'" + ae_seg_tmenunivel1.description + "'," + ae_seg_tmenunivel1.id_menu_option + ",'" + ae_seg_tmenunivel1.url + "','" + ae_seg_tmenunivel1.nivel + "','" + ae_seg_tmenunivel1.hijos + "','" + ae_seg_tmenunivel1.icono + "')";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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

        public void InsertUsuarioVentana(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            try
            {
                string update = "INSERT INTO GA_SEG_Tpermisos(usuario,empresa,proyecto,ventana,permiso,activo) " +
                                "VALUES ('" + ae_ga_seg_tpermisos.usuario + "','" + ae_ga_seg_tpermisos.empresa + "','" + ae_ga_seg_tpermisos.proyecto + "','" + ae_ga_seg_tpermisos.ventana + "','" + ae_ga_seg_tpermisos.permiso + "','" + ae_ga_seg_tpermisos.activo + "')";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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

        public void InsertNewHijo(AE_GA_SEG_TmenuNivel2 ae_seg_tmenunivel2)
        {
            try
            {
                ae_seg_tmenunivel2.id_menu_option = GetNumero().ToString();
                ae_seg_tmenunivel2.nivel = "2";
                string update = "INSERT INTO GA_SEG_TMENU(id_menu_opcion,descripcion,id_padre_menu_opcion,url,nivel,hijos,icono) " +
                                "VALUES (" + ae_seg_tmenunivel2.id_menu_option + ",'" + ae_seg_tmenunivel2.description + "'," + ae_seg_tmenunivel2.id_parent_menu_option + ",'" + ae_seg_tmenunivel2.url + "','" + ae_seg_tmenunivel2.nivel + "','" + ae_seg_tmenunivel2.hijos + "','" + ae_seg_tmenunivel2.icono + "')";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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

        public void InsertNewNieto(AE_GA_SEG_TmenuNivel3 ae_seg_tmenunivel3)
        {
            try
            {
                ae_seg_tmenunivel3.id_menu_option = GetNumero().ToString();
                ae_seg_tmenunivel3.nivel = "3";
                string update = "INSERT INTO GA_SEG_TMENU(id_menu_opcion,descripcion,id_padre_menu_opcion,url,nivel,hijos,icono) " +
                                "VALUES (" + ae_seg_tmenunivel3.id_menu_option + ",'" + ae_seg_tmenunivel3.description + "'," + ae_seg_tmenunivel3.id_parent_menu_option + ",'" + ae_seg_tmenunivel3.url + "','" + ae_seg_tmenunivel3.nivel + "','" + ae_seg_tmenunivel3.hijos + "','" + ae_seg_tmenunivel3.icono + "')";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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

        public void InsertEmpleado(AE_GA_SEG_Templeado ae_seg_Templeado)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SET_Pinsertempleado", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empleado", ae_seg_Templeado.empleado);
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

        public void InsertUsuarioEmpresa(AE_GA_SEG_Tusuempresa ad_UsuarioEmpresa)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SEG_Pinsertusuarioempresa", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", ad_UsuarioEmpresa.cod_emp);
                cmd.Parameters.AddWithValue("@usuario", ad_UsuarioEmpresa.cod_usu);
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

        public void InsertUsuarioVentana(AE_GA_SEG_Tusuventana ad_UsuarioVentana)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SEG_Pinsertusuarioventana", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", ad_UsuarioVentana.cod_emp);
                cmd.Parameters.AddWithValue("@usuario", ad_UsuarioVentana.cod_usu);
                cmd.Parameters.AddWithValue("@modulo", ad_UsuarioVentana.cod_mod);
                cmd.Parameters.AddWithValue("@ventana", ad_UsuarioVentana.cod_ven);
                cmd.Parameters.AddWithValue("@rol", ad_UsuarioVentana.cod_rol);
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

        public void InsertAutLoginVentana(AE_GA_SEG_Tloginvent ae_ga_seg_tloginvent)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SEG_PsetAutLoginVentana", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", ae_ga_seg_tloginvent.usuario);
                cmd.Parameters.AddWithValue("@empresa", ae_ga_seg_tloginvent.empresa);
                cmd.Parameters.AddWithValue("@ventana", ae_ga_seg_tloginvent.ventana);
                cmd.Parameters.AddWithValue("@pc", ae_ga_seg_tloginvent.pc);
                cmd.Parameters.AddWithValue("@pcdns", ae_ga_seg_tloginvent.pcdns);
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

        public void InsertAutLogin(AE_GA_SEG_Tlogin ae_ga_seg_tlogin)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GA_SEG_PsetAutLogin", db);
                cmd.Parameters.AddWithValue("usuario", ae_ga_seg_tlogin.usuario);
                cmd.Parameters.AddWithValue("empresa", ae_ga_seg_tlogin.empresa);
                cmd.Parameters.AddWithValue("FECHA", ae_ga_seg_tlogin.fecha);
                cmd.CommandType = CommandType.StoredProcedure;
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
        #endregion

        #region Update
        public void UpdateNivel1(AE_GA_SEG_TmenuNivel1 ae_seg_tmenunivel1)
        {
            try
            {
                string update = "UPDATE GA_SEG_TMENU " +
                                "SET descripcion='" + ae_seg_tmenunivel1.description + "', " +
                                "url='" + ae_seg_tmenunivel1.url + "', " +
                                "hijos='" + ae_seg_tmenunivel1.hijos + "', " +
                                "icono ='" + ae_seg_tmenunivel1.icono + "' " +
                                "WHERE id_menu_opcion = '" + ae_seg_tmenunivel1.id_menu_option + "'";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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
            try
            {
                if (ae_seg_tmenunivel1.iav == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(1," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.corpal == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(2," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.rectima == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(3," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.depo == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(6," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.allparts == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(4," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.cao == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(5," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                if (ae_seg_tmenunivel1.iavec == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(7," + ae_seg_tmenunivel1.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel1.id_menu_option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUsuarioVentana(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            try
            {
                string update = "UPDATE GA_SEG_Tpermisos " +
                                "SET usuario='" + ae_ga_seg_tpermisos.usuario + "', " +
                                "empresa='" + ae_ga_seg_tpermisos.empresa + "', " +
                                "proyecto='" + ae_ga_seg_tpermisos.proyecto + "', " +
                                "ventana ='" + ae_ga_seg_tpermisos.ventana + "' " +
                                "WHERE id = '" + ae_ga_seg_tpermisos.id + "'";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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

        public void UpdateNivel2(AE_GA_SEG_TmenuNivel2 ae_seg_tmenunivel2)
        {
            try
            {
                string update = "UPDATE GA_SEG_TMENU " +
                                "SET descripcion='" + ae_seg_tmenunivel2.description + "', " +
                                "url='" + ae_seg_tmenunivel2.url + "', " +
                                "hijos='" + ae_seg_tmenunivel2.hijos + "', " +
                                "icono ='" + ae_seg_tmenunivel2.icono + "' " +
                                "WHERE id_menu_opcion = '" + ae_seg_tmenunivel2.id_menu_option + "'";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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
            try
            {
                if (ae_seg_tmenunivel2.iav == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(1," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.corpal == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(2," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.rectima == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(3," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.depo == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(6," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.allparts == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(4," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.cao == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(5," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                if (ae_seg_tmenunivel2.iavec == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(7," + ae_seg_tmenunivel2.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel2.id_menu_option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateNivel3(AE_GA_SEG_TmenuNivel3 ae_seg_tmenunivel3)
        {
            try
            {
                string update = "UPDATE GA_SEG_TMENU " +
                                "SET descripcion='" + ae_seg_tmenunivel3.description + "', " +
                                "url='" + ae_seg_tmenunivel3.url + "', " +
                                "icono ='" + ae_seg_tmenunivel3.icono + "' " +
                                "WHERE id_menu_opcion = '" + ae_seg_tmenunivel3.id_menu_option + "'";
                SqlCommand cmd = new SqlCommand(update, db);
                cmd.CommandType = CommandType.Text;
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
            try
            {
                if (ae_seg_tmenunivel3.iav == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(1," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 1 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.corpal == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(2," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 2 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.rectima == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(3," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 3 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.depo == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(6," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 6 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.allparts == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(4," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 4 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.cao == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(5," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 5 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                if (ae_seg_tmenunivel3.iavec == "True")
                {
                    DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
                    InsertGlobal("INSERT INTO GA_SEG_Tempremenu VALUES(7," + ae_seg_tmenunivel3.id_menu_option + ")");
                }
                else DeleteGlobal("DELETE FROM GA_SEG_Tempremenu WHERE cod_emp = 7 AND cod_men = " + ae_seg_tmenunivel3.id_menu_option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete
        public void DeleteGlobal(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, db);
                cmd.CommandType = CommandType.Text;
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

        public void DeleteUsuarioEmpresa(AE_GA_SEG_Tusuempresa ad_UsuarioEmpresa)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SEG_Pdeleteusuarioempresa", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", ad_UsuarioEmpresa.cod_emp);
                cmd.Parameters.AddWithValue("@usuario", ad_UsuarioEmpresa.cod_usu);
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

        public void DeleteUsuarioVentana(AE_GA_SEG_Tusuventana ad_UsuarioVentana)
        {
            using (SqlCommand cmd = new SqlCommand("GA_SEG_Pdeleteusuarioventana", db))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empresa", ad_UsuarioVentana.cod_emp);
                cmd.Parameters.AddWithValue("@usuario", ad_UsuarioVentana.cod_usu);
                cmd.Parameters.AddWithValue("@modulo", ad_UsuarioVentana.cod_mod);
                cmd.Parameters.AddWithValue("@ventana", ad_UsuarioVentana.cod_ven);
                cmd.Parameters.AddWithValue("@rol", ad_UsuarioVentana.cod_rol);
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
    }
}
