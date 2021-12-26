using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;
using DiverseTraining.Entities;

namespace DiverseTraining.Interface
{
    public interface IAccountService
    {
        Task<UserRegister> SignUp(UserRegisterDto userRegisterDto);
        Task<bool> UserExists(string email);

        // Task<UserLoginDto> SignIn(UserLoginDto userLoginDto);
    }
}