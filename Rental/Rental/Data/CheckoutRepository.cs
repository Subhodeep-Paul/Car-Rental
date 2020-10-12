using Microsoft.EntityFrameworkCore;
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

        public void DeleteBooking(Booking booking)
        {
            _context.TBL_BOOKING.Remove(booking);
        }

        public async Task<Booking> GetBooking(int id)
        {
            IQueryable<Booking> query = _context.TBL_BOOKING;

            return await query.FirstOrDefaultAsync(x => x.A_ID == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
