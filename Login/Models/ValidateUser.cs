using System;
using System.ComponentModel.DataAnnotations;

namespace Login.Models{

    public class ValidateUser
    {
     

        [Required(ErrorMessage="Must Provide First Name")]
        [MinLength(3, ErrorMessage="First Name Must Be Atleast 3 Characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Must Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [MinLength(8)]
        [Required(ErrorMessage="Please provide password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        
        
       
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords must match")]
        public string ConfirmPassword{get;set;}

        [Required(ErrorMessage = "Please provide your age")]
        [Range(0, 100)]
        public int Age { get; set; }
    }








}