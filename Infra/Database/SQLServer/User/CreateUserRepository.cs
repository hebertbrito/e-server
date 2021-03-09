using Data.Protocols.Database.User;
using Domain.Models.User.Request;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.SQLServer.User
{
    public class CreateUserRepository : ICreateUserRepository
    {
        private readonly IDatabaseHelperClass databaseHelperClass;
        const string TABLE_NAME = "Users";
        public CreateUserRepository(IDatabaseHelperClass databaseHelperClass)
        {
            this.databaseHelperClass = databaseHelperClass;
        }

        public async Task CreateUser(UserModel userModel)
        {
            var query = this.CreateQuery(userModel);
            this.ExecutionQuery(query);
            await Task.Delay(1000);
        }


        public StringBuilder CreateQuery(UserModel userModel)
        {
            var sql = this.databaseHelperClass.query;

            sql.Append(" INSERT INTO " + TABLE_NAME);
            sql.Append(@" VALUES ('" + userModel.Username + "', '" + userModel.RG + "', '" + userModel.CPF + "', '" + userModel.CNPJ + "', '" + userModel.Email + "', " +
                "'" + userModel.Telephone + "', '" + userModel.DateBirth + "', '" + userModel.RegisterDate + "') ");

            return sql;
        }

        public async void ExecutionQuery(StringBuilder sql)
        {
            using (this.databaseHelperClass.connection)
            {
                this.databaseHelperClass.connection.Open();
                this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
                await this.databaseHelperClass.command.ExecuteReaderAsync();
            }
        }
    }
}
