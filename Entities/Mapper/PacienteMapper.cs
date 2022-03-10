using AutoMapper;
using citas_medicas.Models.DTO;

namespace citas_medicas.Entities.Mapper
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<PacienteDTO, Paciente>()
                .ForMember(p=>p.Medicos, o=> o.MapFrom(pdto=> new List<Medico>()));

            CreateMap<Paciente, PacienteDTO>()
                .ForMember(pdto => pdto.Medicos, o => o.MapFrom(p => p.Medicos.Select(m => m.Id).ToList()));
        }
    }
}
