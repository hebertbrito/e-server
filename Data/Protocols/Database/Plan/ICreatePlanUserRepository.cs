using Domain.Models.Plan.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Protocols.Database.Plan
{
    public interface ICreatePlanUserRepository
    {
        Task CreatePlanUser(PlanModel planModel);
    }
}
