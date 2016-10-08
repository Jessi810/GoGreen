using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GoGreenV3.Models;

namespace GoGreenV3.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
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

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,100}$", ErrorMessage = "{0} should only contain letters and hyphen and 2-100 in length")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,100}$", ErrorMessage = "{0} should only contain letters and hyphen and 2-100 in length")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "{0} is invalid")]
        [Display(Name = "Cellphone #")]
        public string CellphoneNumber { get; set; }

        [RegularExpression(@"^[0-9]{7}$", ErrorMessage = "{0} is invalid.")]
        [Display(Name = "Telephone #")]
        public string TelephoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Agency Type")]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        [Required]
        [Display(Name = "Agency Name")]
        public string Agency { get; set; }
        
        public IEnumerable<SelectListItem> Hospitals { get; set; }

        public IEnumerable<SelectListItem> PoliceDepartments { get; set; }

        public IEnumerable<SelectListItem> FireStations { get; set; }

        public IEnumerable<SelectListItem> Agencies { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Member Since")]
        public DateTime MemberSince { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Last Active")]
        public DateTime LastActive { get; set; }

        [DataType(DataType.ImageUrl)]
        public string AvatarUrl { get; set; }
    }

    public class EditProfileViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,100}$", ErrorMessage = "{0} should only contain letters and hyphen and 2-100 in length")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,100}$", ErrorMessage = "{0} should only contain letters and hyphen and 2-100 in length")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [RegularExpression(@"^09[0-9]{9}$", ErrorMessage = "{0} is invalid")]
        [Display(Name = "Cellphone #")]
        public string CellphoneNumber { get; set; }

        [RegularExpression(@"^[0-9]{7}$", ErrorMessage = "{0} is invalid.")]
        [Display(Name = "Telephone #")]
        public string TelephoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Agency Type")]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        [Required]
        [Display(Name = "Agency Name")]
        public string Agency { get; set; }

        public IEnumerable<SelectListItem> Agencies { get; set; }
        public IEnumerable<SelectListItem> Hospitals { get; internal set; }
        public IEnumerable<SelectListItem> PoliceDepartments { get; internal set; }
        public IEnumerable<SelectListItem> FireStations { get; internal set; }
    }

    public class EditAgencyViewModel
    {

        [Required]
        [Display(Name = "Agency Type")]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> Types { get; set; }

        [Required]
        [Display(Name = "Agency Name")]
        public string Agency { get; set; }

        public IEnumerable<SelectListItem> Agencies { get; set; }
        public IEnumerable<SelectListItem> Hospitals { get; internal set; }
        public IEnumerable<SelectListItem> PoliceDepartments { get; internal set; }
        public IEnumerable<SelectListItem> FireStations { get; internal set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
