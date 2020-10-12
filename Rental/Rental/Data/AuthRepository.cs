using Microsoft.EntityFrameworkCore;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Rental.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }




        public async Task<TBL_USER> Login(string emailid, string password, string firstname, bool isadmin)
        {
            var email = await _context.TBL_USER.FirstOrDefaultAsync(x => x.A_EMAIL == emailid) ;

            if (email == null)
                return null;

            if (!VerifyPasswordHash(password,email.A_PASSWORD_HASH , email.A_PASSWORD_SALT))
                return null;

            return email;




        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i=0;i<computedHash.Length;i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }

            }
            return true;
        }

        public async Task<TBL_USER> Register(TBL_USER user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordhash(password, out passwordHash, out passwordSalt);
            //out passes a ref of passwordHash

            user.A_PASSWORD_HASH = passwordHash;
            user.A_PASSWORD_SALT = passwordSalt;

            await _context.TBL_USER.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;

        }

        private void CreatePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
            

        }

        public async Task<bool> EmailExists(string email)
        {
            if (await _context.TBL_USER.AnyAsync(x => x.A_EMAIL == email))
                return true;

            return false;
        }
    }
}
