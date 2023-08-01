using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ServiceContext _serviceContext;

        public UserController(IUserService userService, ServiceContext serviceContext)
        {
            _userService = userService;
            _serviceContext = serviceContext;
        }

        [HttpPost(Name = "InsertUsers")]

        public IActionResult Post([FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] UserItem userItem)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.User_Name == userUser_Name
                                    && u.Password == userPassword
                                    && u.IdRoll == 1)
                                .FirstOrDefault();


            if (seletedUser != null)
            {
                int userId = _userService.insertUsers(userItem);
                return Ok(userItem);

            }
            else
            {
                return Unauthorized("El Usuario no Existe");
            }


        }

        [HttpPut(Name = "UpdateUser")]

        public IActionResult UpdateUser(int userId, [FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] UserItem updatedUser)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.User_Name == userUser_Name
                                    && u.Password == userPassword
                                    && u.IdRoll == 1)
                                .FirstOrDefault();


            if (seletedUser != null)
            {
                var user = _serviceContext.Users.FirstOrDefault(p => p.IdUsuario == userId);


                if (user != null)
                {
                    user.User_Name = updatedUser.User_Name;
                    user.IdRoll = updatedUser.IdRoll;
                    user.Password = updatedUser.Password;
                    user.Email = updatedUser.Email;

                    _serviceContext.SaveChanges();

                    return Ok("El Usuario se ha modificado correctamente");

                }
                else
                {
                    return NotFound("No se ha encontrado el Usuario");
                }

            } 
            else
            {
                return Unauthorized("El usuario no esta autorizado");
            }


        }

        [HttpDelete("{userId}", Name = "DeleteUser")]

        public IActionResult Delete(int userId, [FromQuery] string userUser_Name, [FromQuery] string userPassword)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.User_Name == userUser_Name
                                    && u.Password == userPassword
                                    && u.IdRoll == 1)
                                .FirstOrDefault();

            if (seletedUser != null)
            {
                var user = _serviceContext.Users.Find(userId);

                if (user != null)
                {
                    bool isDeleted = _serviceContext.RemoveUserById(userId);

                    if (isDeleted)
                    {
                        return Ok("El usuario se ha eliminado");
                    }
                    else
                    {
                        return BadRequest("Error al eliminar");
                    }

                }
                else
                {
                    return NotFound("No se ha encontrado");
                }


            }
            else
            {
                return Unauthorized("El usuario no esta actualizado");

            }

        }


    }


}
