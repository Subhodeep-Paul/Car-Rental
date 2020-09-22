using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rental.Models
{
    public class TBL_USER
    {
        [Key]
        public int A_ID { get; set; }
        public string A_FIRST_NAME { get; set; }
        public string A_LAST_NAME { get; set; }
        public string A_EMAIL { get; set; }

        public string A_PASSWORD { get; set; }


    }
}