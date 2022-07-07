using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }



        public User()
        {

        }
    }
}
