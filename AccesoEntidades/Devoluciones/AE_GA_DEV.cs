/****************************************************************
-- Titulo:  Entidad Manejo de Devoluciones
-- Author:  Gabriel Reyes
-- Fecha:   26/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/


using System;

namespace AccesoEntidades.Devoluciones
{
    /*
     * Tabla Manejo de Estados de Devolucion
     * */
    public class AE_GA_DEV_Testados
    {
        public int idestado { set; get; }
        public string estado { set; get; }
    }
    /*
     * Tabla Manejo de Motivos de Devolucion
     * */
    public class AE_GA_DEV_Tmotivos
    {
        public int idmotivo { get; set; }
        public string codmotivo { get; set; }
        public string descripcion { get; set; }
        public string codweb { get; set; }
        public string tipo { get; set; } //INTERNA - EXTERNA
    }
    /*
     * Tabla Manejo de Maestro de Devolucion
     * */
    public class AE_GA_DEV_Tdevolucion
    {
        public int iddevolucion { get; set; }
        public string idcliente { get; set; }
        public DateTime? fechadocumento { get; set; }
        public string idVendedor { get; set; }
        public int bultos { get; set; }
        public int estado { get; set; }
        public string factura { get; set; }
        public string devolucion { get; set; }
        public string observacion { get; set; }
        public string direccion { get; set; }
        public int idweb { get; set; } 
        public DateTime? fechaeliminacion { get; set; }
        public string usuarioeliminacion { get; set; }
        public DateTime? fechalogistica { get; set; }
        public string usuariologistica { get; set; }
        public DateTime? fechaVentas { get; set; }
        public string usuarioventas { get; set; }
    }
    /*
     * Tabla Manejo de Detalle de Devolucion
     * */
    public class AE_GA_DEV_Tdevoldetalle
    {
        public int iddetalle { get; set; }
        public string articulo { get; set; }
        public int cantidadOriginal { get; set; }
        public int cantidadReal { get; set; }
        public string motivoOriginal { get; set; }
        public string motivoReal { get; set; }
        public int iddevolucion { get; set; }
        public string observacion { get; set; }
    }
}
