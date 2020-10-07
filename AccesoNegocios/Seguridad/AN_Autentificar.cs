/****************************************************************
-- Titulo:  Armar Login
-- Author:  Sebastian Pozo
-- Fecha:   26/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoDatos.Seguridad;
using AccesoEntidades.Seguridad;
using System;
using System.Data;
using System.DirectoryServices;

namespace AccesoNegocios.Seguridad
{
    public class AN_Autentificar
    {
        #region Variables Globales
        AD_SEG ad_seg = new AD_SEG();
        AE_GA_SEG_Templeado ae_seg_templeado = new AE_GA_SEG_Templeado();
        #endregion

        #region Funciones
        public DataSet getEmpresas()
        {
            try
            {
                return ad_seg.getnombreEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getusuarioEmpresa(string usuario, string cod_emp)
        {
            try
            {
                return ad_seg.getusuarioEmpresa(usuario,cod_emp);
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
                return ad_seg.getconvendedor(usuario);
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
                return ad_seg.getusuariogp(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getbaseEmpresa(string empresa)
        {
            try
            {
                return ad_seg.getbaseEmpresas(empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Busca el Usuario en el Active Directory
        /// </summary>
        /// <param name="usuario">usuario de dominio</param>
        /// <param name="password">clave de dominio</param>
        /// <param name="strDominio">dominio</param>
        /// <param name="DominioIp">ip dominio</param>
        /// <returns>True si existe; False si no existe.</returns>
        public bool UsuarioAD(string usuario, string password, string strDominio, string DominioIp)
        {
            bool res = false;
            try
            {
                string DirectoryEnt = "LDAP://" + DominioIp;
                string dominiousuario = strDominio + @"\" + usuario;
                DirectoryEntry Entry = new DirectoryEntry(DirectoryEnt, dominiousuario, password, AuthenticationTypes.None);
                object nativeObject = Entry.NativeObject;
                res = true;
            }
            catch (Exception)
            {
                //No hay Información
            }
            return res;
        }

        public void ListUsuarioAD()
        {
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://ALVARADO");
                DirectorySearcher dSearch = new DirectorySearcher(entry);
                dSearch.Filter = "(objectClass=user)";
                foreach (SearchResult sResultSet in dSearch.FindAll())
                {
                    if (sResultSet.Properties["samaccountname"].Count > 0)
                    {
                        ae_seg_templeado.empleado = sResultSet.Properties["samaccountname"][0].ToString();
                        int i = ae_seg_templeado.empleado.IndexOf(".");
                        if (i > 0)
                        {
                            ad_seg.InsertEmpleado(ae_seg_templeado);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet UsuarioEmpresa(string usuario)
        {
            return ad_seg.GetUsuarioEmpresa(usuario);
        }

        public DataSet getEmpleados()
        {
            return ad_seg.GetEmpleados();
        }

        public DataSet getEmpresa()
        {
            return ad_seg.GetEmpresas();
        }

        public DataSet getEmpresa(string usuario)
        {
            return ad_seg.GetEmpresas(usuario);
        }

        public DataTable nivel1(string empresa)
        {
            return ad_seg.nivel1(empresa);
        }

        public DataTable nivel2(string padre, string empresa)
        {
            return ad_seg.nivel2(padre,empresa);
        }

        public DataTable nivel3(string padre, string empresa)
        {
            return ad_seg.nivel3(padre, empresa);
        }

        public void InsertUsuarioVentana(AE_GA_SEG_Tusuventana ae_ga_seg_Tusuventana)
        {
            ad_seg.InsertUsuarioVentana(ae_ga_seg_Tusuventana);
        }

        public void DeleteUsuarioVentana(AE_GA_SEG_Tusuventana ae_ga_seg_Tusuventana)
        {
            ad_seg.DeleteUsuarioVentana(ae_ga_seg_Tusuventana);
        }

        public DataSet GetUsuarioVentana(string usuario, string empresa, string modulo)
        {
            return ad_seg.GetUsuarioVentana(usuario, empresa, modulo);
        }

        public void InsertUsuarioEmpresa(AE_GA_SEG_Tusuempresa ae_ga_seg_Tusuempresa)
        {
            ad_seg.InsertUsuarioEmpresa(ae_ga_seg_Tusuempresa);
        }

        public void DeleteUsuarioEmpresa(AE_GA_SEG_Tusuempresa ae_ga_seg_Tusuempresa)
        {
            ad_seg.DeleteUsuarioEmpresa(ae_ga_seg_Tusuempresa);
        }

        public void InsertAutLogin(AE_GA_SEG_Tlogin ae_ga_seg_tlogin)
        {
            ad_seg.InsertAutLogin(ae_ga_seg_tlogin);
        }
        #endregion
    }
}
