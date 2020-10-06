using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Booking
    {
        [Key]
        public int A_ID { get; set; }


     
        public DateTime A_LEASE_START_DATE { get; set; }

        public DateTime A_LEASE_END_DATE { get; set; }
        public int A_TENURE { get; set; }

        public int A_PRICE { get; set; }

        [ForeignKey("TBL_USER")]
        public int A_FK_USERID { get; set; }
        public TBL_USER TBL_USER { get; set; }

        [ForeignKey("Car")]
        public int A_FK_CARID { get; set; }
        public Car Car { get; set; }





    }
}
