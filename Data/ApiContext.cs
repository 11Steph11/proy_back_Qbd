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
        public DbSet<Asistencia> Attendances { get; set; }
        public DbSet<Sede> Regions { get; set; }  // Para la tabla de secciones
        public DbSet<UsuarioTipo> UserTypes { get; set; }  // Para la tabla de secciones
        public DbSet<Trabajador> Trabajador { get; set; }  // Para la tabla de secciones
        public DbSet<Usuario> Users { get; set; }  // Para la tabla de secciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}