using Domain.Models.UserPlan.Request;
using Domain.Models.UserPlan.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UserPlan
{
    public interface GetListUserPlan
    {
        Task<UserPlanModelResponse[]> GetUSerPlanList(UserPlanModel userPlanModel);
    }
}
