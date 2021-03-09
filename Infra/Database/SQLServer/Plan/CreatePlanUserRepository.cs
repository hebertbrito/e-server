using Data.Protocols.Database.Plan;
using Domain.Models.Plan.Request;
using Infra.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Database.SQLServer.Plan
{
    public class CreatePlanUserRepository : ICreatePlanUserRepository
    {
        private readonly IDatabaseHelperClass databaseHelperClass;
        const string TABLE_NAME = "Planos";

        public CreatePlanUserRepository(IDatabaseHelperClass databaseHelperClass)
        {
            this.databaseHelperClass = databaseHelperClass;
        }

        public async Task CreatePlanUser(PlanModel planModel)
        {
            var query = this.CreateQuery(planModel);
            this.ExecutionQuery(query);
            await Task.Delay(1000);
        }

        public StringBuilder CreateQuery(PlanModel planModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO '"+ TABLE_NAME +"' ");
            sql.Append(@" VALUES ('" + planModel.PlanName + "', '" + planModel.Name + "', '" + planModel.StartDatePlan + "', '" + planModel.EndDatePlan + "', " +
                "'" + planModel.TypePerson + "') ");

            return sql;
        }

        public async void ExecutionQuery(StringBuilder sql)
        {
            using (this.databaseHelperClass.connection)
            {
                this.databaseHelperClass.connection.Open();
                this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
                await this.databaseHelperClass.command.ExecuteReaderAsync();
                this.databaseHelperClass.connection.Close();
            }
        }
    }
}
