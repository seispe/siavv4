using AccesoDatos.Autorizaciones;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.Autorizaciones
{
    public class AN_Autorizaciones
    {
        #region VariablesGlobales
        AD_AUT ad_aut;
        #endregion

        #region Constructor
        public AN_Autorizaciones(string empresa)
        {
            ad_aut = new AD_AUT(empresa);
        }
        #endregion

        #region Funciones
        public GridView GetFacturas(int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_aut.GetFacturas(opcion);

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

        public GridView GetAjustes(string ajuste, int opcion)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_aut.GetAjustes(ajuste, opcion);

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

        public string setAprobarAjustes(int id, string ajuste, int opcion)
        {
            try
            {
                return ad_aut.setAprobarAjustes(id, ajuste, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string setAprobarFacturas(string factura, int opcion)
        {
            try
            {
                return ad_aut.setAprobarFacturas(factura, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDetalleAjustes(string ajuste, int opcion)
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_aut.GetAjustes(ajuste, opcion);
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["articulo"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["descripcion"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["cantidad"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["costo"]) + "</td>";
                tabla += "</tr>";
            }
            return tabla;
        }
        #endregion
    }
}
