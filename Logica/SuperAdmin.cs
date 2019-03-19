using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class SuperAdmin
    {
        public SuperAdmin()
        {

        }
        public string validarSession(string user, string clave, int rol_id)
        {
            if (user == null || clave == null || rol_id != 1)
            {
                return "~/Login-Rec/NuevoLogin.aspx";
            }
            else
            {
                return "~/Tienda/CRUDProducto.aspx";
            }
        }
        int kIdioma;
        public Hashtable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();
            DAOUsuario dAO = new DAOUsuario();
            Hashtable compIdioma = new Hashtable();
            if (idioma == "Español")
            {
                kIdioma = 1;
            }
            else if (idioma == "English")
            {
                kIdioma = 2;
            }
            comp = dAO.traerComponentes(kIdioma, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdioma.Add(comp.Rows[i]["control"].ToString(), comp.Rows[i]["texto"].ToString());
            }
            return compIdioma;
        }
    }
}
