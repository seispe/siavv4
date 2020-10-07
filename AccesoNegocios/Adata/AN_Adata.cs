using AccesoDatos.Adata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoNegocios.Adata
{
    public class AN_Adata
    {
        #region VariablesGlobales
        AD_Adata ad_adata = new AD_Adata();
        #endregion

        #region Funciones
        public void InsCTR_TBL_Pruebas(string nombre, string email, string notas, string opcion)
        {
            try
            {
                ad_adata.InsCTR_TBL_Pruebas(nombre, email, notas, opcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
