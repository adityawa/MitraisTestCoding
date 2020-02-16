using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitraisCodingTest.Service.Models
{
    public class RegistrationModel : BaseModel
    {
        [Required(ErrorMessage = "Mobile No is required")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public char Gender { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

    }
}
