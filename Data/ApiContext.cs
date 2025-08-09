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
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Region> Regions { get; set; }  // Para la tabla de secciones
        public DbSet<UserType> UserTypes { get; set; }  // Para la tabla de secciones
        public DbSet<Trabajador> Employees { get; set; }  // Para la tabla de secciones
        public DbSet<User> Users { get; set; }  // Para la tabla de secciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}