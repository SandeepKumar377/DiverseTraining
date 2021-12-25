using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;

namespace DiverseTraining.Interface
{
    public interface IAccountService
    {
        Task<UserRegisterDto> SignUp(UserRegisterDto userRegisterDto);
        Task<bool> UserExists(string email);
    }
}