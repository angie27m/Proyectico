using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;


namespace Logica
{
    public class Loguearse
    {
        DAOUsuario dao = new DAOUsuario();
        int kIdioma;
        string idioma;
        string msj1, msj2;
        Hashtable compIdiomaa = new Hashtable();

        public Loguearse(string idioma)
        {
            this.idioma = idioma;
            mensajesTrad(idioma, 8);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
        }
        string mensaje = "";
        string response = "../Login-Rec/NuevoLogin.aspx";
        public UUsuario loguear(string cedula, string clave) {
            Validaciones val = new Validaciones();
            UUsuario user = new UUsuario();
            if (cedula != "" && clave != "")
            {
                if (val.validarNumeros(cedula) == true)
                {
                    MAC a = new MAC();
                    user.Usuario = cedula;
                    user.Clave = clave;
                    user.Ip = "192.168.1.1";
                    //user.Ip = HttpContext.Current.Request.UserHostAddress;
                    user.Mac = a.traerMac();
                    DAOUsuario guardarUsuario = new DAOUsuario();
                    DataTable data = guardarUsuario.loggin(user);
                    user = new CoreUser(idioma).autenticar(user);
                    mensaje = user.Mensaje;
                    Validaciones validarRol = new Validaciones();
                    response = validarRol.validarRol(user.Rol_id);
                    return user;
                }
                else
                {
                    mensaje = msj1;
                    return user;
                }
            }
            else
            {
                mensaje = msj2;
            }
            
            return user;
        }
        public string get_script()
        {
            string c = "alert('" + mensaje + "');window.location.href = '" + response + "'; ";
            return c;
        }
        
        public DataTable paraIdioma(string idioma, int constante)
        {
            DataTable comp = new DataTable();

            if (idioma == "Español")
            {
                kIdioma = 1;
            }
            else if (idioma == "English")
            {
                kIdioma = 2;
            }
            comp = dao.traerComponentes(kIdioma, constante);
            return comp;
        }

        int kIdiomaa;
        public void mensajesTrad(string idioma, int constante)
        {
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
