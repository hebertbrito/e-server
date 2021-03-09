using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.Plan.Request
{
    public class PlanModel
    {
        [Required]
        [StringLength(100)]
        public string PlanName { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string StartDatePlan { get; set; }

        [Required]
        [StringLength(100)]
        public string EndDatePlan { get; set; }

        [Required]
        [StringLength(100)]
        public string TypePerson { get; set; }

        [Required]
        [StringLength(100)]
        public string RegisterDate { get; set; }
    }
}
