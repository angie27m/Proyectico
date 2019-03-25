using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilitarios;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAOPersistencia
    {
        public List<Sede> traerSedes()
        {
            using (var db = new Mapeo())
            {
                return db.Sedes.Where(x => x.Estado == "true").ToList();
            }
        }

        public bool AgregarSede(Sede sede)
        {
            using (var db = new Mapeo())
            {
                int resultado = db.Sedes.Where(x => x.NombreSede == sede.NombreSede && x.Ciudad == sede.Ciudad).Count();
                if (resultado == 0)
                {
                    db.Sedes.Add(sede);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public void EliminarSede(int idSede)
        {
            using (var db = new Mapeo())
            {
                var entities = (from p in db.Sedes
                                where p.IdSede == idSede
                                select p).Single();
                entities.Estado = "false";
                db.Entry(entities).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Usuario> traerUsuarios(int estado, int rol)
        {
            using (var db = new MapeoUsuarios())
            {
                return db.Usuarios.Where(x => x.Estado == estado && x.RolId == rol).ToList();
            }
        }

        public Usuario ExisteUsuario(Usuario usu)
        {
            try
            {
                using (var db = new MapeoUsuarios())
                    return db.Usuarios.First(t => t.Cedula == usu.Cedula);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool AgregarUsuario(Usuario usu)
        {
            using (var db = new MapeoUsuarios())
            {
                Usuario a = this.ExisteUsuario(usu);

                if (a == null)
                {
                    db.Usuarios.Add(usu);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Entry(a).State = EntityState.Modified;
                    db.SaveChanges();
                    return false;
                }
            }
        }

        public int not_asignaciones()
        {
            using (var db = new MapeoPedido())
            {
                int resultado = db.Pedido.Where(x => x.Estado == false && x.Observacion == null).Count();
                return resultado;
            }
        }

        public int not_conflictos()
        {
            using (var db = new MapeoPedido())
            {
                int resultado = db.Pedido.Where(x => x.Estado == false && x.Observacion != null).Count();
                return resultado;
            }
        }

        public int not_pedido(string sede)
        {
            using (var db = new MapeoAsignacion())
            {
                int resultado = db.Asignacion.Where(x => x.Estado == false && x.Sede == sede).Count();
                return resultado;
            }            
        }
    }
}
