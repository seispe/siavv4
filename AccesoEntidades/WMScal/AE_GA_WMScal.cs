using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoEntidades.WMScal
{
    public class AE_GA_WMS_TPedusuario
    {
        public int id { set; get; }
        public string pedido { set; get; }
        public int id_usuario { set; get; }
    }

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
}
