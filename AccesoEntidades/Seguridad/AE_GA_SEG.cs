/****************************************************************
-- Titulo:  Entidad Manejo de Seguridad
-- Author:  Gabriel Reyes
-- Fecha:   24/04/2017
-- Version: 4.0.2
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************
-- AuthorCambio:  Sebastian Pozo
-- CambiosRealizados: Tablas Manejo Empresas: AE_GA_SEG_TEmpresas
-- Fecha: 26/04/2017
-- Reviso: {Compañero del Area}
****************************************************************/

using System;

namespace AccesoEntidades.Seguridad
{
    /*
     * Tabla Manejo de Usuarios Active Directory
     * */
    public class AE_GA_SEG_Tuseractdir
    {
        public string usuario { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public string nombreCompleto { set; get; }
        public string correo { set; get; }
        public string empresa { set; get; }
        public string ubicacion { set; get; }
        public string ciudad { set; get; }
        public string area { set; get; }
    }
    /*
     * Tabla de Usuarios Login
     * */
    public class AE_GA_SEG_Tlogin
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public string empresa { set; get; }
        public DateTime? fecha { set; get; }
    }
    /*
     * Tabla de Usuarios Login Ventana
     * */
    public class AE_GA_SEG_Tloginvent
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public string empresa { set; get; }
        public string ventana { set; get; }
        public string pc { set; get; }
        public string pcdns { set; get; }
        public DateTime? fecha { set; get; }
    }
    /*
     * Tabla de Empleado
     * */
    public class AE_GA_SEG_Templeado
    {
        public string empleado { set; get; }
        public string usuariogp { get; set; }
        public string correo { get; set; }
        public string cod_vendedor { get; set; }
    }
    /*
     * Tabla de Empresas
     * */
     public class AE_GA_SEG_TEmpresas
    {
        public int cod_emp { set; get; }
        public string empresa { set; get; }
        public string acronimo { set; get; }
        public string base_gp { set; get; }
        public string servidor { set; get; }
        public string estado { set; get; }
    }

    public class AE_GA_SEG_TmenuNivel1
    {
        #region Variables Globales
        public string id_menu_option { set; get; }
        public string description { set; get; }
        public string id_parent_menu_option { set; get; }
        public string url { set; get; }
        public string nivel { set; get; }
        public string hijos { set; get; }
        public string icono { set; get; }
        public string iav { set; get; }
        public string corpal { set; get; }
        public string cao { set; get; }
        public string rectima { set; get; }
        public string allparts { set; get; }
        public string depo { set; get; }
        public string iavec { set; get; }
        #endregion
    }

    public class AE_GA_SEG_TmenuNivel2
    {
        #region Variables Globales
        public string id_menu_option { set; get; }
        public string description { set; get; }
        public string id_parent_menu_option { set; get; }
        public string url { set; get; }
        public string nivel { set; get; }
        public string hijos { set; get; }
        public string icono { set; get; }
        public string iav { set; get; }
        public string corpal { set; get; }
        public string cao { set; get; }
        public string rectima { set; get; }
        public string allparts { set; get; }
        public string depo { set; get; }
        public string iavec { set; get; }
        #endregion
    }

    public class AE_GA_SEG_TmenuNivel3
    {
        #region Variables Globales
        public string id_menu_option { set; get; }
        public string description { set; get; }
        public string id_parent_menu_option { set; get; }
        public string url { set; get; }
        public string nivel { set; get; }
        public string hijos { set; get; }
        public string icono { set; get; }
        public string iav { set; get; }
        public string corpal { set; get; }
        public string cao { set; get; }
        public string rectima { set; get; }
        public string allparts { set; get; }
        public string depo { set; get; }
        public string iavec { set; get; }
        #endregion
    }

    public class AE_GA_SEG_Tusuempresa
    {
        public int cod_emp { set; get; }
        public string cod_usu { set; get; }
    }

    public class AE_GA_SEG_Tusuventana
    {
        public int cod_emp { set; get; }
        public string cod_usu { set; get; }
        public int cod_rol { set; get; }
        public int cod_mod { set; get; }
        public int cod_ven { set; get; }
    }

    public class AE_GA_SEG_Tpermisos
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string empresa { get; set; }
        public string proyecto { get; set; }
        public string ventana { get; set; }
        public string permiso { get; set; }
        public int activo { get; set; }
    }

}
