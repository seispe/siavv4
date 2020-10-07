/****************************************************************
-- Titulo:  Entidad Manejo de Preordenes CAO
-- Author:  Sebastian Pozo
-- Fecha:   05/06/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using System;

namespace AccesoEntidades.PreOrdenes
{
    /** Tabla Manejo de niveles de Autorizacion**/
    public class PRE_Autoriza
    {
        public decimal codAutoriza { set; get; }
        public string nomAutoriza { set; get; }
        public string cargoAutoriza { set; get; }
        public string tipoa { set; get; }
        public decimal monto_desde { set; get; }
        public decimal monto_hasta { set; get; }
        public string tipo { set; get; }
        public string correo { set; get; }
        public int AEscala { set; get; }
    }
    /** Tabla Manejo de Configuraciones Departamentos**/
    public class PRE_Configuracion
    {
        public string control { set; get; }
        public string datos { set; get; }
        public string descripcion { set; get; }
        public int estado { set; get; }
    }
    /** Tabla Manejo de Departamentos**/
    public class PRE_Departamento
    {
        public decimal codDepartamento { set; get; }
        public string nomDepartamento { set; get; }
    }
    /** Tabla Manejo de Gestiones de Compra Tempral**/
    public class PRE_Tbl_Compra_Gestion
    {
        public string Base { set; get; }
        public string Producto { set; get; }
        public string DescripcionProducto { set; get; }
        public string tipo_doc { set; get; }
        public decimal Cantidad { set; get; }
        public decimal Costo { set; get; }
        public string Unidad { set; get; }
        public string Bodega { set; get; }
        public DateTime? fecha_doc { set; get; }
        public decimal linea { set; get; }
        public string referencia { set; get; }
        public string Cliente { set; get; }
        public string Proveedor { set; get; }
        public string DescripcionProveedor { set; get; }
        public string Maquinaria { set; get; }
        public string Nota { set; get; }
        public string cciUsuario { set; get; }
        public string cciSecuencia { set; get; }
        public string DEX_ROW_ID { set; get; }
    }
    /** Tabla Manejo de Gestiones de Compra Real**/
    public class PRE_Tbl_Compra_Gestion_Real
    {
        public string Base { set; get; }
        public string cciProducto { set; get; }
        public string cnoProducto { set; get; }
        public string tipo_doc { set; get; }
        public decimal Cantidad { set; get; }
        public decimal costoArticulo { set; get; }
        public string Unidad { set; get; }
        public string Bodega { set; get; }
        public DateTime? fecha_doc { set; get; }
        public decimal linea { set; get; }
        public string referencia { set; get; }
        public string Cliente { set; get; }
        public string Proveedor { set; get; }
        public string DescripcionProveedor { set; get; }
        public string Maquinaria { set; get; }
        public string Nota { set; get; }
        public string cciUsuario { set; get; }
        public string EstadoAut { set; get; }
        public string cciSecuencia { set; get; }
        public int DEX_ROW_ID { set; get; }
        public string Tipo_Aut { set; get; }
        public string OC { set; get; }
        public int AEscalaG { set; get; }
        public DateTime? FechaGeneraOC { set; get; }
        public string Autorizador1 { set; get; }
        public DateTime? FechaAutorizaOC1 { set; get; }
        public string Autorizador2 { set; get; }
        public DateTime? FechaAutorizaOC2 { set; get; }
        public string Autorizador3 { set; get; }
        public DateTime? FechaAutorizaOC3 { set; get; }
        public string Autorizador4 { set; get; }
        public DateTime? FechaAutorizaOC4 { set; get; }
        public string Autorizador5 { set; get; }
        public DateTime? FechaAutorizaOC5 { set; get; }
        public string Autorizador6 { set; get; }
        public DateTime? FechaAutorizaOC6 { set; get; }
        public decimal nqnCantidad { set; get; }
        public string especificacion { set; get; }
    }
    /** Tabla Manejo de OC Econnect Cabecera**/
    public class PRE_Tbl_Econ_OCCab
    {
        public string PONUMBER { set; get; }
        public string VENDORID { set; get; }
        public DateTime? DOCDATE { set; get; }
        public string BUYERID { set; get; }
        public DateTime? REQDATE { set; get; }
        public DateTime? PRMDATE { set; get; }
        public string CONFIRM1 { set; get; }
        public string PYMTRMID { set; get; }
        public string cciSecuencia { set; get; }
        public string ESTADO { set; get; }
    }
    /** Tabla Manejo de OC Econnect Detalle**/
    public class PRE_Tbl_Econ_OCDet
    {
        public string PONUMBER { set; get; }
        public string VENDORID { set; get; }
        public string ITEMNMBR { set; get; }
        public string ITEMDESC { set; get; }
        public int QTYORDER { set; get; }
        public decimal UNITCOST { set; get; }
        public string UOFM { set; get; }
        public string locncode { set; get; }
    }
    /** Tabla Manejo de Gestiones de Inventario Temporal**/
    public class PRE_Tbl_Inventario_Gestion
    {
        public string Base { set; get; }
        public string Producto { set; get; }
        public int tipo_doc { set; get; }
        public decimal Cantidad { set; get; }
        public string Unidad { set; get; }
        public string Bodega { set; get; }
        public DateTime? fecha_doc { set; get; }
        public string referencia { set; get; }
        public string cliente { set; get; }
        public string maquinaria { set; get; }
        public string cciUsuario { set; get; }
        public decimal linea { set; get; }
        public string cciSolicitante { set; get; }
        public string nota { set; get; }
        public string Descripcion_Producto { set; get; }
        public string secuencia { set; get; }
        public DateTime? fecha_egreso { set; get; }
        public string especificacion { set; get; }
    }
    /** Tabla Manejo de Gestiones de Inventario real**/
    public class PRE_Tbl_Inventario_Gestion_Real
    {
        public string Base { set; get; }
        public string Producto { set; get; }
        public int tipo_doc { set; get; }
        public decimal Cantidad { set; get; }
        public string Unidad { set; get; }
        public string Bodega { set; get; }
        public DateTime? fecha_doc { set; get; }
        public string referencia { set; get; }
        public string cliente { set; get; }
        public string maquinaria { set; get; }
        public string cciUsuario { set; get; }
        public decimal linea { set; get; }
        public string cciSolicitante { set; get; }
        public string nota { set; get; }
        public string Descripcion_Producto { set; get; }
        public string secuencia { set; get; } 
        public string VA { set; get; }
        public DateTime? fecha_egreso { set; get; }
        public string Autorizador { set; get; }
        public string especificacion { set; get; }
    }
    /** Tabla Manejo de Ordenes de Compra Finalizadas**/
    public class PRE_Tbl_OrdenesCompra
    {
        public string Base { set; get; }
        public string cciProducto { set; get; }
        public string cnoProducto { set; get; }
        public string tipo_doc { set; get; }
        public decimal Cantidad { set; get; }
        public decimal costoArticulo { set; get; }
        public string Unidad { set; get; }
        public string Bodega { set; get; }
        public DateTime? fecha_doc { set; get; }
        public decimal linea { set; get; }
        public string referencia { set; get; }
        public string Cliente { set; get; }
        public string Proveedor { set; get; }
        public string DescripcionProveedor { set; get; }
        public string Maquinaria { set; get; }
        public string Nota { set; get; }
        public string cciUsuario { set; get; }
        public string EstadoAut { set; get; }
        public string cciSecuencia { set; get; }
        public string Tipo_Aut { set; get; }
        public string DocumentoOC { set; get; }
        public int AEscalaG { set; get; }
        public DateTime FechaGeneraOC { set; get; }
        public string Autorizador1 { set; get; }
        public DateTime? FechaAutorizaOC1 { set; get; }
        public string Autorizador2 { set; get; }
        public DateTime? FechaAutorizaOC2 { set; get; }
        public string Autorizador3 { set; get; }
        public DateTime? FechaAutorizaOC3 { set; get; }
        public string Autorizador4 { set; get; }
        public DateTime? FechaAutorizaOC4 { set; get; }
        public string Autorizador5 { set; get; }
        public DateTime? FechaAutorizaOC5 { set; get; }
        public string Autorizador6 { set; get; }
        public DateTime? FechaAutorizaOC6 { set; get; }
        public decimal nqnCantidad { set; get; }
        public string DEX_ROW_ID { set; get; }
    }
    /** Tabla Manejo de Preordenes Cabecera**/
    public class PRE_Tbl_preorden_Cab
    {
        public string cciSecuencia { set; get; }
        public string ctpPreOrden { set; get; }
        public string cciEstado { set; get; }
        public string cciSolicitado { set; get; }
        public string cciObra { set; get; }
        public string cnoObservacion { set; get; }
        public DateTime? dfeDocumento { set; get; }
        public DateTime? dfeEntrega { set; get; }
        public int DEX_ROW_ID { set; get; }
        public string Obra { set; get; }
    }
    /** Tabla Manejo de Preordenes Cabecera Temporal**/
    public class PRE_Tbl_preorden_Cab_Tempo
    {
        public string secuencia { set; get; }
        public string usuario { set; get; }
        public DateTime? fecha { set; get; }
    }
    /** Tabla Manejo de Preordenes Detalle**/
    public class PRE_Tbl_preorden_Det
    {
        public string cciSecuencia { set; get; }
        public decimal nqnLinea { set; get; }
        public string cciProducto { set; get; }
        public string cnoProducto { set; get; }
        public string cciUmedida { set; get; }
        public decimal nqnCantidad { set; get; }
        public string cciMaquinaria { set; get; }
        public string cnoObservacion { set; get; }
        public string cciEstadoDet { set; get; }
        public decimal nqnCantidadGestionada { set; get; }
        public string EstadoAutorizacion { set; get; }
        public int DEX_ROW_ID { set; get; }
        public DateTime? FechaAutorizacion { set; get; }
        public string ANULADO { set; get; }
        public string Motivo { set; get; }
        public decimal Costo { set; get; }
        public decimal Stock { set; get; }
        public decimal Monto { set; get; }
        public string Maquinaria { set; get; }
        public string Autorizador { set; get; }
        public decimal CantidadGestionadaOC { set; get; }
        public string MotivoCierre { set; get; }
        public string Rubro { set; get; }
        public DateTime FechaCierre { set; get; }
        public string MotivoRechazo { set; get; }
        public DateTime? FechaRechazo { set; get; }
    }
    /** Tabla Manejo de Preordenes Detalle Temporañ**/
    public class PRE_Tbl_preorden_Det_tempo
    {
        public string cciSecuencia { set; get; }
        public decimal nqnLinea { set; get; }
        public string cciProducto { set; get; }
        public string cnoProducto { set; get; }
        public string cciUmedida { set; get; }
        public decimal nqnCantidad { set; get; }
        public string cciMaquinaria { set; get; }
        public string cnoObservacion { set; get; }
        public string cciEstadoDet { set; get; }
        public decimal nqnCantidadGestionada { set; get; }
        public string EstadoAutorizacion { set; get; }
        public int DEX_ROW_ID { set; get; }
        public string ANULADO { set; get; }
        public decimal Costo { set; get; }
        public decimal Stock { set; get; }
        public decimal Monto { set; get; }
        public string Maquinaria { set; get; }
        public string Autorizador { set; get; }
        public decimal CantidadGestionadaOC { set; get; }
        public string Usuario { set; get; }
        public string Rubro { set; get; }
    }
    /** Tabla Manejo de Secuencia de Preordenes**/
    public class PRE_Tbl_secuencia_preorden
    {
        public string cciSecuencia { set; get; }
    }
    /** Tabla Manejo de Solicitudes de Compra**/
    public class PRE_Tbl_Solicitud_Compra
    {
        public string Ubod_sol { set; get; }
        public string Fecha_Sol { set; get; }
        public string Cod_Secuencia { set; get; }
        public string Cod_Producto { set; get; }
        public decimal Cant_original { set; get; }
        public decimal Cant_solicitada { set; get; }
        public int Linea { set; get; }
        public string Bodega_Compra { set; get; }
        public decimal egreso { set; get; }
        public string EstadoAut { set; get; }
        public decimal Cant_Compra { set; get; }
        public decimal egresoTotal { set; get; }
        public string especificacion { set; get; }
    }
    /** Tabla Manejo de Solicitudes de Compran Temporal**/
    public class PRE_Tbl_Solicitud_Compra_tempo
    {
        public string Ubod_sol { set; get; }
        public string Fecha_Sol { set; get; }
        public string Cod_Secuencia { set; get; }
        public string Cod_Producto { set; get; }
        public decimal Cant_original { set; get; }
        public decimal Cant_solicitada { set; get; }
        public int Linea { set; get; }
        public string Bodega_Compra { set; get; }
        public decimal egreso { set; get; }
        public string EstadoAut { set; get; }
        public string especificacion { set; get; }
    }
}
