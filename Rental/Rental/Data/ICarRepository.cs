using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Data
{
    public interface ICarRepository
    {
       
        public Task<Car[]> GetCar();
        public Task<Car> GetCar(int id);
        public Task<Car> UpdateAvailability(int id);
        public void AddCar(Car car);
        public Task<bool> SaveChangesAsync();
    }
}
