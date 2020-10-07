using AccesoDatos.WMScal;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace AccesoNegocios.Wmscal
{
    public class AN_WMScal
    {
        #region VariablesGlobales
        AD_WMScal ad_wmscal = new AD_WMScal();
        #endregion

        #region Funciones
        public DataSet GetCCproductofamilia(int op, string dato)
        {
            return ad_wmscal.GetCCproductofamilia(op, dato);
        }

        public DataSet GetPicking(int id_rol, string empresa)
        {
            return ad_wmscal.GetPicking(id_rol, empresa);
        }
        
        public string InsConteoCiclico(int op, string tipo, string documento, int cantidad, string codigoproducto, string descripcion,
            string observacion, string origen, string empresa, int idcc, string usuario, string usuarioasigna)
        {
            try
            {
                return ad_wmscal.InsConteoCiclico(op, tipo, documento, cantidad, codigoproducto, descripcion, observacion, origen, empresa, idcc, usuario,usuarioasigna);
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
                return ad_wmscal.ExportarGP(maestro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUsuAsig(string dato, int op)
        {
            return ad_wmscal.GetUsuAsig(dato, op);
        }

        public GridView GetCCReportes(string filtro, int op)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wmscal.GetCCReportes(filtro, op);

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

        public string AsigFamilia(string producto, string familia, int op)
        {
            try
            {
                return ad_wmscal.AsigFamilia(producto, familia, op);
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
                return ad_wmscal.ValidaTraspasos(traspaso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string UpdateTraspasos(string traspaso)
        {
            try
            {
                return ad_wmscal.UpdateTraspasos(traspaso);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetPedsinStock()
        {
            DataSet dsp = new DataSet();
            string tabla = "";
            dsp = ad_wmscal.GetPedsinStock();
            DataTable dt = dsp.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                tabla += "<tr>";
                tabla += "<td>" + Convert.ToString(row["CODIGO"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["DESCRIPCION"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["CANT"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["PEDIDO"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["FECHA"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["CLIENTE"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["VENDEDOR"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["STOCK"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["CIF"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["PRECIO"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["MU"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["QTY_UC"]) + "</td>";
                tabla += "<td>" + Convert.ToString(row["FECHA_UC"]) + "</td>";

                tabla += "</tr>";
            }
            return tabla;
        }

        public GridView GetPedsinStock2()
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_wmscal.GetPedsinStock();

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
