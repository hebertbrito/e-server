using Domain.Models.User.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Protocols.Database.User
{
    public interface ICreateUserRepository
    {
        Task CreateUser(UserModel userModel);
    }
}
