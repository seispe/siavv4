/****************************************************************
-- Titulo:  Armar Menu
-- Author:  Gabriel Reyes
-- Fecha:   24/04/2017
-- Version: 4.0.1
-- Empresa: Grupo Alvarado
-- Reviso: {Compañero del Area}
-- Aprobo: {Jefe Inmediato}
****************************************************************/

using System;
using AccesoDatos.Seguridad;
using System.Data;
using System.Web.UI.WebControls;
using AccesoEntidades.Seguridad;

namespace AccesoNegocios.Seguridad
{
    public class AN_Menu
    {
        #region Variables Globales
        AD_SEG ad_seg = new AD_SEG();
        string _strARMARMENU = "";
        #endregion

        #region Funciones
        public string CrearMenu(string empresa, string usuario)
        {
            string menu = "";
            string menu2 = "";
            string icon = "";
            DataTable dth;
            DataTable dth2;
            DataTable dt = ad_seg.getPadresMenu(empresa, usuario);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[5].ToString() == "N")
                { //No tiene Hijos
                    _strARMARMENU += "<li class='menu__item'><a class='menu__link'  data-submenu='" + dr[0] + "' href='" + dr[3] + "'><i class='fa " + dr[6] + " fa-fw'></i>" + dr[1] + "</a></li>";
                    //vg_menu += "<li><a href='" + dr[3] + "'><i class='fa " + dr[6] + " fa-fw'></i> " + dr[1] + "</a></li>";
                }
                else
                { //Tiene Hijos / Verificamos en que nivel tiene hijos
                    dth = ad_seg.gethijosMenu(dr[2].ToString(), empresa, usuario,"2"); // 2 => Nivel 2 del Menu y 3 => Nivel 3 del Menu
                    foreach (DataRow drh in dth.Rows)
                    { //Verifico que el hijo no tenga hijos
                        if (drh[5].ToString() == "S")
                        {
                            //Recorrer los hijos de el Nivel 3
                            dth2 = ad_seg.getnietoMenu(drh[0].ToString(), empresa, usuario,"3");
                            foreach (DataRow drh2 in dth2.Rows)
                            {
                                menu2 += "<li class='menu__item'><a class='menu__link' href='" + drh2[3] + "'><i class='fa " + drh2[6] + " fa-fw'></i>" + drh2[1] + "</a></li>";
                                //menu2 += "<li><a href='" + drh2[3] + "' ><i class='fa " + drh2[6] + " fa-fw'></i> " + drh2[1] + "</a></li>";
                                icon = "<span class='caret'></span>";
                            }
                            //Unir Padre e hijo en el Nivel 3
                            menu += "<li class='menu__item'><a class='menu__link'  data-submenu='" + drh[0] + "' href='" + drh[3] + "'><i class='fa " + drh[6] + " fa-fw'></i>" + drh[1] + "" + icon + "</a><ul data-menu='" + drh[0] + "' class='menu__level'>" + menu2 + "</ul></li>";
                            //menu += "<li  class='submenu2'><a href='" + drh[3] + "'><i class='fa " + drh[6] + " fa-fw'></i> " + drh[1] + "" + icon + "</a><ul class='children2'>" + menu2 + "</ul></li>";
                            menu2 = ""; icon = "";
                        }
                        else
                        {
                            menu += "<li class='menu__item'><a class='menu__link' href='" + drh[3] + "'><i class='fa " + drh[6] + " fa-fw'></i>" + drh[1] + "</a></li>";
                            //menu += "<li><a href='" + drh[3] + "'><i class='fa " + drh[6] + " fa-fw'></i> " + drh[1] + "</a></li>";
                        }
                        icon = "<span class='caret'></span>";
                    }
                    //Uno padre e hijo Nivel 2
                    _strARMARMENU += "<li class='menu__item'><a class='menu__link'  data-submenu='" + dr[0] + "' href='" + dr[3] + "'><i class='fa " + dr[6] + " fa-fw'></i>" + dr[1] + "" + icon + "</a><ul data-menu='" + dr[0] + "' class='menu__level'>" + menu + "</ul></li>";
                    //vg_menu += "<li><a href='" + dr[3] + "' class='submenu'><i class='fa " + dr[6] + " fa-fw'></i> " + dr[1] + "" + icon + "</a><ul class='children'>" + menu + "</ul></li>";
                    menu = ""; icon = "";
                }
            }
            _strARMARMENU += "<li class='menu__item'><a class='menu__link' data-submenu='0' href='/SIAV_v4/OutLogin.aspx'><i class='fa fa-times fa-fw'></i> Salir</a></li>";
            //vg_menu += "<li><a href='/SIAV/OutLogin.aspx'><i class='fa fa-times fa-fw'></i> Salir</a></li>";
            return _strARMARMENU;
        }

        public string AcronimoEmpresas(string empresa)
        {
            try
            {
                string acronimo = ad_seg.getacronimoEmpresas(empresa);
                return acronimo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string VerificarVentana(string usuario,string empresa,string ventana)
        {
            return ad_seg.validarUsuarioVenta(usuario,empresa,ventana);
        }

        public string BaseEmpresas(string empresa)
        {
            try
            {
                string acronimo = ad_seg.getbaseEmpresas(empresa);
                return acronimo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public GridView GetConfigNivel(string nivel, string buscar)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            switch (nivel)
            {
                case "1":
                    dsp = ad_seg.GetConfigNivel1();
                    break;
                case "2":
                    dsp = ad_seg.GetConfigNivel2(buscar);
                    break;
                case "3":
                    dsp = ad_seg.GetConfigNivel3(buscar);
                    break;
            }
            
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

        public GridView GetUsuarioVentana(string buscar)
        {
            DataSet dsp = new DataSet();
            GridView gv = new GridView();

            dsp = ad_seg.GetUsuarioVentana(buscar);

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

        public void UpdateNivel1(AE_GA_SEG_TmenuNivel1 ae_seg_tmenunivel1)
        {
            ad_seg.UpdateNivel1(ae_seg_tmenunivel1);
        }

        public void UpdateUsuarioVentan(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            ad_seg.UpdateUsuarioVentana(ae_ga_seg_tpermisos);
        }

        public void UpdateNivel2(AE_GA_SEG_TmenuNivel2 ae_seg_tmenunivel2)
        {
            ad_seg.UpdateNivel2(ae_seg_tmenunivel2);
        }

        public void UpdateNivel3(AE_GA_SEG_TmenuNivel3 ae_seg_tmenunivel3)
        {
            ad_seg.UpdateNivel3(ae_seg_tmenunivel3);
        }

        public void InsertNewPadre(AE_GA_SEG_TmenuNivel1 ae_seg_tmenunivel1)
        {
            ad_seg.InsertNewPadre(ae_seg_tmenunivel1);
        }

        public void InsertUsuarioVentana(AE_GA_SEG_Tpermisos ae_ga_seg_tpermisos)
        {
            ad_seg.InsertUsuarioVentana(ae_ga_seg_tpermisos);
        }

        public void InsertNewHijo(AE_GA_SEG_TmenuNivel2 ae_seg_tmenunivel2)
        {
            ad_seg.InsertNewHijo(ae_seg_tmenunivel2);
        }

        public void InsertNewNieto(AE_GA_SEG_TmenuNivel3 ae_seg_tmenunivel3)
        {
            ad_seg.InsertNewNieto(ae_seg_tmenunivel3);
        }

        public string Boxquick(string ventana,string icono, string titulo, string color)
        {
            try
            {
                //Colores Aceptados
                //"green", "blue", "orange", "purple", "yellow"
                //Declaracion de Variables
                string armar;
                //Armar box-quick
                armar = "<div class='col-xs-4 col-sm-4'>";
                armar += "<div class='box-quick-link " + color + "-background'>";
                //ventana = ventana.Remove(0, 20);
                armar += "<a href='" + ventana.Trim() + "'>";
                armar += "<div class='header'>";
                armar += "<div class='fa " + icono.Trim() + " fa-3x'>";
                armar += "</div>";
                armar += "</div>";
                armar += "<div class='content'>";
                armar += titulo.Trim();
                armar += "</div>";
                armar += "</a>";
                armar += "</div>";
                armar += "</div>";
      
                return armar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertAutLoginVentana(AE_GA_SEG_Tloginvent ae_ga_seg_tloginvent)
        {
            ad_seg.InsertAutLoginVentana(ae_ga_seg_tloginvent);
        }

        public string GetAutLoginVentana(string usuario, string empresa)
        {
            try
            {
                Random r = new Random();
                string cadena = ""; string armar;
                string[] color = new string[] { "green", "blue", "orange", "purple", "yellow" };
                DataTable dt = ad_seg.GetAutLoginVentana(usuario,empresa);
                
                foreach (DataRow row in dt.Rows)
                {
                    armar = "<div class='col-xs-4 col-sm-4'>";
                    armar += "<div class='box-quick-link " + color[r.Next(0, 4)].Trim() + "-background'>";

                    string valor = Convert.ToString(row["ventana"]);
                    //valor = valor.Remove(0, 20);

                    armar += "<a href='" + valor.Trim() + "'>";
                    armar += "<div class='header'>";

                    string icono = ad_seg.GetVentanaIcono(valor);

                    armar += "<div class='fa " + icono.Trim() + " fa-3x'>";
                    armar += "</div>";
                    armar += "</div>";
                    armar += "<div class='content'>";

                    valor = ad_seg.GetVentana(valor);

                    armar += valor.Trim();
                    armar += "</div>";
                    armar += "</a>";
                    armar += "</div>";
                    armar += "</div>";

                    if (valor.Length > 1) cadena += armar;
                }

                return cadena;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
