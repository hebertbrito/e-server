using Domain.Models.UserPlan.Request;
using Domain.Models.UserPlan.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Protocols.Database.UserPlan
{
    public interface IGetListUserPlanRepository
    {
        Task<UserPlanModelResponse[]> GetUSerPlanList(UserPlanModel userPlanModel);
    }
}
