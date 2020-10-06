using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rental.DTO;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Data
{
    public class CarRepository : ICarRepository
    {

        private readonly DataContext _context;
        public CarRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCar(Car car)
        {
            _context.TBL_CAR.Add(car);
        }

        public async Task<Car> UpdateAvailability(int id)
        {
            var car=await _context.TBL_CAR.FirstOrDefaultAsync(x => x.A_ID == id);

            if(car != null)
            {
                car.A_IS_AVAILABLE = !car.A_IS_AVAILABLE;
              
            }

            return car;



        }

        public async Task<Car> GetCar(int id)
        {
            IQueryable<Car> query = _context.TBL_CAR;
           
            return await query.Include(p => p.A_BOOKING).FirstOrDefaultAsync(x => x.A_ID == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        async Task<Car[]> ICarRepository.GetCar()
        {
            IQueryable<Car> query = _context.TBL_CAR;
            query = query.OrderBy(x => x.A_DISTANCE_DRIVEN);
            return await query.ToArrayAsync();
        }




    }
}
