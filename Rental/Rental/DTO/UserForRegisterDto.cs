using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.DTO
{
    public class UserForRegisterDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
    }
}
