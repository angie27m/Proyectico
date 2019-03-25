using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("asignacion", Schema = "tienda")]
    public class Asignaciones
    {
        public Asignaciones()
        {

        }
        private int idAsignaciones;
        private int idAsignacion;
        private string referencia;
        private int cantidad;
        private double talla;

        [Column("idasignaciones")]
        public int IdAsignaciones { get => idAsignaciones; set => idAsignaciones = value; }
        [Column("idasignacion")]
        public int IdAsignacion { get => idAsignacion; set => idAsignacion = value; }
        [Column("referencia")]
        public string Referencia { get => referencia; set => referencia = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("talla")]
        public double Talla { get => talla; set => talla = value; }
    }
}
