using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePokus3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
    }
}
