/****************************************************************
-- Titulo:  Entidad Manejo de Comisiones
-- Author:  Gabriel Reyes
-- Fecha:   24/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using System;

namespace AccesoEntidades.Comisiones
{
    /*
     * Tabla Configuracion de Comisiones
     * */
    public class AE_GA_COM_Tconfig
    {
        public int idConfig { get; set; }
        public string config { get; set; }
        public decimal valor { get; set; }
        public decimal porcentake { get; set; }
    }
    /*
     * Tabla de Vendedores
     * */
    public class AE_GA_COM_Tvendedor
    {
        public string idVendedor { get; set; }
        public string vendedor { get; set; }
    }
    /*
     * Tabla Temporal Comisiones Pagadas
     * */
    public class AE_GA_COM_Ttemppagada
    {
        public int idComi { get; set; }
        public string idVendedor { get; set; }
        public string ruc { get; set; }
        public string factura { get; set; }
        public DateTime? fechafac { get; set; }
        public DateTime? fechaefectivizada { get; set; }
        public decimal subtotal { get; set; }
        public decimal notasCredito { get; set; }
        public decimal devolucion { get; set; }
        public decimal netoComi { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Temporal Efectividad Calculos
     * */
    public class AE_GA_COM_Ttempefectividad_calc
    {
        public int idEfectividad { get; set; }
        public int idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public int totalCliente { get; set; }
        public int ventaCliente { get; set; }
        public decimal porceAlcanzado { get; set; }
        public decimal porceComi { get; set; }
        public decimal porceComisionar { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Temporal Morosidad Calculos
     * */
    public class AE_GA_COM_Ttempmorosidad_calc
    {
        public int idMorosidad { get; set; }
        public string idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public decimal ventaneta { get; set; }
        public decimal montoMorosidad { get; set; }
        public decimal montoAlcanzado { get; set; }
        public decimal porceComi { get; set; }
        public decimal porceAceptable { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Temporal Devolucion Calculos
     * */
    public class AE_GA_COM_Ttempdevolucion_cal
    {
        public int idDevolucion { get; set; }
        public string idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public decimal ventaneta { get; set; }
        public decimal montoDevolucion { get; set; }
        public decimal montoAlcanzado { get; set; }
        public decimal porceAceptable { get; set; }
        public decimal porceComi { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Comisiones Pagadas
     * */
    public class AE_GA_COM_Tpagada
    {
        public int idComi { get; set; }
        public string idVendedor { get; set; }
        public string ruc { get; set; }
        public string factura { get; set; }
        public DateTime? fechafac { get; set; }
        public DateTime? fechaefectivizada { get; set; }
        public decimal subtotal { get; set; }
        public decimal notasCredito { get; set; }
        public decimal devolucion { get; set; }
        public decimal netoComi { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Efectividad Calculos
     * */
    public class AE_GA_COM_Tefectividad_calc
    {
        public int idEfectividad { get; set; }
        public int idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public int totalCliente { get; set; }
        public int ventaCliente { get; set; }
        public decimal porceAlcanzado { get; set; }
        public decimal porceComi { get; set; }
        public decimal porceComisionar { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Morosidad Calculos
     * */
    public class AE_GA_COM_Tmorosidad_calc
    {
        public int idMorosidad { get; set; }
        public string idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public decimal ventaneta { get; set; }
        public decimal montoMorosidad { get; set; }
        public decimal montoAlcanzado { get; set; }
        public decimal porceComi { get; set; }
        public decimal porceAceptable { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Devolucion Calculos
     * */
    public class AE_GA_COM_Tdevolucion_cal
    {
        public int idDevolucion { get; set; }
        public string idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public decimal ventaneta { get; set; }
        public decimal montoDevolucion { get; set; }
        public decimal montoAlcanzado { get; set; }
        public decimal porceAceptable { get; set; }
        public decimal porceComi { get; set; }
        public decimal comision { get; set; }
    }
    /*
     * Tabla Pagada Calculos
     * */
    public class AE_GA_COM_Tpagada_calc
    {
        public int idPago { get; set; }
        public string idVendedor { get; set; }
        public string mes { get; set; }
        public int año { get; set; }
        public decimal cupo { get; set; }
        public decimal neto { get; set; }
        public decimal porceAlcanzado { get; set; }
        public decimal porceComi { get; set; }
        public decimal porceComisionar { get; set; }
    }
}
