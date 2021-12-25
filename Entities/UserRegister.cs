using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiverseTraining.Entities
{
    public class UserRegister
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}