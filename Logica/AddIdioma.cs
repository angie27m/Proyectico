using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class AddIdioma
    {
        DAOUsuario dao = new DAOUsuario();
        DataTable tablaidi = new DataTable();
        DataTable componentes = new DataTable();
        DataTable paraultimoComp = new DataTable();
        DataTable paraultimoIdi = new DataTable();
        DataTable sinTraducirComp = new DataTable();
        int sesionIdiomaAct, sesionIdiomaEsc;
        int soloComp = 0, ultimoComp = 0, ultimoIdi=0;
        int ultimoMen = 0;
        DataTable mensajes = new DataTable();
        DataTable paraultimoMen = new DataTable();
        DataTable sinTraducirMen = new DataTable();
        string idioma;
        List<string> compoSinTrad = new List<string>();
        List<string> compoAct = new List<string>();
        public AddIdioma(string StrIdioma)
        {
            DataTable idi = new DataTable();
            idi = dao.traerIdioma();
            for (int i = 0; i < idi.Rows.Count; i++)
            {
                if (idi.Rows[i]["nombre"].ToString().ToLower() == StrIdioma.ToLower())
                { 
                    sesionIdiomaAct = int.Parse(idi.Rows[i]["id"].ToString());
                }
            }
        }
        public void ValidarExistente(string idioma, string terminacion)
        {
            this.idioma = idioma;
            if (validarCajas(idioma, terminacion))
            {
                tablaidi = dao.traerIdioma();
                for (int i = 0; i < tablaidi.Rows.Count; i++)
                {
                    if (tablaidi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower() || tablaidi.Rows[i]["terminacion"].ToString().ToLower() == terminacion.ToLower())
                    {
                        soloComp = 1;
                    }
                }
                if (soloComp == 1)
                {
                    DataTable idi = new DataTable();
                    idi = dao.traerIdioma();
                    for (int i = 0; i < idi.Rows.Count; i++)
                    {
                        if (idi.Rows[i]["nombre"].ToString().ToLower() == idioma.ToLower())
                        {
                            sesionIdiomaEsc = int.Parse(idi.Rows[i]["id"].ToString());
                        }
                    }
                    sinTraducirComp = dao.traerTodosComponentesUnIdioma(sesionIdiomaEsc);
                    componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                    sinTraducirMen = dao.traerTodosMensajesUnIdioma(sesionIdiomaEsc);
                    mensajes = dao.traerTodosMensajesUnIdioma(sesionIdiomaAct);
                    HacerListaSinTrad();
                }
                else
                {
                    componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                    mensajes = dao.traerTodosMensajesUnIdioma(sesionIdiomaAct);
                    
                    
                    paraultimoIdi = dao.traerUltimoIDIdi();
                    ultimoIdi = int.Parse(paraultimoIdi.Rows[0]["id"].ToString()) + 1;
                    dao.crearIdioma(ultimoIdi, idioma, terminacion);


                    for (int i = 0; i < componentes.Rows.Count; i++)
                    {
                        paraultimoComp = dao.traerUltimoIDComp();
                        ultimoComp = int.Parse(paraultimoComp.Rows[0]["id"].ToString());
                        dao.crearComponente(ultimoComp + 1, int.Parse(componentes.Rows[i]["formulario_id"].ToString()), ultimoIdi, componentes.Rows[i]["control"].ToString());
                    }
                    for(int i = 0; i < mensajes.Rows.Count; i++)
                    {
                        paraultimoMen = dao.traerUltimoIDMen();
                        ultimoMen = int.Parse(paraultimoMen.Rows[0]["id"].ToString()) + 1;
                        dao.crearMensaje(ultimoMen, mensajes.Rows[i]["nombre"].ToString(), int.Parse(mensajes.Rows[i]["msj"].ToString()), ultimoIdi, int.Parse(mensajes.Rows[i]["clase"].ToString()));
                    }
                }
            }
        }
        public DataTable getComponentes()
        {
            return componentes;
        }
        public void HacerListaSinTrad()
        {
            
            for(int i =0; i < componentes.Rows.Count; i++)
            {
                if (sinTraducirComp.Rows[i]["texto"].ToString() == "")
                {
                    compoAct.Add(componentes.Rows[i]["texto"].ToString());
                }

            }
            for(int i = 0; i < mensajes.Rows.Count; i++)
            {

            }
        }
        public List<string> getListaSinTrad()
        {
            return compoSinTrad;
        }
        public List<string> getListaAct()
        {
            return compoAct;
        }

        public void ActualizarIdioma(string controlAct, string texto)
        {
            if (validarTrad(texto))
            {
                string controlNuevo;
                for (int i = 0; i < componentes.Rows.Count; i++)
                {
                    if (componentes.Rows[i]["texto"].ToString() == controlAct)
                    {
                        controlNuevo = componentes.Rows[i]["control"].ToString();
                        dao.ActualizarIdioma(sesionIdiomaEsc, controlNuevo, texto);
                    }
                }
                componentes = dao.traerTodosComponentesUnIdioma(sesionIdiomaAct);
                HacerListaSinTrad();
            }
        }

        public bool validarCajas(string idioma, string terminacion)
        {
            if(idioma=="" || terminacion == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool validarTrad(string texto)
        {
            if (texto == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
