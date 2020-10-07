using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoEntidades.WMSiav
{
    public class AE_GA_WMS_Trol
    {
        public int id { set; get; }
        public string rol { set; get; }
        public int activo { set; get; }
        public DateTime? fecha_creacion { set; get; }
        public DateTime? fecha_modificacion { set; get; }
    }

    public class AE_GA_WMS_TUsuario
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public string clave { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }
        public int activo { set; get; }
        public DateTime? fecha_creacion { set; get; }
        public DateTime? fecha_modificacion { set; get; }
        public int id_rol { set; get; }
    }

    public class AE_GA_WMS_TPedusuario
    {
        public int id { set; get; }
        public string pedido { set; get; }
        public int id_usuario { set; get; }
    }

    public class AE_GA_WMS_Tlogistica
    {
        public int id { set; get; }
        public string pedido { set; get; }
        public int bulto { set; get; }
        public string camion { set; get; }
        public string ruta { set; get; }
        public string ciudad { set; get; }
        public string transportista { set; get; }
        public DateTime? fechacarga { set; get; }
        public int idestado { set; get; }
        public string usuario { set; get; }
        public int activo { set; get; }
    }

    public class AE_GA_WMS_Treversas
    {
        public int id { set; get; }
        public string proceso { set; get; }
        public string numconsolidado { set; get; }
        public string pedido { set; get; }
        public string producto { set; get; }
        public string motivo { set; get; }
        public string coor_destino { set; get; }
        public string coor_sugerida { set; get; }
        public decimal can_procesada { set; get; }
        public decimal can_reversar { set; get; }
        public string usuario { set; get; }
        public DateTime? freversa { set; get; }
        public int linea { set; get; }
    }

    public class AE_GA_WMS_Talterno
    {
        public int id { set; get; }
        public string codigoproducto { set; get; }
        public string codigoalterno { set; get; }
        public int estado { set; get; }
        public DateTime? fechacreacion { set; get; }
        public DateTime? fechaactualizacion { set; get; }
        public string usuario { set; get; }
        public string empresa { set; get; }
    }

    public class AE_GA_CC_TMaestroCC
    {
        public int id { set; get; }
        public string usuario { set; get; }
        public DateTime? fechainicial { set; get; }
        public DateTime? fechafinal { set; get; }
        public int estado { set; get; }
        public int activo { set; get; }
        public int idTipoCC { set; get; }
        public string empresa { set; get; }
        public string observacion { set; get; }
    }

    public class AE_GA_CC_TDetalleCC
    {
        public int id { set; get; }
        public string coordenada { set; get; }
        public string area { set; get; }
        public string rack { set; get; }
        public string percha { set; get; }
        public string usuario { set; get; }
        public int asignada { set; get; }
        public int estado { set; get; }
        public DateTime? fechaasignacion { set; get; }
        public string empresa { set; get; }
        public int idMaestroCC { set; get; }
    }

    public class AE_GA_CC_TReconteo
    {
        public int id { set; get; }
        public string producto { set; get; }
        public int cantconteo { set; get; }
        public DateTime? fecha { set; get; }
        public string empresa { set; get; }
        public string usuario { set; get; }
        public int activo { set; get; }
        public int idMaestroCC { set; get; }
    }
}
