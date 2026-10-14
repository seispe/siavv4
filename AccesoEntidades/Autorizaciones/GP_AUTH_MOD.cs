using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoEntidades.Autorizaciones
{
    public class GP_AUTH_MOD
    {
        public int ID { get; set; }
        public string USUARIO_SOLICITA_PERMISO { get; set; }
        public DateTime FECHA_SOLICITUD { get; set; }
        public string MODULO { get; set; }
        public int AÑO { get; set; }
        public int MES { get; set; }
        public string NOMBRE_MES { get; set; }

        public GP_AUTH_MOD() { }

        public GP_AUTH_MOD(int id, string usuario_solicita_permiso, DateTime fecha_solicitud, string modulo, int año, string nombreMes)
        {
            ID = id;
            USUARIO_SOLICITA_PERMISO = usuario_solicita_permiso;
            FECHA_SOLICITUD = fecha_solicitud;
            MODULO = modulo;
            AÑO = año;
            NOMBRE_MES = nombreMes;
        }
    }
}
