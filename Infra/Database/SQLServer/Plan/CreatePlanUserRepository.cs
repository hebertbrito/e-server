using Data.Protocols.Database.Plan;
using Domain.Models.GenericModel;
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
        private readonly GenericRepository genericRepository;
        const string TABLE_NAME = "Planos";

        public CreatePlanUserRepository(IDatabaseHelperClass databaseHelperClass)
        {
            this.databaseHelperClass = databaseHelperClass;
            this.genericRepository = new GenericRepository(this.databaseHelperClass);
        }

        public async Task CreatePlanUser(PlanModel planModel)
        {
            var value = await this.genericRepository.GetUserByName(planModel.NameUser);
            if (await this.ValidateVerifyTypeUser(value))
            {
                planModel.IdUser = Convert.ToInt32(value.ID);
                var query = this.CreateQuery(planModel);
                this.ExecutionQuery(query);
                await Task.Delay(1000);
            }
            else
            {
                throw new Exception("The PJ user type cannot have more than 1 plan relationship");
            }
            
        }

        public StringBuilder CreateQuery(PlanModel planModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO Plans ");
            sql.Append(@" VALUES ('" + planModel.IdUser + "', '" + planModel.StartDatePlan + "', '" + planModel.EndDatePlan + "', '" + planModel.RegisterDate + "') ");

            return sql;
        }

        public void ExecutionQuery(StringBuilder sql)
        {
            using (this.databaseHelperClass.connection)
            {
                this.databaseHelperClass.connection.Open();
                this.databaseHelperClass.command = new System.Data.SqlClient.SqlCommand(sql.ToString(), this.databaseHelperClass.connection);
                this.databaseHelperClass.command.ExecuteReader();
                this.databaseHelperClass.connection.Close();
            }
        }

        public async Task<bool> ValidateVerifyTypeUser(GenericModel genericModel)
        {
            if(genericModel.ID > 0)
            {
                if (genericModel.TypeUser != null)
                {
                    if (genericModel.TypeUser == "2")
                    {
                        return await this.genericRepository.GetValidateWithPJ(genericModel.ID);

                    }
                }
            }

            return true;
        }
    }
}
