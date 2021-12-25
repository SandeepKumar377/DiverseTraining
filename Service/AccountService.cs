using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DiverseTraining.Data;
using DiverseTraining.DTOs;
using DiverseTraining.Entities;
using DiverseTraining.Interface;
using Microsoft.EntityFrameworkCore;

namespace DiverseTraining.Service
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        public AccountService(DataContext context)
        {
            _context = context;
        }

        //User Registration method
        public async Task<UserRegisterDto> SignUp(UserRegisterDto userRegisterDto)
        {
            using var hmac = new HMACSHA512();           // convert password into Hash (algorithm) 
            var user = new UserRegister()
            {
                Name = userRegisterDto.Name,
                Email = userRegisterDto.Email.ToLower(),
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)), //password convert into Hash
                PasswordSalt=hmac.Key, // Private Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return userRegisterDto;
        }

        //check user is already exist or not method
        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower());                         
        }
    }
}