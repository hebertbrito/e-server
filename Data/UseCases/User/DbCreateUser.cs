using Domain.Models.User.Request;
using Domain.UseCases.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UseCases.User
{
    public class DbCreateUser : ICreateUser
    {
        public async Task CreateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
