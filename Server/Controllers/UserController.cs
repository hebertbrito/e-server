using Data.UseCases.User;
using Domain.Models.User.Request;
using Infra.Database.SQLServer.User;
using Infra.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [Route("user/create")]
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserModel userModel)
        {
            DatabaseHelperClass databaseHelperClass = new DatabaseHelperClass("Password=123456789;Persist Security Info=True;User ID=sqlserver;Initial Catalog=epharma;Data Source=34.95.222.223");

            try
            {
                if(!ModelState.IsValid){
                    throw new Exception("Model is Invalid");
                }
                CreateUserRepository createUserRepository = new CreateUserRepository(databaseHelperClass);
                DbCreateUser dbCreateUser = new DbCreateUser(createUserRepository);

                await dbCreateUser.CreateUser(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                databaseHelperClass.connection.Close();
                return StatusCode(500, ex);
            }
        }
    }
}
