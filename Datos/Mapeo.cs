
using System.Data.Entity;


namespace Datos
{
    class Mapeo: DbContext
    {
        public DbSet<Sede> Sedes { get; set; }
        private readonly string schema;

        
        public Mapeo() : base("name = sedes1")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema("tienda");
            base.OnModelCreating(builder);
        }
    }
}
