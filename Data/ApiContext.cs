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
        public DbSet<Asistencia> Asistencia { get; set; }
        public DbSet<Sede> Sedes { get; set; }  // Para la tabla de secciones
        public DbSet<Persona> Personas { get; set; }  // Para la tabla de secciones
        public DbSet<Usuario> Usuarios { get; set; }  // Para la tabla de secciones
        public DbSet<Paciente> Pacientes { get; set; }  // Para la tabla de secciones
        public DbSet<Medicos> Medicos { get; set; }  // Para la tabla de secciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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