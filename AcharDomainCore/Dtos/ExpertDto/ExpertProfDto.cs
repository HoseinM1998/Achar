using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.AspNetCore.Http;

namespace AcharDomainCore.Dtos.ExpertDto
{
    public class ExpertProfDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string? Street { get; set; }
        public string? Email { get; set; }
        [DisplayName(" عکس پروفایل")]
        public string? ProfileImageUrl { get; set; }
        [DisplayName("شماره تلفن")]
        public string? PhoneNumber { get; set; }
        [DisplayName(" جنسیت")]
        public GenderEnum? Gender { get; set; }
        [DisplayName(" شهر")]
        public string? NameCity { get; set; }
        [DisplayName(" مهارت ها")]
        public List<Entites.HomeService>? Skills { get; set; }
        public List<int>? ServiceIds { get; set; }
        public int? Score { get; set; }
        public int ApplictaionUserId { get; set; }

        public bool IsActive { get; set; }
        public decimal Balance { get; set; }
        public int CityId { get; set; }
        public IFormFile? ImageFile { get; set; }
        public Comment? Comment { get; set; }



    }
}
