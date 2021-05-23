using Microsoft.AspNetCore.Mvc;
using SixDegreesIt.Business.Models;
using SixDegreesIt.Business.Usuario;
using System.Threading.Tasks;

namespace SixDegreesIt.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuario _usuario;

        public UsuariosController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetUsuarios()
        {
            return await _usuario.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUsuarioEntity(int id)
        {
            return await _usuario.GetUserByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> PutUsuarioEntity(int id, UserRequest request)
        {
            return await _usuario.UpdateUserAsync(id, request);
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUsuarioEntity(UserRequest request)
        {
            return await _usuario.AddUserAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUsuarioEntity(int id)
        {
            return await _usuario.DeleteUserAsync(id);
        }
    }
}
