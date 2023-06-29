using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugMissingMethodException.Model
{
    public class City
    {
        public string CityName { get; set; }
        public string [] FriendsThere { get; set; }

        public City()
        {
            FriendsThere = new string[2];
        }
    }
}
