using Microsoft.AspNetCore.Mvc;
using SixDegreesIt.Business.Helpers;
using SixDegreesIt.Business.Models;
using SixDegreesIt.DataAccess.Usuarios;
using SixDegreesIt.DataAccess.Models;
using SixDegreesIt.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SixDegreesIt.DataAccess.Helpers;

namespace SixDegreesIt.Business.Usuario
{
    public class Usuario : IUsuario
    {
        private readonly IUsuarioDAO _usuario;
        private readonly IModelHelper _modelHelper;
        private readonly IUserHelper _userHelper;

        public Usuario(
            IUsuarioDAO usuario, 
            IModelHelper modelHelper,
            IUserHelper userHelper)
        {
            _usuario = usuario;
            _modelHelper = modelHelper;
            _userHelper = userHelper;
        }

        public async Task<ActionResult<UserResponse>> GetAllUsersAsync()
        {
            try
            {
                IEnumerable<UsuarioEntity> usuarios = await _usuario.GetUsuariosAsync();
                if (usuarios == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        Messaje = "No hay usuarios registrados en la base de datos",
                        Result = new NotFoundResult()
                    };
                }

                return new UserResponse
                {
                    IsSuccess = true,
                    Result = usuarios
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = ex.Message,
                    Result = new BadRequestResult()
                };
            }
        }

        public async Task<ActionResult<UserResponse>> GetUserByIdAsync(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        Messaje = "Error: Id nulo!",
                        Result = new BadRequestResult()
                    };
                }

                UsuarioEntity usuario = await _usuario.GetUsuarioByIdAsync(id);
                if (usuario == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        Messaje = "Error: Usuario no existe!",
                        Result = new NotFoundResult()
                    };
                }

                return new UserResponse
                {
                    IsSuccess = true,
                    Result = usuario
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = ex.Message,
                    Result = new BadRequestResult()
                };
            }
        }

        public async Task<ActionResult<UserResponse>> UpdateUserAsync(int id, UserRequest request)
        {
            if (!id.Equals(request.Id))
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = "Error: Id errado!",
                    Result = new BadRequestResult()
                };
            }

            UserModel model = _modelHelper.RequestToModel(request);
            UsuarioEntity userEntity = _userHelper.ModelToUserEntity(model);
            try
            {
                await _usuario.UpdateUserAsync(userEntity);
                return new UserResponse
                {
                    IsSuccess = true,
                    Result = new NoContentResult()
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = ex.Message,
                    Result = new BadRequestResult()
                };
            }
        }

        public async Task<ActionResult<UserResponse>> AddUserAsync(UserRequest request)
        {
            UserModel model = _modelHelper.RequestToModel(request);
            UsuarioEntity userEntity = _userHelper.ModelToUserEntity(model);
            try
            {
                await _usuario.AddUserAsync(userEntity); 
                return new UserResponse
                {
                    IsSuccess = true,
                    Result = new NoContentResult()
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = ex.Message,
                    Result = new BadRequestResult()
                };
            }
        }

        public async Task<ActionResult<UserResponse>> DeleteUserAsync(int id)
        {
            try
            {
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        Messaje = "Error: Id nulo!",
                        Result = new BadRequestResult()
                    };
                }

                UsuarioEntity usuario = await _usuario.GetUsuarioByIdAsync(id);
                if (usuario == null)
                {
                    return new UserResponse
                    {
                        IsSuccess = false,
                        Messaje = "Error: Usuario no existe!",
                        Result = new NotFoundResult()
                    };
                }

                await _usuario.DeleteUserAsync(usuario);

                return new UserResponse
                {
                    IsSuccess = true,
                    Result = new NoContentResult()
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    IsSuccess = false,
                    Messaje = ex.Message,
                    Result = new BadRequestResult()
                };
            }
        }
    }
}
