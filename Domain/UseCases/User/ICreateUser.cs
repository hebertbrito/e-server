using Domain.Models.User.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.User
{
    public interface ICreateUser
    {
        Task CreateUser(UserModel userModel);
    }
}
