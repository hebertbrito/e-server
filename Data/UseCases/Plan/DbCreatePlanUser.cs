using Data.Protocols.Database.Plan;
using Domain.Models.Plan.Request;
using Domain.UseCases.Plan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UseCases.Plan
{
    public class DbCreatePlanUser : ICreatePlan
    {
        private readonly ICreatePlanUserRepository createPlanUserRepository;
        public DbCreatePlanUser(ICreatePlanUserRepository createPlanUserRepository)
        {
            this.createPlanUserRepository = createPlanUserRepository;
        }
        public async Task CreatePlanUser(PlanModel planModel)
        {
            await this.createPlanUserRepository.CreatePlanUser(planModel);
        }
    }
}
