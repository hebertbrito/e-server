using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.UserPlan.Request
{
    public class UserPlanModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string CPF { get; set; }

        [StringLength(100)]
        public string CNPJ { get; set; }

        [StringLength(100)]
        public string RegisterDate { get; set; }
    }
}
