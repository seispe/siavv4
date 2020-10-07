using AccesoDatos.GP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AccesoNegocios.GP
{
    public class AN_Cobranzas
    {
        #region Variables Globales
        AD_Cobranzas ad_cobranzas = null;
        #endregion

        #region Constructor
        public AN_Cobranzas(string empresa)
        {
            ad_cobranzas = new AD_Cobranzas(empresa);
        }
        #endregion

        #region Funciones
        public string insClientesDoc(int idsolicitud, string ruc, string cliente, string ven, DateTime fsolicitud, DateTime frecibo, string usuario, string observacion, int op)
        {
            try
            {
                return ad_cobranzas.insClientesDoc(idsolicitud, ruc, cliente, ven, fsolicitud, frecibo, usuario, observacion, op);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void insDocumentos(int idcliente, string ruc, string cliente, string ven, int documento, string usuario,string observacion, int op)
        {
            try
            {
                ad_cobranzas.insDocumentos(idcliente, ruc, cliente, ven, documento, usuario,observacion, op);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GridView GetListadoDoc(int idsolicitud, string dato1, string tipo, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetListadoDoc(idsolicitud, dato1, tipo, op);

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

        public GridView LlenarGrid(string cliente, string vendedor, string ciudad,string fechaEmision,string fechaVencimiento)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetEstadoCuenta(cliente, vendedor, ciudad,fechaEmision,fechaVencimiento);

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

        public GridView GridChqPostfechados(string cliente, string vendedor, string ciudad, string fechaEmision, string fechaVencimiento)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetChqPostfechados(cliente, vendedor, ciudad, fechaEmision, fechaVencimiento);

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

        public GridView GridChqProtestados(string cliente, string vendedor, string ciudad, string fechaEmision, string fechaVencimiento)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetChqProtestados(cliente, vendedor, ciudad, fechaEmision, fechaVencimiento);

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

        public GridView rpt_cuentasxcobrar(string empresa, string fecha)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetCuentasxCobrar(empresa, fecha);

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

        public GridView rpt_cuentasxpagar(string empresa, string fecha)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.GetCuentasxPagar(empresa, fecha);

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

        public DataSet generarCSV(string cliente, string vendedor, string ciudad,string fechaEmision, string fechaVencimiento)
        {
            DataSet dsp = new DataSet();

            dsp = ad_cobranzas.GetEstadoCuenta(cliente, vendedor,ciudad,fechaEmision,fechaVencimiento);
            
            return dsp;
        }

        /// <summary>
        /// REPORTE DE RECAUDACIONES CABECERA, DETALLE DE CLIENTES
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataTable GetRecaudacionesV1(string desde, string hasta, string bases)
        {
            return ad_cobranzas.GetRecaudacionesV1(desde, hasta, bases).Tables[0];
        }

        /// <summary>
        /// REPORTE DE RECAUDACIONES, DETALLE CHEQUES INGRESADOS POR CLIENTE
        /// </summary>
        /// <param name="ruc"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataTable GetRecaudacionesV2(string ruc, string desde, string hasta, string bases)
        {
            return ad_cobranzas.GetRecaudacionesV2(ruc, desde, hasta, bases).Tables[0];
        }

        /// <summary>
        /// REPORTE DE RECAUDACIONES, DETALLE DE FACTURAS APLICADAS
        /// </summary>
        /// <param name="ruc"></param>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="bases"></param>
        /// <returns></returns>
        public DataTable GetRecaudacionesV3(string ruc, string desde, string hasta, string bases)
        {
            return ad_cobranzas.GetRecaudacionesV3(ruc, desde, hasta, bases).Tables[0];
        }

        public GridView Getrpt_chequesProt(string empresa, string fechai, string fechaf)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.Getrpt_chequesProt(empresa, fechai, fechaf);

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

        public GridView Getrpt_chequesPosfNoDepo(string empresa, string fechai, string fechaf)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.Getrpt_chequesPosfNoDepo(empresa, fechai, fechaf);

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

        public GridView Getrpt_chequesPosfDepo(string empresa, string fechai, string fechaf)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_cobranzas.Getrpt_chequesPosfDepo(empresa, fechai, fechaf);

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
        #endregion
    }
}
