using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                db.Sedes.Remove(entities);
                db.SaveChanges();
            }
        }
    }
        
}
