using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Proy_back_QBD.Models
{

    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }  // Puede ser nulo 
        [Column("contrasena")]
        public required string Contrasena { get; set; }  // Puede ser nulo        
        public TipoUsuario? Tipo { get; set; }  // Puede ser nulo
        [Column("tipo_id")]
        public int? TipoId { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_creacion")]
        public DateTime? FechaCreacion { get; set; }  // Puede ser nulo        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador_id")]
        public int? CreadorId { get; set; }
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int? ModificadorId { get; set; }
        public Usuario? Modificador { get; set; }
        [Column("horario_entrada")]
        public TimeOnly? HorarioEntrada { get; set; }  // Puede ser nulo
        [Column("horario_salida")]
        public TimeOnly? HorarioSalida { get; set; }  // Puede ser nulo
        public Persona? Persona { get; set; }  // Puede ser nulo
        [Column("persona_id")]
        public int? PersonaId { get; set; }  // Puede ser nulo
        [Column("cmp")]
        public string? Cmp { get; set; }  // Puede ser nulo
        [Column("horario_almuerzo")]
        public TimeOnly? HorarioAlmuerzo { get; set; }  // Puede ser nulo
        [Column("horario_regreso")]
        public TimeOnly? HorarioRegreso { get; set; }  // Puede ser nulo
        [Column("codigo")]
        public string? Codigo { get; set; }
        public List<Asistencia>? AsistenciasCreadas { get; set; }
        public List<Asistencia>? AsistenciasModificadas { get; set; }
        public List<Especialidad>? EspecialidadsCreadas { get; set; }
        public List<Especialidad>? EspecialidadsModificadas { get; set; }
        public List<Formula>? FormulasCreadas { get; set; }
        public List<Formula>? FormulasModificadas { get; set; }
        public List<Medico>? MedicosCreadas { get; set; }
        public List<Medico>? MedicosModificadas { get; set; }
        public List<Paciente>? PacientesCreadas { get; set; }
        public List<Paciente>? PacientesModificadas { get; set; }
        public List<Pedido>? PedidosCreadas { get; set; }
        public List<Pedido>? PedidosModificadas { get; set; }
        public List<Persona>? PersonasCreadas { get; set; }
        public List<Persona>? PersonasModificadas { get; set; }
        public List<Sede>? SedesCreadas { get; set; }
        public List<Sede>? SedesModificadas { get; set; }
        public Sede? Sede { get; set; }
        public List<Usuario>? UsuariosCreadas { get; set; }
        public List<Usuario>? UsuariosModificadas { get; set; }
        public List<TipoUsuario>? TUCreadas { get; set; }
        public List<TipoUsuario>? TUModificadas { get; set; }
        public List<ProdTerm>? PTCreados { get; set; }
        public List<ProdTerm>? PTModificados { get; set; }
        public List<Cobro>? CobrosCreadas { get; set; }
        public List<Cobro>? CobrosModificadas { get; set; }
        public List<Laboratorio>? LaboratorioCreadas { get; set; }
        public List<Laboratorio>? LaboratorioModificadas { get; set; }
    }
    [Table("tipos_usuario")]
    public class TipoUsuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }  // Puede ser nulo 
        [Column("nombre")]
        public string? Nombre { get; set; }  // Puede ser nulo
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }  // Puede ser nulo        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("fecha_modificacion")]
        public DateTime FechaModificacion { get; set; }  // Puede ser nulo
        [Column("creador_id")]
        public int? CreadorId { get; set; }
        public Usuario? Creador { get; set; }
        [Column("modificador_id")]
        public int? ModificadorId { get; set; }
        public Usuario? Modificador { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}