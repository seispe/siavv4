﻿using AccesoDatos.GP;
using System.Data;
using System.Web.UI.WebControls;
using System;

namespace AccesoNegocios.GP
{
    public class AN_Compras
    {
        #region Variables Globales
        AD_Compras ad_compras = null;
        #endregion

        #region Constructor
        public AN_Compras(string empresa)
        {
            ad_compras = new AD_Compras(empresa);
        }
        #endregion

        #region Funciones
        public GridView rpt_costodescarga(string empresa, string fechaInicial, string fechaFinal)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetCostosDescarga(empresa, fechaInicial, fechaFinal);

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
        public GridView rpt_rendimientos(string empresa, string fecha)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetRendimientos(empresa, fecha);

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
        public GridView rpt_listaprecios(string empresa, string proveedor, string codigo, string descripcion, string marca)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetListaPreciosNOAsociados(empresa, proveedor, codigo, descripcion, marca);

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

        public GridView rpt_recibimientoWMS(string empresa, string ordenCompra)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            switch (empresa)
            {
                case "GPIAV":
                    empresa = "01";
                    break;
                case "GPCAL":
                    empresa = "03";
                    break;
                default:
                    empresa = "01";
                    break;
            }

            dsp = ad_compras.GetRecibimientoWMS(empresa, ordenCompra);

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
        public GridView rpt_ordencompraGPWMS(string empresa, string ordenCompra)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();
            
            dsp = ad_compras.GetOrdenCompraWMSGP(empresa, ordenCompra);

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

        public GridView GetProveedores(string dato, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetProveedores(dato, opcion);

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

        public GridView GetRotacion(int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetRotacion(op);

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

        public GridView GetPedidosCao()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetPedidosCao();

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

        public DataSet GetDetalleFacturaDtos(int op, string dato)
        {
            return ad_compras.GetDetalleFacturaDtos(op, dato);
        }

        public GridView GetGVDetalleFacturaDtos(int op, string dato)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_compras.GetDetalleFacturaDtos(op, dato);

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

        public string InsDtosMercaderia(string secuencial, string ruc, string cliente, string factura, DateTime ffactura, string item, string descripcion, int cantingreso,
                                         decimal porcentajeingreso, int cantfactura, decimal precioUnit, decimal dtoItem, decimal precioTotal, string codvend)
        {
            try
            {
                return ad_compras.InsDtosMercaderia(secuencial, ruc, cliente, factura, ffactura, item, descripcion, cantingreso, porcentajeingreso, cantfactura, precioUnit, dtoItem, precioTotal, codvend);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string InsDtosMercaderiaCAL(string secuencial, string bodega, string ruc, string cliente, string factura, DateTime ffactura, string item, string descripcion, int cantingreso,
                                        decimal porcentajeingreso, int cantfactura, decimal precioUnit, decimal dtoItem, decimal precioTotal, string codvend)
        {
            try
            {
                return ad_compras.InsDtosMercaderiaCAL(secuencial,bodega, ruc, cliente, factura, ffactura, item, descripcion, cantingreso, porcentajeingreso, cantfactura, precioUnit, dtoItem, precioTotal, codvend);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CorreoDtoMercaderia(string secuencial)
        {
            try
            {
                return ad_compras.CorreoDtoMercaderia(secuencial);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string SecuencialDtoMercaderia(int op)
        {
            try
            {
                return ad_compras.SecuencialDtoMercaderia(op);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
