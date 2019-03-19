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

        public void AgregarSede(Sede sede)
        {
            using (var db = new Mapeo())
            {
                db.Sedes.Add(sede);
                db.SaveChanges();
            }

        }

        public void EliminarSede(int idSede)
        {
            using (var db = new Mapeo())
            {
                
            }

        }
    }
}
