using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Data
{
    public interface IAuthRepository
    {
        Task<TBL_USER> Register(TBL_USER user, string password);

        Task<TBL_USER> Login(string email, string password,string firstname);

        Task<bool> EmailExists(string username);

     
    }
}
