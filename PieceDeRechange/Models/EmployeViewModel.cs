using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PieceDeRechange.Models
{
    public class Login
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }

    
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class RegisterViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "FirstNameRequired")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "LastNameRequired")]
        public string LastName { get; set; }

        [Display(Name = "Street", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
          ErrorMessageResourceName = "StreetRequired")]
        public string Street { get; set; }

        [Display(Name = "NumberApp", ResourceType = typeof(Resources.Resources))]
        public string NumberApp { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
          ErrorMessageResourceName = "CityRequired")]
        public string City { get; set; }

        [Display(Name = "Province", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
           ErrorMessageResourceName = "ProvinceRequired")]
        public string Province { get; set; }

        [Display(Name = "CodePostal", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
           ErrorMessageResourceName = "CodePostalRequired")]
        public string CodePostal { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PasswordRequired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}