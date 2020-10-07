/****************************************************************
-- Titulo:  Acceso Negocios de OrdenCompra
-- Author:  Gabriel Reyes
-- Fecha:   26/06/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using AccesoDatos.Devoluciones;
using AccesoDatos.OrdenCompra;
using AccesoEntidades.Devoluciones;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.OrdenCompra
{
    public class AN_OrdenCompra
    {
        #region Variables Globales
        AD_OCL ad_ocl = new AD_OCL();
        #endregion

        #region Constructor
        public AN_OrdenCompra()
        {
        }

        #endregion

        #region Funciones
        /// <summary>
        /// Funcion Llenar grid de acuerdo al estado de la devolucion
        /// </summary>
        /// <param name="empresa">Base Empresa</param>
        /// <param name="estado">Estado Devolucion</param>
        /// <returns></returns>
        public GridView getfacturas(string empresa,string buscar)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_ocl.getFacturas(empresa, buscar);

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

        public string GetDetalleFac(string factura, string empresa)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_ocl.GetDetalleFac(factura, empresa);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["CODFACTURA"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["CODALL"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }

        public void setFacturas()
        {
            ad_ocl.setFacturas();
        }

        public string setOrdenCompra(string empresa, string factura,string bodega,string usuariogp)
        {
            string resultado = "";
            resultado = ad_ocl.setOrdenCompra(empresa,factura,bodega,usuariogp);
            return resultado;
        }
        #endregion
    }
}
