using AccesoDatos.WMSiav;
using AccesoEntidades.WMSiav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AccesoNegocios.WMSiav
{
    public class AN_WMS
    {
        #region VariablesGlobales
        AE_GA_WMS_Trol ae_ga_wms_trol = new AE_GA_WMS_Trol();
        AE_GA_WMS_TUsuario ae_ga_wms_tusuario = new AE_GA_WMS_TUsuario();
        AD_WMS ad_wms = new AD_WMS();
        #endregion

        #region Funciones
        public GridView GetrptVoids(string documento, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptVoids(documento, op);

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

        public GridView GetActVoids(string documento, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetActVoids(documento, op);

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

        public GridView GetrptRecepcion(string filtro, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptRecepcion(filtro, op);

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

        public DataSet GetDetPicking(string consolidado, string pedido, string producto, string opcion)
        {
            return ad_wms.GetDetPicking(consolidado, pedido, producto, opcion);
        }

        public DataSet GetPicking(int id_rol, string empresa)
        {
            return ad_wms.GetPicking(id_rol, empresa);
        }

        public DataSet GetAreasBodega(string empresa)
        {
            return ad_wms.GetAreasBodega(empresa);
        }

        public DataSet GetConteoCiclico(string empresa)
        {
            return ad_wms.GetConteoCiclico(empresa);
        }

        public DataSet GetMConteoCiclicoProdFam()
        {
            return ad_wms.GetMConteoCiclicoProdFam();
        }

        public DataSet Gettiposciudades(string empresa, string opcion)
        {
            return ad_wms.Gettiposciudades(empresa, opcion);
        }

        public DataSet GetConsolidado(string empresa, string dato, string opcion)
        {
            return ad_wms.GetConsolidado(empresa, dato, opcion);
        }

        public DataSet GetDetallePedidosLogisticaDT(string bd, string pedidos, int opcion)
        {
            return ad_wms.GetDetallePedidosLogistica(bd, pedidos, opcion);
        }

        public GridView GetDetallePedidosLogistica(string bd, string pedidos, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetDetallePedidosLogistica(bd, pedidos, opcion);

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

        public DataTable GetPackingList(string bd, string pedidos, int opcion)
        {
            return ad_wms.GetPackingList(bd, pedidos, opcion).Tables[0];
        }

        public GridView GetPedidosNoAsignados(string pedido, string ciudad, string tipo, string cliente, string empresa, string opcion)
        {
            
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetPedidosNoAsignados(pedido, ciudad,tipo,cliente,empresa, opcion);

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

        public GridView GetNE(string pedido, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetNE(pedido, opcion);

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

        public string InsGA_WMS_Tconsolidado(int id, AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario, string empresa)
        {
            try
            {
                return ad_wms.InsGA_WMS_Tconsolidado(id, ae_ga_wms_tpedusuario, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsGA_WMS_PReversaRecepcion(AE_GA_WMS_Treversas ae_ga_wms_treversas, string empresa)
        {
            try
            {
                return ad_wms.InsGA_WMS_PReversaRecepcion(ae_ga_wms_treversas, empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReimpNE(string pedido)
        {
            try
            {
                return ad_wms.ReimpNE(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void InsertPed_Usuario(AE_GA_WMS_TPedusuario ae_ga_wms_tpedusuario)
        {
            try
            {
                ad_wms.InsGA_WMS_TPedusuario(ae_ga_wms_tpedusuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string InsGA_WMS_Treversas(AE_GA_WMS_Treversas ae_ga_wms_treversas, string opcion)
        {
            try
            {
                return ad_wms.InsGA_WMS_Treversas(ae_ga_wms_treversas, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsCodAlt(AE_GA_WMS_Talterno ae_ga_wms_talterno)
        {
            try
            {
                ad_wms.InsCodAlt(ae_ga_wms_talterno);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsimpNE(string pedidos, string usuario, string empresa)
        {
            try
            {
                ad_wms.InsimpNE(pedidos, usuario, empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void InsRutaSugerida(string empresa, string usuario, string consolidado)
        {
            try
            {
                ad_wms.InsRutaSugerida(empresa, usuario, consolidado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetPedidosArmados(string pedido, string opcion)
        {
            return ad_wms.GetPedidosArmados(pedido, opcion);
        }

        public DataSet GetCodAlt(string producto, string empresa)
        {
            return ad_wms.GetCodAlt(producto,empresa);
        }

        public void PedidosArmados()
        {
            //Llenar Informacion
            DataSet dsp = new DataSet();
            dsp = this.GetPedidosArmados("","1");
            DataTable dt = dsp.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                string pedido = Convert.ToString(row["PEDIDO"]);
                this.GetPedidosArmados(pedido, "2");
            }
        }

        public string UpTlogistica(AE_GA_WMS_Tlogistica ae_ga_wms_tlogistica)
        {
            try
            {
                return ad_wms.UpTlogistica(ae_ga_wms_tlogistica);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpCerrarProd(string numconsolidado, string pedido, string producto, string coordenada, string observacion, string usuarioanula)
        {
            try
            {
                return ad_wms.UpCerrarProd(numconsolidado, pedido, producto, coordenada, observacion, usuarioanula);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string getConsolidadoMax(string empresa, string dato, string opcion)
        {
            try
            {
                return ad_wms.getConsolidadoMax(empresa, dato, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string getValidaarmado(string pedido, string producto, int opcion)
        {
            try
            {
                return ad_wms.getValidaarmado(pedido, producto, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AnulaPedidoV2(string pedido, string observacion, string usuario)
        {
            try
            {
                return ad_wms.AnulaPedidoV2(pedido,observacion,usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView getPedidosReversa(string pedido, string empresa, string opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.getPedidosReversa(pedido, empresa, opcion);

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

        public GridView getCierrePicking(string dato, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.getCierrePicking(dato, opcion);

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

        public string getCoorPedvalida(string coordenada, string pedido, string tipocoor, string opcion)
        {
            try
            {
                return ad_wms.getCoorPedvalida(coordenada,pedido,tipocoor,opcion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetValidaProd(string alterno, string producto, string empresa, int opcion)
        {
            try
            {
                return ad_wms.GetValidaProd(alterno, producto, empresa, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdatePedidoConsol(string numconsolidado, string pedido)
        {
            try
            {
                return ad_wms.UpdatePedidoConsol(numconsolidado, pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string AnulaPedido(string pedido, int opcion)
        {
            try
            {
                return ad_wms.AnulaPedido(pedido, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string Claves(string modulo, string clave)
        {
            try
            {
                return ad_wms.Claves(modulo, clave);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetEstadoPedido(string dato1, string dato2, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetEstadoPedido(dato1, dato2, opcion);

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

        public GridView GetPendxEmpacar(string filtro, string area, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetPendxEmpacar(filtro, area, opcion);

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

        public GridView GetEstadoPedidoFecha(string dato1, string dato2, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetEstadoPedidoFecha(dato1, dato2, opcion);

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

        public GridView GetKardex(string dato1, string dato2, string dato3, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetKardex(dato1, dato2, dato3, opcion);

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

        public GridView GetUbicaProducto(string dato, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetUbicaProducto(dato, opcion);

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

        public GridView GetUbicaProductoCuarentena(string dato, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetUbicaProductoCuarentena(dato, opcion);

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

        public string GetDetallePed(string pedido)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_wms.GetDetallePed(pedido);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["pedido"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["producto"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidad"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["marca"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["stockWMS"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }

        public DataSet GetDetallePedGrid(string pedido)
        {
            return ad_wms.GetDetallePed(pedido);
        }

        public GridView GetrptResumenDiario(string fdesde, string fhasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptResumenDiario(fdesde, fhasta);

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

        public GridView GetrptResumenDiarioXProceso(string fdesde, string fhasta, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptResumenDiarioXProceso(fdesde, fhasta, opcion);

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

        public GridView getRacksxArea(int idmaestrocc, string area, string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.getRacksxArea(idmaestrocc, area, empresa);

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

        public string InsAsigCCMaestro(AE_GA_CC_TMaestroCC ae_ga_cc_tmaestrocc, int opcion)
        {
            try
            {
                return ad_wms.InsAsigCCMaestro(ae_ga_cc_tmaestrocc, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsAsigCCDetalle(AE_GA_CC_TDetalleCC ae_ga_cc_tdetallecc, int opcion)
        {
            try
            {
                return ad_wms.InsAsigCCDetalle(ae_ga_cc_tdetallecc, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetDetConteo(string dato, string idmaestro, string empresa, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetDetConteo(dato, idmaestro, empresa, opcion);

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

        public string UpVaciarCoordenada(string coordenada, int idmaestro, string producto, string empresa, int opcion)
        {
            try
            {
                return ad_wms.UpVaciarCoordenada(coordenada, idmaestro, producto, empresa, opcion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GridView GetDifeConteo(int idmaestro, string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetDifeConteo(idmaestro, empresa);

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

        public string InsGA_CC_PInsReconteoCab(AE_GA_CC_TReconteo ae_ga_cc_treconteo)
        {
            try
            {
                return ad_wms.InsGA_CC_PInsReconteoCab(ae_ga_cc_treconteo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpCantCoor(int dato, string coordenada, string producto, string usuario, string empresa, int idmaestro)
        {
            try
            {
                return ad_wms.UpCantCoor(dato, coordenada, producto, usuario, empresa, idmaestro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string AbrirCoor(string coordenada, string empresa, int idmaestro)
        {
            try
            {
                return ad_wms.AbrirCoor(coordenada, empresa, idmaestro);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GridView GetAvanceCCxUsuario(string filtro, int op)
        {

            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetAvanceCCxUsuario(filtro, op);

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

        public GridView GetRepConteo(string filtro, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetRepConteo(filtro, op);

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

        public string UpdateTraspasos(string traspaso)
        {
            try
            {
                return ad_wms.UpdateTraspasos(traspaso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateTraspasosOUTLET(string traspaso)
        {
            try
            {
                return ad_wms.UpdateTraspasosOUTLET(traspaso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ValidaTrapasos(string traspaso)
        {
            try
            {
                return ad_wms.ValidaTraspasos(traspaso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ArreglaNE(string pedido)
        {
            try
            {
                return ad_wms.ArreglaNE(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CerrarOC(string oc)
        {
            try
            {
                return ad_wms.CerrarOC(oc);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ForzarPed(string pedido)
        {
            try
            {
                return ad_wms.ForzarPed(pedido);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SubirPVC(string factura)
        {
            try
            {
                return ad_wms.SubirPVC(factura);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SubirNC(string devolucion)
        {
            try
            {
                return ad_wms.SubirNC(devolucion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SubirRecepcionOC(string orden)
        {
            try
            {
                return ad_wms.SubirRecepcionOC(orden);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public GridView GetBultosxUsuario(string usuario)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetBultosxUsuario(usuario);

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

        public GridView GetConspenxUsuario()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetConspenxUsuario();

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

        public string InsObsCierre(string observacion)
        {
            try
            {
                return ad_wms.InsObsCierre(observacion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetCantReversa(string consolidado, string pedido, string producto, int opcion)
        {
            try
            {
                return ad_wms.GetCantReversa(consolidado, pedido, producto, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetWMSvsGP(int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetWMSvsGP(op);

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

        public GridView GetPedpenxFact(int anio, int mes)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetPedpenxFact(anio, mes);

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

        public GridView GetRPT_PTiemposWMS(string fdesde, string fhasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetRPT_PTiemposWMS(fdesde, fhasta);

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

        public GridView GetRPT_PTiemposWMSresumen(string fdesde, string fhasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetRPT_PTiemposWMSresumen(fdesde, fhasta);

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

        public GridView GetWMSvsGPIAV()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetWMSvsGPIAV();

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

        public string InsItemRecepcion(string numerodocumento, string codigoproducto, int cantidad)
        {
            try
            {
                return ad_wms.InsItemRecepcion(numerodocumento,codigoproducto,cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMotivosReversa(int opcion)
        {
            return ad_wms.GetMotivosReversa(opcion);
        }

        public DataSet GetCCproductofamilia(int op, string dato)
        {
            return ad_wms.GetCCproductofamilia(op, dato);
        }

        public DataSet GetUsuAsig(string dato, int op)
        {
            return ad_wms.GetUsuAsig(dato, op);
        }

        public string InsConteoCiclico(int op, string tipo, string documento, int cantidad, string codigoproducto, string descripcion,
            string observacion, string origen, string empresa, int idcc, string usuario, string usuarioasigna)
        {
            try
            {
                return ad_wms.InsConteoCiclico(op, tipo, documento, cantidad, codigoproducto, descripcion, observacion, origen, empresa, idcc, usuario, usuarioasigna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsConteoCiclicoCuarentena(int op, string tipo, string documento, int cantidad, string codigoproducto, string descripcion,
            string observacion, string origen, string empresa, int idcc, string usuario, string usuarioasigna)
        {
            try
            {
                return ad_wms.InsConteoCiclicoCuarentena(op, tipo, documento, cantidad, codigoproducto, descripcion, observacion, origen, empresa, idcc, usuario, usuarioasigna);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ExportarGP(int maestro)
        {
            try
            {
                return ad_wms.ExportarGP(maestro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ExportarGPCuarentena(int maestro)
        {
            try
            {
                return ad_wms.ExportarGPCuarentena(maestro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetCCReportes(string filtro, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetCCReportes(filtro, op);

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

        public GridView GetNoStock(string dato1, string dato2, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetNoStock(dato1, dato2, opcion);

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

        public GridView GetrptReversas(string dato1, string dato2, int op, string pedido)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptReversas(dato1, dato2, op, pedido);

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

        public GridView GetrptAnulaciones(string dato1, string dato2, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetrptAnulaciones(dato1, dato2, op);

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

        public string DarCoordenada(string producto, string empresa, string consolidado)
        {
            try
            {
                return ad_wms.DarCoordenada(producto, empresa, consolidado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //PEDIDO LOGISTICA-OBTENER DATOS
        public DataSet GetPedidoLogistica(string pedido)
        {
            return ad_wms.GetPedidoLogistica(pedido);
        }

        public GridView GetDetallePedidoLogistica(string pedido)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetDetallePedidoLogistica(pedido);

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

        //PEDIDO LOGISTICA-INGRESAR DATOS
        public string InsPreciboLogistica(string pedido, string usuario)
        {
            try
            {
                return ad_wms.InsRecibimientoLogistica(pedido, usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetComprometidos(string dato1, string dato2, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetComprometidos(dato1, dato2, opcion);

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

        public string ActVoids(int id, string codigo_void, int op)
        {
            try
            {
                return ad_wms.ActVoids(id, codigo_void, op);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getCierrePickingTipo(string dato, int opcion)
        {
            return ad_wms.getCierrePicking(dato, opcion);
        }

        public GridView GetConteoDetallado(int op, string dato)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetConteoDetallado(op, dato);

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

        public GridView GetStock64()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetStock64();

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

        public GridView GetTiemposWMS(string fdesde, string fhasta, string prioridad, string ciudad, int items)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetTiemposWMS(fdesde, fhasta, prioridad, ciudad, items);

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

        public string InsArreglarArmado(string pedido, string codigoproducto, int cantidad)
        {
            try
            {
                return ad_wms.InsArreglarArmado(pedido, codigoproducto, cantidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AsigFamilia(string producto, string familia, int op)
        {
            try
            {
                return ad_wms.AsigFamilia(producto, familia, op);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetPendxFamilia(int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetPendxFamilia(op);

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

        public GridView GetRecepcionNE(string desde, string hasta, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.GetRecepcionNE(desde, hasta, opcion);

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

        public string Getstockiavec(string pedido)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_wms.Getstockiavec(pedido);
            if (dsp.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsp.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    tabla += "<tr>";
                    tabla += "<td>" + Convert.ToString(row["PEDIDO"]) + "</td>";
                    tabla += "<td>" + Convert.ToString(row["CODIGO"]) + "</td>";
                    tabla += "<td>" + Convert.ToString(row["DESCRIPCION"]) + "</td>";
                    tabla += "<td>" + Convert.ToString(row["CantSolicitada"]) + "</td>";
                    tabla += "<td>" + Convert.ToString(row["StockWMS"]) + "</td>";
                    tabla += "</tr>";
                }
            }
            else
            {
                tabla = "vacio";
            }
            return tabla;
        }

        /// <summary>
        /// OBTENER EL DETALLE DE LOS BULTOS POR PEDIDO PARA EL MODULO CONSOLIDADO DE BULTO
        /// </summary>
        public GridView getBultosxPedido(string pedido, int idbulto, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wms.getBultosxPedido(pedido, idbulto, op);

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

        /// <summary>
        /// OBTENER EL CONTENIDO DE LOS BULTOS POR PEDIDO PARA EL MODULO CONSOLIDADO DE BULTO
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public string getDetBultosxPedido(string pedido, int idbulto)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_wms.getBultosxPedido(pedido, idbulto, 2);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["pedido"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["idbulto"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["producto"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cant_armar"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }

        /// <summary>
        /// CREAR CONSOLIDADOS DE BULTOS
        /// 
        public string insConsolidadosBultos(string pedido, int idbulto, string usuario, int op)
        {
            try
            {
                return ad_wms.insConsolidadosBultos(pedido, idbulto, usuario, op);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// IMPRIMIR NOTA DE ENTREGA MODULO CONSOLIDADO DE BULTOS
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public DataTable GetPackingListConsBultos(string pedido)
        {
            try
            {
                return ad_wms.GetPackingListConsBultos(pedido).Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
