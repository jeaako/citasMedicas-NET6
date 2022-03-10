using AutoMapper;
using citas_medicas.Entities;
using citas_medicas.Models.DTO;
using citas_medicas.Services;
using Microsoft.AspNetCore.Mvc;

namespace citas_medicas.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;


        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<UsuarioDTO>> GetUsuarios()
        {
            IList<UsuarioDTO> usuariosDTO = new List<UsuarioDTO>();
            var usuarios = _usuarioService.GetAllUsuarios();
            
            foreach (Usuario u in usuarios)
                usuariosDTO.Add(_mapper.Map<UsuarioDTO>(u));

            return Ok(usuariosDTO.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> GetUsuarioById(long id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);

            if (usuario != null)
                return _mapper.Map<UsuarioDTO>(usuario);

            return NotFound();

        }

        [HttpPost]
        public ActionResult<String> AddUsuario(UsuarioDTO usuarioDTO)
        {
            if (_usuarioService.AddUsuario(_mapper.Map<Usuario>(usuarioDTO)) != null)
                return Ok("Usuario creado correctamente.");
               
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<String> DeleteUsuario(long id)
        {
            if (_usuarioService.DeleteUsuario(id) != null)
                return Ok("Usuario eliminado correctamente");

                return NotFound();
        }


    }
}
