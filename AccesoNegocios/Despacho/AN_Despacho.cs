

using AccesoDatos.Despacho;
using AccesoDatos.Seguridad;
using AccesoEntidades.Despacho;
using AccesoEntidades.Seguridad;
using AccesoNegocios.Seguridad;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;

namespace AccesoNegocios.Despacho
{
    public class AN_Despacho
    {
        #region VariablesGlobales
        AD_DES ad_des = new AD_DES();
        AE_GA_PKG_Tmaestro ae_ga_pkg_tmaestro = new AE_GA_PKG_Tmaestro();
        AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle = new AE_GA_PKG_Tdetalle();
        AD_SEG ad_seg = new AD_SEG();

        public object JsonConvert { get; private set; }
        #endregion

        #region Funciones
        //public GridView getfacturasPacking(string estado)
        //{
        //    DataSet dsp = new DataSet();
        //    GridView gv = new GridView();

        //    dsp = ad_des.getfacturasPacking(estado);

        //    if (dsp.Tables[0].Rows.Count > 0)
        //    {
        //        gv.DataSource = dsp;
        //        gv.DataBind();
        //    }
        //    else
        //    {
        //        dsp.Tables[0].Rows.Add(dsp.Tables[0].NewRow());
        //        gv.DataSource = dsp;
        //        gv.DataBind();
        //        int columncount = gv.Rows[0].Cells.Count;
        //        gv.Rows[0].Cells.Clear();
        //        gv.Rows[0].Cells.Add(new TableCell());
        //        gv.Rows[0].Cells[0].ColumnSpan = columncount;
        //        gv.Rows[0].Cells[0].Text = "No se encuentra datos";
        //    }
        //    return gv;
        //}

        public GridView getfacturasEstado(string estado)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_des.getPedidosEstado(estado);

            if (dsp.Tables[0].Rows.Count > 0)
            {
                gv.DataSource = dsp;
                gv.DataBind();
            }
            else
            {
                dsp.Tables[0].Rows.Add(dsp.Tables[0].NewRow());
                gv.DataSource = dsp;
                gv.DataBind();
                int columncount = gv.Rows[0].Cells.Count;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public void InsertaGestion(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {
            ad_des.insertGA_PKG_Tdetalle(ae_ga_pkg_tdetalle);
        }

        public void ActGCli(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {
            ad_des.actGcliGA_PKG_Tdetalle(ae_ga_pkg_tdetalle);
        }

        public void ActinsaGestion(AE_GA_PKG_Tdetalle ae_ga_pkg_tdetalle)
        {
            ad_des.actinsGA_PKG_Tdetalle(ae_ga_pkg_tdetalle);
        }

        public void InsertaEstado(AE_GA_PKG_Tmaestro ae_ga_pkg_tmaestro)
        {
            ad_des.insertGA_PKG_Tmaestro(ae_ga_pkg_tmaestro);
        }

        public string ValidarEstado(string factura, string opcion)
        {
            try
            {
                return ad_des.validaGA_PKG_TEstado(factura, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ConsultaEstado(string factura, string opcion)
        {
            try
            {
                return ad_des.consultaGA_PKG_TEstado(factura, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getPermisos(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            string resultado = ad_seg.getPermisos(ae_ga_seg_tpermisos);
            if (resultado == "1")
            {
                switch (ae_ga_seg_tpermisos.permiso)
                {
                    case "BTNAUTOMATICOS":
                        resultado = permiso("BTNAUTOMATICOS");
                        break;
                    case "GPACKING":
                        resultado = permiso("GPACKING");
                        break;
                    case "GBODEGA":
                        resultado = permiso("GBODEGA");
                        break;
                    case "GLOGISTICA":
                        resultado = permiso("GLOGISTICA");
                        break;
                    case "GCLIENTE":
                        resultado = permiso("GCLIENTE");
                        break;
                    default:
                        resultado = "";
                        break;
                }
            }
            else
            {
                resultado = "";
            }            
            return resultado;
        }

        private string permiso(string permiso)
        {
            string resultado = "";
            switch (permiso)
            {
                case "BTNAUTOMATICOS":
                    resultado += "<div class='process-step'> " +
                        "<button type = 'button' class='btn btn-info btn-circle' data-toggle='tab' href='#menu1'><i class='fa fa-usd fa-3x'></i></button>" +
                                "<p> " +
                                    "<small>Gestion<br /> " +
                                        "Cobranzas</small> " +
                                "</p> " +
                            "</div> " +
                            "<div class='process-step'> " +
                                "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu2'><i class='fa fa-truck fa-3x'></i></button> " +
                                "<p> " +
                                    "<small>Gestion<br /> " +
                                        "Pedido</small> " +
                                "</p> " +
                            "</div> " +
                            "<div class='process-step'> " +
                                "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu4'><i class='fa fa-file-text-o fa-3x'></i></button> " +
                                "<p> " +
                                    "<small>Gestion<br /> " +
                                        "Factura<br /> " +
                                        "Contabilizada</small> " +
                                "</p> " +
                            "</div>";
                    break;
                case "GPACKING":
                    resultado += "<div class='process-step'> " +
                        "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu5'><i class='fa fa-dropbox fa-3x'></i></button> " +
                                "<p> " +
                                   "<small>Gestion<br /> " +
                                        "PackingList</small> " +
                                "</p> " +
                            "</div>";
                    break;
                case "GBODEGA":
                    resultado += "<div class='process-step'> " +
                        "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu6'><i class='fa fa-cogs fa-3x'></i></button> " +
                                "<p> " +
                                    "<small>Gestion<br /> " +
                                        "Bodega</small> " +
                                "</p> " +
                            "</div>";
                    break;
                case "GLOGISTICA":
                    resultado += "<div class='process-step'> " +
                        "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu7'><i class='fa fa-paper-plane fa-3x'></i></button> " +
                                "<p> " +
                                    "<small>Gestion<br /> " +
                                        "Logistica</small> " +
                                "</p> " +
                            "</div>";
                    break;
                case "GCLIENTE":
                    resultado += "<div class='process-step'> " +
                        "<button type = 'button' class='btn btn-default btn-circle' data-toggle='tab' href='#menu8'><i class='fa fa-check fa-3x'></i></button> " +
                                "<p> " +
                                    "<small>Contacto<br /> " +
                                        "Cliente</small> " +
                                "</p> " +
                            "</div>";

                    break;
                default:
                    resultado = "";
                    break;
            }
            return resultado;
        }

        public void datosJson(string empresa)
        {
            string url;
            string fechaini = DateTime.Now.ToString("yyyy-MM-dd");
            string fechafin = DateTime.Now.ToString("yyyy-MM-dd");
            WebRequest wr;
            WebResponse wres;
            Stream stream;
            StreamReader streamreader;

            //modificar la url para realizar la busqueda indicada
            url = "http://ventas.iav.com.ec/json/fac/" + empresa + "/" + fechaini + "/" + fechafin + "";
            wr = WebRequest.Create(url);
            wres = wr.GetResponse();
            stream = wres.GetResponseStream();
            streamreader = new StreamReader(stream);

            //Obtenemos los datos de Cada factura
            //dynamic dynJson = jscon JsonConvert.DeserializeObject(streamreader.ReadToEnd());
            dynamic dynJson = Newtonsoft.Json.JsonConvert.DeserializeObject(streamreader.ReadToEnd());
            foreach (var item in dynJson)
            {
                //VALIDAMOS SI YA EXISTE LA FACTURA EN LA TABLA GA_PKG_Tmaestro SI EXISTE ACTUALIZA SI NO EXISTE INSERTA
                string factura = this.ValidarEstado(Convert.ToString(item.numero_factura),"1");
                if (Convert.ToInt32(factura) != 0)
                {
                    //VALIDAMOS SI YA ESTA CONTABILIZADA
                    string pedido = this.ValidarEstado(Convert.ToString(item.numero_factura), "2");
                    if (Convert.ToInt32(pedido) != 0)
                    {
                        //OBTENEMOS EL ULTIMO ESTADO DETALLE
                        string factura2 = this.ValidarEstado(Convert.ToString(item.numero_factura), "3");
                        if (Convert.ToInt32(factura2) == 1 || Convert.ToInt32(factura2) == 2)
                        {
                            //CONSULTAR IDMAESTRO INSERTAR DETALLE
                            string idmaestro = this.ConsultaEstado(Convert.ToString(item.numero_factura), "1");
                            ae_ga_pkg_tdetalle.idmaestro = Convert.ToInt32(idmaestro);
                            ae_ga_pkg_tdetalle.usuario = item.username;
                            for (int i = 3; i <= 4; i++)
                            {
                                ae_ga_pkg_tdetalle.idproceso = i;
                                if (i == 3) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = item.fechafactura; ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 4) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime("1999/01/01"); ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                                this.InsertaGestion(ae_ga_pkg_tdetalle);
                            }
                        }
                    }
                }
                if (Convert.ToInt32(factura) == 0)
                {
                    //VALIDAMOS SI YA ESTA INGRESADA SOP30200 ESTADO PACK 3 FACTURA SI EXISTE SE INGRESA CON ESTADO 3 FACTURA CONTABILIZADA
                    string pedido = this.ValidarEstado(Convert.ToString(item.numero_factura), "2");
                    if (Convert.ToInt32(pedido) != 0)
                    {
                        ae_ga_pkg_tmaestro.descripcion = "";
                        ae_ga_pkg_tmaestro.ruc = item.cliente.ruc;
                        ae_ga_pkg_tmaestro.factura = item.numero_factura;
                        ae_ga_pkg_tmaestro.fechainicio = item.fechafactura;
                        ae_ga_pkg_tmaestro.fechafin = item.fechafactura;
                        ae_ga_pkg_tmaestro.estadoinicial = 3;
                        this.InsertaEstado(ae_ga_pkg_tmaestro);
                        //CONSULTAR IDMAESTRO INSERTAR DETALLE
                        string idmaestro = this.ConsultaEstado(Convert.ToString(item.numero_factura),"1");
                        ae_ga_pkg_tdetalle.idmaestro = Convert.ToInt32(idmaestro);
                        ae_ga_pkg_tdetalle.usuario = item.username;
                        if (item.id_cobranzas != "")
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                ae_ga_pkg_tdetalle.idproceso = i;
                                if (i == 1) { ae_ga_pkg_tdetalle.documento = item.id_cobranzas; ae_ga_pkg_tdetalle.fechaInigestion = item.fechaCobranzas; ae_ga_pkg_tdetalle.fechaFingestion = item.fecha; ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 2) { ae_ga_pkg_tdetalle.documento = item.wms_id; ae_ga_pkg_tdetalle.fechaInigestion = item.fecha; ae_ga_pkg_tdetalle.fechaFingestion = item.fechafactura; ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 3) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = item.fechafactura; ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 4) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime("1999/01/01"); ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                                this.InsertaGestion(ae_ga_pkg_tdetalle);
                            }
                        }
                        if (item.id_cobranzas == "")
                        {
                            for (int i = 2; i <= 4; i++)
                            {
                                ae_ga_pkg_tdetalle.idproceso = i;
                                if (i == 2) { ae_ga_pkg_tdetalle.documento = item.wms_id; ae_ga_pkg_tdetalle.fechaInigestion = item.fecha; ae_ga_pkg_tdetalle.fechaFingestion = item.fechafactura; ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 3) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = item.fechafactura; ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 4) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = Convert.ToDateTime(this.ConsultaEstado(Convert.ToString(item.numero_factura), "2")); ae_ga_pkg_tdetalle.fechaFingestion = Convert.ToDateTime("1999/01/01"); ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                                this.InsertaGestion(ae_ga_pkg_tdetalle);
                            }
                        }
                    }
                    else
                    {
                        //Validamos si la factura tiene COBRANZAS ESTADO PACK 1
                        if (item.id_cobranzas != "")
                        {
                            ae_ga_pkg_tmaestro.descripcion = "";
                            ae_ga_pkg_tmaestro.ruc = item.cliente.ruc;
                            ae_ga_pkg_tmaestro.factura = item.numero_factura;
                            ae_ga_pkg_tmaestro.fechainicio = item.fechaCobranzas;
                            ae_ga_pkg_tmaestro.fechafin = item.fecha;
                            ae_ga_pkg_tmaestro.estadoinicial = 1;
                            this.InsertaEstado(ae_ga_pkg_tmaestro);
                            //CONSULTAR idmaestro INSERTAR DETALLE
                            string idmaestro = this.ConsultaEstado(Convert.ToString(item.numero_factura),"1");
                            ae_ga_pkg_tdetalle.idmaestro = Convert.ToInt32(idmaestro);
                            ae_ga_pkg_tdetalle.documento = item.wms_id;
                            ae_ga_pkg_tdetalle.usuario = item.username;
                            for (int i = 1; i <= 2; i++)
                            {
                                ae_ga_pkg_tdetalle.idproceso = i;
                                if (i == 1) { ae_ga_pkg_tdetalle.documento = item.id_cobranzas; ae_ga_pkg_tdetalle.fechaInigestion = item.fechaCobranzas; ae_ga_pkg_tdetalle.fechaFingestion = item.fecha; ae_ga_pkg_tdetalle.activo = 0; ae_ga_pkg_tdetalle.observacion = ""; }
                                if (i == 2) { ae_ga_pkg_tdetalle.documento = item.wms_id; ae_ga_pkg_tdetalle.fechaInigestion = item.fecha; ae_ga_pkg_tdetalle.fechaFingestion = item.fechafactura; ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                                //if (i == 3) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = item.fechafactura; ae_ga_pkg_tdetalle.fechaFingestion = DateTime.Now; ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                                this.InsertaGestion(ae_ga_pkg_tdetalle);
                            }
                        }
                        //ESTADO PACK 2 PEDIDO
                        if (item.id_cobranzas == "")
                        {
                            ae_ga_pkg_tmaestro.descripcion = "";
                            ae_ga_pkg_tmaestro.ruc = item.cliente.ruc;
                            ae_ga_pkg_tmaestro.factura = item.numero_factura;
                            ae_ga_pkg_tmaestro.fechainicio = item.fecha;
                            ae_ga_pkg_tmaestro.fechafin = item.fechafactura;
                            ae_ga_pkg_tmaestro.estadoinicial = 2;
                            this.InsertaEstado(ae_ga_pkg_tmaestro);
                            //CONSULTAR iddetalle INSERTAR DETALLE
                            string estado = this.ConsultaEstado(Convert.ToString(item.numero_factura), "1");
                            ae_ga_pkg_tdetalle.idmaestro = Convert.ToInt32(estado);
                            ae_ga_pkg_tdetalle.documento = item.wms_id;
                            ae_ga_pkg_tdetalle.usuario = item.username;
                            ae_ga_pkg_tdetalle.idproceso = 2;
                            ae_ga_pkg_tdetalle.documento = item.wms_id; ae_ga_pkg_tdetalle.fechaInigestion = item.fecha; ae_ga_pkg_tdetalle.fechaFingestion = item.fechafactura; ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; 
                            //if (i == 3) { ae_ga_pkg_tdetalle.documento = item.numero_factura; ae_ga_pkg_tdetalle.fechaInigestion = item.fechafactura; ae_ga_pkg_tdetalle.fechaFingestion = DateTime.Now; ae_ga_pkg_tdetalle.activo = 1; ae_ga_pkg_tdetalle.observacion = ""; }
                            this.InsertaGestion(ae_ga_pkg_tdetalle);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
