/****************************************************************
-- Titulo:  Entidad Manejo Tablas de Despacho
-- Author:  Sebastián Pozo
-- Fecha:   03/05/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************
-- AuthorCambio:  Sebastian Pozo
-- CambiosRealizados: Nuevos nombres tablas y campos
-- Fecha: 12/07/2017
-- Reviso: {Compañero del Area}
****************************************************************/
using System;

namespace AccesoEntidades.Despacho
{
    public class AE_GA_PKG_Tproceso
    {
        public int idproceso { set; get; }
        public int posicion { set; get; }
        public string descripcion { set; get; }
    }

    public class AE_GA_PKG_Tmaestro
    {
        public int idmaestro { set; get; }
        public string descripcion { set; get; }
        public string ruc { set; get; }
        public string factura { set; get; }
        public DateTime? fechainicio { set; get; }
        public DateTime? fechafin { set; get; }
        public int estadoinicial { set; get; }
    }

    public class AE_GA_PKG_Tdetalle
    {
        public int iddetalle { set; get; }
        public int idproceso { set; get; }
        public int idmaestro { set; get; }
        public DateTime? fechaInigestion { set; get; }
        public DateTime? fechaFingestion { set; get; }
        public string documento { set; get; }
        public string usuario { set; get; }
        public string observacion { set; get; }
        public int activo { set; get; }
    }
}

