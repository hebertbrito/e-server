using Data.Protocols.Database.UserPlan;
using Domain.Models.UserPlan.Request;
using Domain.Models.UserPlan.Response;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.SQLServer.UserPlan
{
    public class GetListUserPlanRepository : IGetListUserPlanRepository
    {

        private readonly IDatabaseHelperClass databaseHelperClass;
        public List<UserPlanModelResponse> LstUserPlan = new List<UserPlanModelResponse>();
        public GetListUserPlanRepository(IDatabaseHelperClass databaseHelperClass)
        {
            this.databaseHelperClass = databaseHelperClass;
        }

        public async Task<List<UserPlanModelResponse>> GetUSerPlanList(UserPlanModel userPlanModel)
        {
            var query  = this.CreateQuery(userPlanModel);
            this.ExecutionQuery(query);
            await Task.Delay(1000);
            return LstUserPlan;
        }


        public void ExecutionQuery(StringBuilder sql)
        {
            using (this.databaseHelperClass.connection)
            {
                this.databaseHelperClass.connection.Open();
                this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
                this.MapperGetListPlanUser(this.databaseHelperClass.command.ExecuteReader());
                this.databaseHelperClass.connection.Close();
            }
        }

        public void MapperGetListPlanUser(SqlDataReader reader)
        {            
            while (reader.Read())
            {
                Object[] values = new Object[reader.FieldCount];
                int fieldCount = reader.GetValues(values);

                Dictionary<string, string> teste = new Dictionary<string, string>();

                List<string> LstColumn = new List<string>();
                LstColumn.Add("Name");
                LstColumn.Add("PlanName");
                LstColumn.Add("RegisterDate");

                for (int i = 0; i < fieldCount; i++)
                {
                    teste.Add(LstColumn[i], values[i].ToString());
                }
                this.ConvertToModelResponse(teste);
            }
        }


        public void ConvertToModelResponse(Dictionary<string, string> value)
        {
            UserPlanModelResponse userPlanModelResponse = new UserPlanModelResponse();

            foreach (var item in value)
            {
                if ("Name" == item.Key)
                {
                    userPlanModelResponse.Name = item.Value;
                }

                if ("PlanName" == item.Key)
                {
                    userPlanModelResponse.PlanName = item.Value;
                }

                if ("RegisterDate" == item.Key)
                {
                    userPlanModelResponse.RegisterDate = item.Value;
                }
            }

            LstUserPlan.Add(userPlanModelResponse);
        }

        public StringBuilder CreateQuery(UserPlanModel userPlanModel)
        {
            StringBuilder sql = new StringBuilder();
            StringBuilder end = new StringBuilder();
            StringBuilder middle = new StringBuilder();
            sql.Append(" SELECT Users.Name, Plans.PlanName, Users.RegisterDate ");
            sql.Append(" FROM  Users ");
            middle.Append(" INNER JOIN Plans on Plans.IdUser = Users.ID ");
            end.Append(" WHERE ");
            var counter = 0;
            if (userPlanModel.Name != null && userPlanModel.Name != "")
            {
                end.Append(" Users.Name = '" + userPlanModel.Name.ToString() + "' ");
                counter = ++counter;
            }

            if (userPlanModel.RegisterDate != null && userPlanModel.RegisterDate != "")
            { 
                if (counter > 0)
                {
                    end.Append(" AND Users.RegisterDate = '" + userPlanModel.RegisterDate.ToString() + "' ");
                }
                else
                { 
                    end.Append(" Users.RegisterDate =  '" + userPlanModel.RegisterDate.ToString() + "' ");
                }
                counter = ++counter;
            }

            if (userPlanModel.CNPJ != null && userPlanModel.CNPJ != "")
            {
                if (counter > 0)
                {
                    end.Append(" AND Users.CNPJ = '" + userPlanModel.CNPJ.ToString() + "' ");
                }
                else
                {
                    end.Append(" Users.CNPJ = '" + userPlanModel.CNPJ.ToString() + "' ");
                }
                counter = ++counter;
            }

            if (userPlanModel.CPF != null && userPlanModel.CPF != "")
            {
                if (counter > 0)
                {
                    end.Append(" AND Users.CPF = '" + userPlanModel.CPF.ToString() + "' ");
                }
                else
                { 
                    end.Append(" Users.CPF = '" + userPlanModel.CPF.ToString() + "' ");
                }
                counter = ++counter;
            }

            sql.Append(middle);

            if(counter > 0)
            {
                sql.Append(end);
            }


            return sql;
        }

    }
}
