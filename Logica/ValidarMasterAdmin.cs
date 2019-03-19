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
    public class ValidarMasterAdmin
    {
        public string validarSession(string nombre, string clave, string rol, string sede)
        {
            if (nombre == null || clave == null || rol == null || sede == null)
            {
                return ("../Login-Rec/NuevoLogin.aspx");
            }

            return ("../Tienda/CRUDVendedor.aspx");
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
