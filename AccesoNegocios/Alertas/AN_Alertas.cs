using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoNegocios.Alertas
{
    public class AN_Alertas
    {
        /// <summary>
        /// Muestra un Mensaje de acuerdo a los parametros
        /// </summary>
        /// <param name="titulo">Titulo del Mensaje</param>
        /// <param name="msg">Contenido del mensaje</param>
        /// <param name="alerta">Color de la alerta</param>
        /// <returns>Mensaje para enviar a Label</returns>
        public string Mensaje(string titulo, string msg, string alerta)
        {
            /* Tipos de Mensajes */
            // info
            // success
            // warning
            // danger
            switch (alerta)
            {
                case "rojo":
                    alerta = "danger";
                    break;
                case "amarillo":
                    alerta = "warning";
                    break;
                case "azul":
                    alerta = "info";
                    break;
                case "verde":
                    alerta = "success";
                    break;
                default:
                    break;
            }
            //string mensaje = "<div id='mensaje' class='alert alert-" + alerta + " fade in mensaje'><a href='#' class='close' data-dismiss='alert'>&times;</a><strong>" + titulo + "</strong> " + msg + "</div>";
            string mensaje = "<div id='mensaje' style='position: absolute; width: 400px; height: 80px; top: 0px; left: 540px; z-index:99999;' class='alert alert-"+ alerta +"' fade in><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><strong>"+ titulo +"</strong>"+ msg +"</div>";
            return mensaje;
        }
    }
}
