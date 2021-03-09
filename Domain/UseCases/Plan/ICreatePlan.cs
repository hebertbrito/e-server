using Domain.Models.Plan.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Plan
{
    public interface ICreatePlan
    {
        Task CreatePlanUser(PlanModel userModel);
    }
}
