using Microsoft.AspNetCore.Mvc;
using SixDegreesIt.Business.Models;
using SixDegreesIt.DataAccess.Models;
using System.Threading.Tasks;

namespace SixDegreesIt.Business.Usuario
{
    public interface IUsuario
    {
        Task<ActionResult<UserResponse>> GetAllUsersAsync();
        Task<ActionResult<UserResponse>> GetUserByIdAsync(int id);
        Task<ActionResult<UserResponse>> UpdateUserAsync(int id, UserRequest request);
        Task<ActionResult<UserResponse>> AddUserAsync(UserRequest request);
        Task<ActionResult<UserResponse>> DeleteUserAsync(int id);
    }
}
