using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace SIAV_v4.Proyectos.Pruebas
{
    public partial class frm_LeerDatosJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url;
            string datos = "";
            WebRequest wr;
            WebResponse wres;
            Stream stream;
            StreamReader streamreader;

            //modificar la url para realizar la busqueda indicada
            url = "http://ventas.iav.com.ec/json/wms/GPIAV/2017-04-26/2017-04-26";
            wr = WebRequest.Create(url);
            wres = wr.GetResponse();
            stream = wres.GetResponseStream();
            streamreader = new StreamReader(stream);

            //Obtenemos los datos de Cada Pedido
            dynamic dynJson = JsonConvert.DeserializeObject(streamreader.ReadToEnd());
            foreach (var item in dynJson)
            {
                //Aqui podemos guardar esos datos en base de datos / realizar update
                datos = datos + (item.wms_id + " / " +  item.numero_factura + " / " + item.estado + " / " + item.fechafactura + " <br> ");
            }

            //Mostramos en Pantalla
            Response.Clear();
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            Response.ContentType = "application/json";
            Response.Write(datos);
            Response.End();
        }
    }
}