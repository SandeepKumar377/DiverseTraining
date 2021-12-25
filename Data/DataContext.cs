using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiverseTraining.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}
        public DbSet<UserRegister> Users { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}