using Data.Protocols.Database.User;
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
        private readonly ICreateUserRepository createUserRepository;
        public DbCreateUser(ICreateUserRepository createUserRepository)
        {
            this.createUserRepository = createUserRepository;
        }

        public async Task CreateUser(UserModel userModel)
        {
            await this.createUserRepository.CreateUser(userModel);
        }
    }
}
