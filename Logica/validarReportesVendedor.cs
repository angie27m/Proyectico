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
    public class validarReportesVendedor
    {
        string mensaje, response, sesion, msj1;
        Hashtable compIdiomaa = new Hashtable();

        public validarReportesVendedor(string idioma)
        {
            mensajesTrad(idioma, 18);
            msj1 = compIdiomaa["1"].ToString();
        }

        public void validarTB(string tb)
        {
            if (validarNumeros(tb) == true)
            {
                sesion = tb;
                response = ("../Tienda/VistaFactura.aspx");
            }
            else
            {
                mensaje = msj1;
            }
        }

        public bool validarNumeros(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getResponse()
        {
            return response;
        }

        public string getMensaje()
        {
            return mensaje;
        }

        public string getSesion()
        {
            return sesion;
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

        int kIdiomaa;
        public void mensajesTrad(string idioma, int constante)
        {
            DAOUsuario dao = new DAOUsuario();
            DataTable comp = new DataTable();
            if (idioma == "Español")
            {
                kIdiomaa = 1;
            }
            else if (idioma == "English")
            {
                kIdiomaa = 2;
            }
            comp = dao.traerMensajes(kIdiomaa, constante);
            for (int i = 0; i < comp.Rows.Count; i++)
            {
                compIdiomaa.Add(comp.Rows[i]["msj"].ToString(), comp.Rows[i]["texto"].ToString());
            }
        }
    }
}
