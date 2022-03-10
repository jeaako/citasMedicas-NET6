namespace citas_medicas.Entities
{
    public class MedicoPaciente
    {
        public long PacienteId { get; set; }
        public long MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
      
    }
}
