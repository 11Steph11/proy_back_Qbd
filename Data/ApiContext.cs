using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Models;

namespace Proy_back_QBD.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        // DbSets actualizados a las clases correctas
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Sede> Sedes { get; set; }  // Para la tabla de secciones
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }  // Para la tabla de secciones
        public DbSet<Trabajador> Trabajadores { get; set; }  // Para la tabla de secciones
        public DbSet<Usuario> Usuarios { get; set; }  // Para la tabla de secciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Convierte el nombre de las columnas a minúsculas
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }
            }
        }
    }
}