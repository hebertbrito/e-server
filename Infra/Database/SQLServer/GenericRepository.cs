using Domain.Models.GenericModel;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.SQLServer
{
    public class GenericRepository
    {
        private readonly IDatabaseHelperClass databaseHelperClass;
        const string TABLE_NAME = "Planos";
        public string ID { get; set; }
        public string TypeUser { get; set; }
        private object MyProperty { get; set; }

        delegate void DelegateMapper();
        public GenericRepository(IDatabaseHelperClass databaseHelperClass)
        {
            this.databaseHelperClass = databaseHelperClass;
        }


        public async Task<GenericModel> GetUserByName(String Name)
        {
            var query = this.CreateQueryByName(Name);
            this.ExecutionQueryByName(query);
            await Task.Delay(1000);
            GenericModel genericModel = new GenericModel();
            if (this.ID != null && this.ID != "0")
            {
                genericModel.ID = Convert.ToInt32(this.ID);
            }

            if (this.ID != null)
            {
                genericModel.TypeUser = this.TypeUser;
            }
            return genericModel;
        }

        public async Task<bool> GetValidateWithPJ(int ID)
        {
            var query = this.HasValueWithPJ(ID);
            var idValid = this.ExecutionQueryValidateWithPJ(query);
            await Task.Delay(1000);
            if (idValid)
            {
                return false;
            }
            return true;
        }

        public StringBuilder CreateQueryByName(String Name)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ID, TypeUser FROM Users where name = '" + Name + "' ");
            return sql;
        }

        public StringBuilder HasValueWithPJ(int ID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT ID FROM Plans where IdUser = '" + ID + "' ");
            return sql;
        }

        public void ExecutionQueryByName(StringBuilder sql)
        {
            
                this.databaseHelperClass.connection.Open();
                this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
                this.MapperByName(this.databaseHelperClass.command.ExecuteReader());
                this.databaseHelperClass.connection.Close();

        }

        public bool ExecutionQueryValidateWithPJ(StringBuilder sql)
        {
            this.databaseHelperClass.connection.Open();
            this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
            var response = this.VerifyValidateWithPJ(this.databaseHelperClass.command.ExecuteReader());
            this.databaseHelperClass.connection.Close();

            return response;
        }

        public bool VerifyValidateWithPJ(SqlDataReader reader)
        {
            if (reader.HasRows)
            {
                return true;
            }

            return false;
        }

        public void MapperByName(SqlDataReader reader)
        {

            if (reader.Read())
            { 
                this.ID = reader.GetValue(0).ToString();
                this.TypeUser = reader.GetValue(1).ToString();
            }
            else
            {
                this.ID = "0";
                this.TypeUser = null;
            }
        }
    }
}
