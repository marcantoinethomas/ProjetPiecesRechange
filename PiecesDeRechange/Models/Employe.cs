using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PiecesDeRechange.Models
{
    public class Employe
    {
        public int ID { get; set; }

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

        [Display(Name = "TypeEmp", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
           ErrorMessageResourceName = "TypeEmpRequired")]
        public int TypeEmp { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(8, ErrorMessageResourceType = typeof(Resources.Resources),
                          ErrorMessageResourceName = "PasswordLong")]
        public string Password { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "EmailRequired")]
        [RegularExpression(".+@.+\\..+", ErrorMessageResourceType = typeof(Resources.Resources),
                                         ErrorMessageResourceName = "EmailInvalid")]
        public string Email { get; set; }

        public string Statut { get; set; }
        public string DescripType { get; set; }
        public string DescripStatut { get; set; }
    }




}