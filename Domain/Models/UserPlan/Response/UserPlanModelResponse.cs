using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.UserPlan.Response
{
    public class UserPlanModelResponse
    {
        [StringLength(100)]
        public string PlanName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string RegisterDate { get; set; }
    }
}
