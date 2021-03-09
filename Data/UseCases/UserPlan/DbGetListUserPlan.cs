using Data.Protocols.Database.UserPlan;
using Domain.Models.UserPlan.Request;
using Domain.Models.UserPlan.Response;
using Domain.UseCases.UserPlan;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.UseCases.UserPlan
{
    public class DbGetListUserPlan : IGetListUserPlan
    {

        private readonly IGetListUserPlanRepository getListUserPlanRepository;

        public DbGetListUserPlan(IGetListUserPlanRepository getListUserPlanRepository)
        {
            this.getListUserPlanRepository = getListUserPlanRepository;
        }
        public async Task<UserPlanModelResponse[]> GetUSerPlanList(UserPlanModel userPlanModel)
        {
            var response = await this.getListUserPlanRepository.GetUSerPlanList(userPlanModel);

            return response;
        }
    }
}
