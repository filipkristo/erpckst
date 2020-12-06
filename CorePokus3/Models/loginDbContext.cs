using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePokus3.Models;

namespace CorePokus3.Models
{
    public class loginDbContext :  DbContext
    {
        public loginDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CorePokus3.Models.RegisterViewModel> RegisterViewModel { get; set; }
    }

   

}
