using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSMVC.ViewModel
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }


        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email ID")]
        [EmailAddress]
        public string emailID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}