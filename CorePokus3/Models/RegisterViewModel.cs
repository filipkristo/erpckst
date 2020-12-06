using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorePokus3.Models
{
    public class RegisterViewModel
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Firstname should be more than 2 characters")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int PIN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsVolunteer { get; set; }
        public bool IsOutsorced { get; set; }
       
        public string Login { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
    }
}
