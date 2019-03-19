using Datos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logica
{
    

    public class ValidacionesCrudAdmin
    {
        String msj1, msj2, msj3, msj4, msj5, msj6, msj7, msj8, msj9;
        Hashtable compIdiomaa = new Hashtable();
        DAOUsuario dao = new DAOUsuario();
        Usuario usuario = new Usuario();
        DataTable usu = new DataTable();

        string nombre, cedula, clave, direccion, telefono, correo, dseleccionado, dsexo;
        string nombree, cedulae, clavee, direccione, telefonoe, correoe, dseleccionadoe, dsexoe;
        string mensaje;
        string accion;

        public ValidacionesCrudAdmin(string idioma)
        {
            mensajesTrad(idioma, 14);
            msj1 = compIdiomaa["1"].ToString();
            msj2 = compIdiomaa["2"].ToString();
            msj3 = compIdiomaa["3"].ToString();
            msj4 = compIdiomaa["4"].ToString();
            msj5 = compIdiomaa["5"].ToString();
            msj6 = compIdiomaa["6"].ToString();
            msj7 = compIdiomaa["7"].ToString();
            msj8 = compIdiomaa["8"].ToString();
            msj9 = compIdiomaa["9"].ToString();
        }

        public ValidacionesCrudAdmin(string nombrea, string cedulaa, string correoa, string direcciona, string telefonoa, string dseleccionadoa, string dsexoa, string clave,
            string nombree, string cedulae, string correoe, string direccione, string telefonoe, string dseleccionadoe, string dsexoe, string clavee, string accion)
        {
            this.nombre = nombrea;
            this.cedula = cedulaa;
            this.direccion = direcciona;
            this.telefono = telefonoa;
            this.correo = correoa;
            this.dseleccionado = dseleccionadoa;
            this.dsexo = dsexoa;
            this.clave = clave;
            this.nombree = nombree;
            this.cedulae = cedulae;
            this.direccione = direccione;
            this.telefonoe = telefonoe;
            this.correoe = correoe;
            this.dseleccionadoe = dseleccionadoe;
            this.dsexoe = dsexoe;
            this.clavee = clavee;
            this.accion = accion;

            usu = dao.traerUsuariosAdmin();
            if (accion == "guardar")
            {
                mensaje = hacertodoagregar();
            }
            if (accion == "editar")
            {
                mensaje = hacertodoeditar();
            }

        }
        
        public bool validarLlenoAgregar(string cedula, string nombre, string clave, string direccion, string telefono, string correo)
        {
            if (cedula == "" || nombre == "" || clave == "" || direccion == "" || telefono == "" || correo == "")
            {
                mensaje = msj1;
                return false;
            }
            else
            {

                return true;
            }
        }

        public bool validarCaractNombre(string nombre)
        {
            bool resultadoNombre = Regex.IsMatch(nombre, @"^[a-zA-Z]+$");
            if (resultadoNombre == true || nombre.Contains(" "))
            {
                return true;
            }
            else
            {
                mensaje = msj2;
                return false;
            }
        }

        public bool validarNumerosCed(string num)
        {
            try
            {
                if (int.Parse(cedula)< 999999999) {
                    double x = Convert.ToDouble(num);
                    return true;
                }
                else
                {
                    mensaje = msj3;
                    return false;
                }
                
            }
            catch (Exception)
            {
                mensaje = msj2;
                return false;
            }
        }
        public bool validarNumerosTel(string num)
        {
            try
            {
                double x = Convert.ToDouble(num);
                return true;
            }
            catch (Exception)
            {
                mensaje = msj4;
                return false;
            }
        }

        public bool validarCedula(string cedulallega)
        {
            DataTable cedula = new DataTable();

            cedula = dao.traerUsuariosAdmin();
            for (int i = 0; i < cedula.Rows.Count; i++)
            {
                if (cedula.Rows[i]["cedula"].ToString() == cedulallega)
                {
                    mensaje = msj5;
                    return false;
                }
            }

            return true;

        }

        public bool validarAdmin(string sedeSeleccionada)
        {
            DataTable sede = new DataTable();

            sede = dao.traerUsuariosAdmin();

            for (int i = 0; i < sede.Rows.Count; i++)
            {
                if (sede.Rows[i]["sede"].ToString() == sedeSeleccionada && sede.Rows[i]["rol_id"].ToString() == "2")
                {
                    mensaje = msj6;
                    return false;
                }
            }
            return true;
        }

        public bool validaralgocedula()
        {
            if (usuario.Cedula <= 0 )
            {
                mensaje = msj7;
                return false;
            }
            return true;
        }

        public string hacertodoagregar()
        {
            if (validarLlenoAgregar(cedula, nombre, clave, direccion, telefono, correo))
            {
                if (validarCaractNombre(nombre))
                {
                    if (validarNumerosTel(telefono))
                    {
                        if (validarNumerosCed(cedula))
                        {
                            if (validarCedula(cedula))
                            {
                                if (validarAdmin(dseleccionado))
                                {
                                    usuario.Cedula = Convert.ToInt64(cedula);
                                    if (validaralgocedula())
                                    {
                                        usuario.Nombre = nombre;
                                        usuario.Clave = clave;
                                        usuario.Direccion = direccion;
                                        usuario.Telefono = long.Parse(telefono);
                                        if (usuario.Telefono <= 0)
                                        {
                                            mensaje = msj8;
                                            return mensaje;
                                        }
                                        usuario.Sexo = dsexo;
                                        usuario.Sede = dseleccionado;
                                        usuario.Correo = correo;
                                        usuario.Estado = 1;
                                        usuario.Session = "hola";
                                        usuario.RolId = 2;
                                        usuario.LastModified = DateTime.Now;

                                        dao.CrearUsuario(usuario);
                                    }
                                    else
                                    {

                                    }

                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                dao.agregarUsuarioNuevamente(cedula);
                                usu = dao.traerUsuariosAdmin();
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return mensaje;
        }

        public string devuelvemensaje()
        {
            return mensaje;
        }

        bool validarLlenoEditar()
        {
            if (cedulae == "" || nombree == "" || clavee == "" || direccione == "" || telefonoe == "" || correoe == "")
            {
                mensaje = msj9;
                return false;
            }
            else
            {
                return true;
            }
        }
        public string hacertodoeditar()
        {
            if (validarLlenoEditar())
            {
                if (validarCaractNombre(nombree))
                {
                    if (validarNumerosTel(telefonoe))
                    {
                        Usuario usuario2 = new Usuario();

                        usuario2.Cedula = int.Parse(cedulae);
                        usuario2.Nombre = nombree;
                        usuario2.Clave = clavee;
                        usuario2.Direccion = direccione;
                        usuario2.Telefono = Convert.ToInt64(telefonoe);
                        usuario2.Sexo = dsexoe;
                        usuario2.Sede = dseleccionadoe;
                        usuario2.Correo = correoe;
                        usuario2.Estado = 1;
                        usuario2.Session = "";
                        usuario2.RolId = 2;
                        usuario2.LastModified = DateTime.Now;

                        dao.actualizarUsuario(usuario2);


                    }
                    else
                    {
                    }
                }
                else
                {
                }
            }
            else
            {
            }
            return mensaje;
        }
        public Usuario paracomandogrid(string comando, string argumento) 
        {
            Usuario iusuari = new Usuario();
            if(comando == "Editar")
            {
                iusuari = traerEditar(Convert.ToInt32(argumento));
                return iusuari;
            }
            if(comando == "Eliminar")
            {
                eliminarUsuario(argumento);
            }
            return iusuari;
        }
        public Usuario traerEditar(int a)
        {
            Usuario usuar = new Usuario();
            for (int i = 0; i < usu.Rows.Count; i++)
            {
                if (a == Convert.ToInt32(usu.Rows[i]["cedula"]))
                {
                    usuar.Cedula = long.Parse(usu.Rows[i]["cedula"].ToString());
                    usuar.Nombre = usu.Rows[i]["nombre"].ToString();
                    usuar.Clave = usu.Rows[i]["clave"].ToString();
                    usuar.Sexo = usu.Rows[i]["sexo"].ToString();
                    usuar.Direccion = usu.Rows[i]["direccion"].ToString();
                    usuar.Telefono = long.Parse(usu.Rows[i]["telefono"].ToString());
                    usuar.Correo = usu.Rows[i]["correo"].ToString();
                }
            }
            return usuar;
        }
        void eliminarUsuario(string a)
        {
            dao.eliminarUsuario(a);
        }
        public List<string> llenarDDLs()
        {
            DataTable dsede = new DataTable();
            List<string> sedes = new List<string>();
            dsede = dao.traerSedes();
            

            for (int i = 0; i < dsede.Rows.Count; i++)
            {
                sedes.Add(dsede.Rows[i]["nombresede"].ToString() + "-" + dsede.Rows[i]["ciudad"].ToString());
                
            }
            return sedes;
        }

        public DataTable traerAdmins()
        {
            DAOUsuario dao = new DAOUsuario();            
            return dao.traerUsuariosAdmin();
        }

        public DataTable traerSedes()
        {
            DAOUsuario dao = new DAOUsuario();
            return dao.traerSedes();
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
