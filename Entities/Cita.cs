using System.ComponentModel.DataAnnotations;

namespace citas_medicas.Entities

{
    public class Cita : IEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        
        [Required]
        public string MotivoCita { get; set; } = string.Empty;
        
        [Required]
        public DateTime FechaHora { get; set; }
        
        [Required]
        public Diagnostico Diagnostico { get; set; }     
        
        [Required]
        public Medico Medico { get; set; }
       
        [Required]
        public Paciente Paciente { get; set; }
    }
}
