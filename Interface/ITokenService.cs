using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;

namespace DiverseTraining.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string email);
    }
}