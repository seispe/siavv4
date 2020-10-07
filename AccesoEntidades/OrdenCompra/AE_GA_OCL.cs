/****************************************************************
-- Titulo:  Entidad Manejo de Orden Compra
-- Author:  Gabriel Reyes
-- Fecha:   26/06/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using System;

namespace AccesoEntidades.OrdenCompra
{
    public class GA_OCL_Tfacturas
    {
        public string empresa { get; set; }
        public string factura { get; set; }
        public DateTime? fecha { get; set; }
        public string bodega { get; set; }
        public string pedido { get; set; }
        public decimal total { get; set; }
        public int recibida { get; set; }
        public string usuariorecibe { get; set; }
        public DateTime? fecharecibe { get; set; }
    }
}
