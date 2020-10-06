using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Car
    {
        [Key]
        public int A_ID { get; set; }
        public string A_COMPANY { get; set; }
        public string A_MODEL { get; set; }
        public int A_DISTANCE_DRIVEN { get; set; }
        public int A_NUMBER_OF_SEATS { get; set; }
        public string A_FUEL_TYPE { get; set; }
        public string A_TRANSMISSION { get; set; }
        public bool A_IS_AVAILABLE { get; set; }

        public int A_PRICE { get; set; }

        public ICollection<Booking> A_BOOKING { get; set; }




    }
}
