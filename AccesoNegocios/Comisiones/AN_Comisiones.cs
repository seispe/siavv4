/****************************************************************
-- Titulo:  Acceso Negocios de Comisiones
-- Author:  Gabriel Reyes
-- Fecha:   26/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoDatos.Comisiones;
using AccesoEntidades.Comisiones;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.Comisiones
{
    public class AN_Comisiones
    {
        #region Variables Globales
        AD_COM ad_com;
        #endregion

        #region Constructor
        public AN_Comisiones(string empresa)
        {
            ad_com = new AD_COM(empresa);
        }

        #endregion

        #region Funciones
        public GridView GetConfigComi()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_com.GetConfigComi();

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

        public GridView GetConfigVendedor(string vendedor)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_com.GetConfigVendedor(vendedor);

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

        public GridView GetComision(string vendedor,string mes,string año,string tipo)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_com.GetComision(vendedor,mes,año,tipo);

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

        public DataSet getVendedores()
        {
            return ad_com.GetVendedores();
        }

        public void ModificarValor(string idconfig, string valor)
        {
            ad_com.setComiConfig(idconfig, valor);          
        }

        public string putNuevoCalculo(AE_GA_COM_Tpagada_calc ae_ga_com_tpagada_calc)
        {
            return ad_com.putNuevoCalculo(ae_ga_com_tpagada_calc);
        }

        public string editCalculo(AE_GA_COM_Tpagada_calc ae_ga_com_tpagada_calc)
        {
            return ad_com.editCalculo(ae_ga_com_tpagada_calc);
        }

        public string getExisteRegistro(string vendedor, string mes, string año)
        {
            string resultado = "";
            resultado = ad_com.getExisteRegistro(vendedor,mes,año);
            return resultado;
        }

        public string getExisteComision(string vendedor, string mes, string año)
        {
            string resultado = "";
            resultado = ad_com.getExisteComision(vendedor, mes, año);
            return resultado;
        }

        public string setComision(string vendedor, string mes, string año)
        {
            string resultado = "";
            resultado = ad_com.setComision(vendedor, mes, año);
            return resultado;
        }
        #endregion
    }
}
