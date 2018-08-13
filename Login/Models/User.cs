using System;
using System.ComponentModel.DataAnnotations;

namespace Login.Models{

    public class User{

        [Key]
        
        public int UserId{get;set;}
        public string Name{ get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; } 

        [DataType(DataType.Password)]
        
        public string Password{ get; set; }

        public int Age{ get; set; } 
    }








}