using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rental.Models
{
    public class TBL_USER
    {
        [Key]
        public int  A_ID { get; set; }
        public string A_FIRST_NAME { get; set; }
        public string A_LAST_NAME { get; set; }
        public string A_EMAIL { get; set; }

        public byte[] A_PASSWORD_HASH{ get; set; }

        public byte[] A_PASSWORD_SALT { get; set; }

        public string A_CITY { get; set; }

        public bool A_IS_ADMIN { get; set; }

        public ICollection<Booking> A_BOOKING { get; set; }



    }
}