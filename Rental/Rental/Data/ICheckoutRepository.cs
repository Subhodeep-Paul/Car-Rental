using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Data
{
    public interface ICheckoutRepository
    {
        public Task<Booking> Book(Booking user);
        public void DeleteBooking(Booking booking);

        public Task<Booking> GetBooking(int id);
        public Task<bool> SaveChangesAsync();
       
    }
}
