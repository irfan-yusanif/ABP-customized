using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Abp.AutoMapper;
using Final1.Users.Dto;
using Final1.Global;

namespace Final1.Web.Models.UserProfile
{
    [AutoMapFrom(typeof(UserListDto))]
    //[AutoMapTo(typeof(UserListDto))]

    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

       // [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        public static IEnumerable<SelectListItem> UserRolesSelectList()
        {
            return StaticDictionaries.UserRoles.Select(p => new SelectListItem { Value = p.Value, Text = p.Key }).AsEnumerable();
        }

        public bool IsActive { get; set; }
        //[Display(Name = "Do Not Send Me Email Notices")]
        //public bool EmailNoticeOptOut { get; set; }

        //[Display(Name = "Last Login")]
        //public DateTime? LastLogin { get; set; }
    }
}