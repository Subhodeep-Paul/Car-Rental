using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Data
{
    public class CheckoutRepository : ICheckoutRepository

    {

        private readonly DataContext _context;
        public CheckoutRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Booking> Book(Booking user)
        {
            await _context.TBL_BOOKING.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

            

        }
    }
}
