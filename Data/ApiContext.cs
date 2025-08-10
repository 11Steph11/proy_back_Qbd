using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Dto.Response;
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
        public DbSet<UsuarioTipo> UsuarioTipos { get; set; }  // Para la tabla de secciones
        public DbSet<Trabajador> Trabajador { get; set; }  // Para la tabla de secciones
        public DbSet<Usuario> Usuarios { get; set; }  // Para la tabla de secciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        public async Task<List<FechaConHoras>> ObtenerAsistenciasAsync(string a, int b, int c)
        {
            // ExecuteSqlRawAsync no devuelve el resultado directamente, así que usamos FromSql para obtener el valor
            var response = await Database.SqlQueryRaw<FechaConHoras>("SELECT * FROM obtener_horarios_trabajador({0}, {1}, {2})", a, b, c)
                .ToListAsync();
            return response;
        }
    }
}