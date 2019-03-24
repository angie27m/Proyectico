using Datos;
using System.Collections.Generic;
using System.Data;

namespace Logica
{

    public class Idioma
    {
        DAOUsuario dao = new DAOUsuario();
        List<string> idiomas = new List<string>();
        DataTable tabla = new DataTable();
        public Idioma()
        {

        }
        public List<string> llenarDDL()
        {
            tabla = dao.traerIdioma();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                idiomas.Add(tabla.Rows[i]["nombre"].ToString());
            }
            return idiomas;
        }
    }
}
