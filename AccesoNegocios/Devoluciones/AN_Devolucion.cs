/****************************************************************
-- Titulo:  Acceso Negocios de Devoluciones
-- Author:  Gabriel Reyes
-- Fecha:   02/05/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoDatos.Devoluciones;
using AccesoEntidades.Devoluciones;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.Devoluciones
{
    public class AN_Devolucion
    {
        #region Variables Globales
        AD_DEV ad_dev;
        #endregion

        #region Constructor
        public AN_Devolucion(string empresa)
        {
            ad_dev = new AD_DEV(empresa);
        }

        #endregion

        #region Funciones
        public GridView GetrptVoids(string documento, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetrptVoids(documento, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView GetrptVoidsPVQ(string documento, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetrptVoidsPVQ(documento, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView GetItemDV(string iddevolucion, string producto, string empresa, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetItemDV(iddevolucion, producto, empresa, opcion);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        /// <summary>
        /// Funcion Llenar grid de acuerdo al estado de la devolucion
        /// </summary>
        /// <param name="empresa">Base Empresa</param>
        /// <param name="estado">Estado Devolucion</param>
        /// <returns></returns>
        public GridView LlenarGrid(string empresa, string estado, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDevoluciones(empresa, estado, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }
        /// <summary>
        /// Funcion Busca items por # de iddevolucion
        /// </summary>
        /// <param name="empresa">Base empresa</param>
        /// <param name="iddevolucion">iddevolucion</param>
        /// <returns></returns>
        public GridView LlenarGrid(string empresa, int iddevolucion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDevoluciones(empresa, iddevolucion);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public DataSet LlenarMotivos()
        {
            DataSet dsp = new DataSet();

            dsp = ad_dev.GetMotivos();

            return dsp;
        }

        public string ModificarEstado(string empresa, string iddevolucion, string estado, string usuario, string observacion)
        {
            string resultado = "";
            switch (estado)
            {
                case "1":
                    ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                    if (empresa != "GPTRA" && empresa != "GPPKR")
                    {
                        ad_dev.setDevolucionWMS(empresa); //Descomentar para que se vayan al WMS las devoluciones
                    }
                    break;
                case "2": //ENVIAR A GP DEVOLUCIONES DE PROKAR
                    resultado = ad_dev.setDevolucionGP(iddevolucion); //Descomentar para que se vayan al GP las devoluciones
                    if (resultado.Trim().Length < 18)
                    {
                        ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                    }
                    break;
                case "3":
                    if (empresa == "GPPKR")
                    {
                        ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                    }
                    else
                    {
                        resultado = ad_dev.setDevolucionGP(iddevolucion); //Descomentar para que se vayan al GP las devoluciones
                        if (resultado.Trim().Length < 18)
                        {
                            ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                        }
                    }
                    break;
                case "4":
                    ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                    //ad_dev.setDevolucionGP(empresa); //Descomentar para que se vayan al GP las devoluciones
                    break;
                default:
                    ad_dev.setDevolucionEstado(empresa, iddevolucion, estado, usuario, observacion);
                    break;
            }
            return resultado;
        }

        public string getCorreoClienteDevolucion(string empresa, string iddevolucionn)
        {
            string resultado = ad_dev.getDevolucionGPCorreo(empresa, iddevolucionn);
            return resultado;
        }
        public GridView DetalleDevolucion(string empresa, string iddevolucion)
        {
            GridView gv = new GridView();
            DataSet dsp = new DataSet();
            dsp = ad_dev.GetDetalleDevoluciones(empresa, iddevolucion);
            gv.DataSource = dsp;
            return gv;
        }

        public string tablaDevolucion(string empresa, string iddevolucion)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_dev.GetDetalleDevoluciones(empresa, iddevolucion);
            DataTable dt = dsp.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["articulo"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidadOriginal"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidadReal"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["motiOriginal"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["motiRealTexto"]) + "</td>";
                tabla += "</tr>";
            }

            return tabla;
        }

        public string tablaDetalleFactura(string idweb)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_dev.GetDetalleFactura(idweb);
            DataTable dt = dsp.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["pedido"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["fechaFactura"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["ciudad"]) + "</td>";
                tabla += "</tr>";
            }

            return tabla;
        }

        public string tablaFactura(string empresa, string factura)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_dev.GetDetalleFactura(empresa, factura);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["articulo"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidad"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }

        public string tablaDetDevRechazadas(string iddevolucion)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_dev.GetDetalleDevolucionesRechazadas(iddevolucion);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["articulo"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidadOriginal"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["motivoOriginal"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }

        public string EnvioLogistica(string devolucion, string usuario, int op)
        {
            try
            {
                return ad_dev.EnvioLogistica(devolucion, usuario, op);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void actualizarDetalle(AE_GA_DEV_Tdevoldetalle ae_ga_dev_tdevoldetalle)
        {
            ad_dev.actualizarDetalle(ae_ga_dev_tdevoldetalle);
        }

        public void UpdateMotivos()
        {
            ad_dev.setUpdateMotivos();
        }

        public void UpdateEstados()
        {
            ad_dev.setUpdateEstados();
        }

        public GridView rpt_porretirar(string empresa, string fechaDesde, string fechaHasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_porretirar(empresa, fechaDesde, fechaHasta);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView rpt_estado(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion, string vendedor)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_estado(empresa, fechaDesde, fechaHasta, cliente, iddevolucion, vendedor);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView rpt_pormotivo(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_pormotivo(empresa, fechaDesde, fechaHasta, cliente, iddevolucion);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView rpt_pormotivoNC(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_pormotivoNC(empresa, fechaDesde, fechaHasta, cliente, iddevolucion);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView rpt_pordia(string empresa, string fechaDesde, string fechaHasta, string cliente, string iddevolucion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_pordia(empresa, fechaDesde, fechaHasta, cliente, iddevolucion);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView Getrpt_picadaslog(string dato1, string dato2, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_picadaslog(dato1, dato2, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView Getrpt_devrechazadas(string dato1, string dato2, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.Getrpt_devrechazadas(dato1, dato2, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView GetDetFactCarta(string factura, string codigo, string guia, DateTime fcourier, string usuario, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDetFactCarta(factura, codigo, guia, fcourier, usuario, op);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public DataTable GetFactCarta(string factura)
        {
            return ad_dev.GetDetFactCarta(factura, "", "", DateTime.Now, "", 3).Tables[0];
        }

        public string setCierreItemDV(string iddevolucion, string producto, string empresa, int opcion)
        {
            try
            {
                return ad_dev.setCierreItemDV(iddevolucion, producto, empresa, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GridView GetDV64(string dato1, string dato2, string empresa, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDV64(dato1, dato2, empresa, opcion);

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

        public GridView GetDV64Unamuncho(string dato1, string dato2, string empresa, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDV64Unamuncho(dato1, dato2, empresa, opcion);

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

        public string GetDetalle(string documento, int op)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = dsp = ad_dev.GetrptVoids(documento, op);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["id"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["producto"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["void"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cant"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["pedido"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["factura"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["fecha_factura"]) + "</td>";

                tabla += "</tr>";
            }
            return tabla;
        }

        public string GetDetallePVQ(string documento, int op)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = dsp = ad_dev.GetrptVoidsPVQ(documento, op);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["id"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["producto"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["void"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cant"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["pedido"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["factura"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["fecha_factura"]) + "</td>";

                tabla += "</tr>";
            }
            return tabla;
        }

        public void InsCodCartServ(string factura, string cliente, string codigo, string descripcion, int cantidad, string guia, string fcourier, DateTime fdev, string usuario, int op)
        {
            try
            {
                ad_dev.InsCodCartServ(factura, cliente, codigo, descripcion, cantidad, guia, fcourier, fdev, usuario, op);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GridView GetDVCourierTRA(string dato1, string dato2, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDVCourierTRA(dato1, dato2, opcion);

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

        public GridView GetDVEliminadas(string dato1, string dato2)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDVEliminadas(dato1, dato2);

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

        public int cargarExcel(DataTable tabla)
        {
            return ad_dev.cargarExcel(tabla);
        }

        public GridView GetDVCompensaciones(int devolucion, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDVCompensaciones(devolucion, op);

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

        public void setDVCompensaciones(int devolucion, string articulo, int cantCompensada,
                string observacionCompensada, int cantNoCompensada, string observacionNoCompensada, string usuario, int op)
        {
            ad_dev.setDVCompensaciones(devolucion, articulo, cantCompensada, observacionCompensada, cantNoCompensada, observacionNoCompensada, usuario, op);
        }

        public string generaTraspasos(string tipodocumento, string usuario, string motivo)
        {
            return ad_dev.generaTraspasos(tipodocumento, usuario, motivo);
            
        }

        public GridView GetrptTraspasos(int op, string dato1, string dato2)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetrptTraspasos(op, dato1, dato2);

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
                gv.AutoGenerateColumns = false;
                gv.Rows[0].Cells.Clear();
                gv.Rows[0].Cells.Add(new TableCell());
                gv.Rows[0].Cells[0].ColumnSpan = columncount;
                gv.Rows[0].Cells[0].Text = "No se encuentra datos";
            }
            return gv;
        }

        public GridView GetDVingresoMotivos(int devolucion, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_dev.GetDVingresoMotivos(devolucion, op);

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

        public void setDVingresoMotivos(int devolucion, string articulo, int cantFallaFabrica,
               string observacionFallaFabrica, int cantCuarentena, string observacionCuarentena, string usuario, int op)
        {
            ad_dev.setDVingresoMotivos(devolucion, articulo, cantFallaFabrica, observacionFallaFabrica, cantCuarentena, observacionCuarentena, usuario, op);
        }
        #endregion
    }
}
