using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models.User.Request
{
    public class UserModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
        [StringLength(100)]
        public string CPF { get; set; }

        
        [StringLength(100)]
        public string RG { get; set; }

        
        [StringLength(100)]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string DateBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string RegisterDate { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeUser { get; set; }
    }
}
