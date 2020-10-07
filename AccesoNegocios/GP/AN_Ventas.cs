using AccesoDatos.GP;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.GP
{
    public class AN_Ventas
    {
        #region Variables Globales
        AD_Ventas ad_ventas = null;
        #endregion

        #region Constructor
        public AN_Ventas(string empresa)
        {
            ad_ventas = new AD_Ventas(empresa);
        }
        #endregion

        #region Funciones
        public GridView rpt_ventas_vendedorlinea(string empresa, string fecha1, string fecha2, string vendedor, string linea, int tipo)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.Getventas_vendedorlinea(empresa, fecha1, fecha2, vendedor, linea, tipo);

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
        public GridView rptLineas(string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetLineas(empresa);

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
        public GridView rpt_ventas_vendedor_linea_mensual(string empresa, string fecha)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.Get_Ventas_vendedor_linea_mensual(empresa, fecha);

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
        public GridView rpt_clientes_con_deuda(string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetClientes_con_deuda(empresa);

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
        public GridView rpt_clientes_cupos(string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetClientes_cupos(empresa);

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

        public GridView getPorDespachar(string empresa)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetPorDespachar(empresa);

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

        public GridView GetVtasxItems(string empresa, string fechaDesde, string fechaHasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasxItems(empresa, fechaDesde, fechaHasta);

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

        public GridView GetVtasxLineas(string fdesde, string fhasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasxLineas(fdesde,fhasta);

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

        public DataSet GetVenSup(string dato1, string dato2, string dato3, int op, string dato4)
        {
            return ad_ventas.GetVenSup(dato1, dato2, dato3, op, dato4);
        }

        public string GetPerSup(string dato1, string dato2, string dato3, int op, string dato4)
        {
            try
            {
                return ad_ventas.GetPerSup(dato1, dato2, dato3, op, dato4);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetVtasxFecha(string desde, string hasta)
        {
            return ad_ventas.GetVtasxFecha(desde, hasta).Tables[0];
        }

        public GridView GetVtasxFechaEx(string desde, string hasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasxFecha(desde, hasta);

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

        public GridView GetVtasxCliVen(string ruc, string desde, string hasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasxCliVen(ruc, desde, hasta);

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

        public GridView GetVtasCostoLogistico(string desde, string hasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasCostoLogistico(desde, hasta);

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

        public GridView GetVtasCostoLogisticoPVG(string desde, string hasta)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ventas.GetVtasCostoLogisticoPVG(desde, hasta);

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
        #endregion
    }
}
