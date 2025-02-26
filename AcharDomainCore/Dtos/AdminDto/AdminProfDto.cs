using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Http;

namespace AcharDomainCore.Dtos.AdminDto
{
    public class AdminProfDto
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
        public decimal Balance { get; set; }
        public IFormFile? ImageFile { get; set; }


    }
}
