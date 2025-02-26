using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Enums;

namespace AcharDomainCore.Dtos.CustomerDto
{
    public class CustomerGetAll
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        [DisplayName(" عکس پروفایل")]
        public string? ProfileImageUrl { get; set; }
        [DisplayName("شماره تلفن")]
        public string? PhoneNumber { get; set; }
        [DisplayName(" جنسیت")]
        public GenderEnum? Gender { get; set; }
        [DisplayName(" شهر")]
        public string NameCity { get; set; }
        public decimal Balance { get; set; }
    }
}
