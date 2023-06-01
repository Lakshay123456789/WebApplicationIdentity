using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationIdentity.Models
{
    public class SignUpUserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="please enter your first name")]

        public string FirstName { get;set; }

        public string LastName { get;set; } 

        [Required(ErrorMessage ="please enter your email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="please entre a strong password ")]
        [Compare("ConfirmPassword",ErrorMessage ="please does not match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "please Confirm your password ")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
