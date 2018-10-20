using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PiecesDeRechange.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RememberBrowser", ResourceType = typeof(Resources.Resources))]
        public bool RememberBrowser { get; set; }

        [Display(Name = "Remember", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(8, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "PasswordLong")]
        public string Password { get; set; }

        [Display(Name = "Remember", ResourceType = typeof(Resources.Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "FirstNameLong")]
        public string FirstName { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(5, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "LastNameLong")]
        public string LastName { get; set; }

        [Display(Name = "Street", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
          ErrorMessageResourceName = "StreetRequired")]
        public string Street { get; set; }

        [Display(Name = "NumberApp", ResourceType = typeof(Resources.Resources))]
        public string NoApp { get; set; }

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
        [StringLength(8, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "PasswordLong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password", ErrorMessageResourceName = "ComparePasswordError")]
        public string ConfirmPassword { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(8, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "PasswordLong")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources.Resources))]
        [Compare("Password", ErrorMessageResourceName = "ComparePasswordError")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
