using MauiBugMissingMethodException.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugMissingMethodException.Services
{
    public static class CityService
    {
        public static string [] CityNames = new string[] { "Lima", "Bogota", "Cartajena de Indias", "Sevilla", "Mexico City" };
        public static string[] FriendNames = new string[] { "Juan", "Alberto", "Casimiro", "Silvia", "Julia" };

        public static List<City> GetCities()
        {
            var returnList = new List<City>();
            foreach (var cityName in CityNames)
            {
                var city = new City { CityName = cityName };
                Random random = new Random();
                city.FriendsThere[0] = FriendNames[random.Next(0, FriendNames.Length)];
                city.FriendsThere[1] = FriendNames[random.Next(0, FriendNames.Length)];

                returnList.Add(city);
            }

            return returnList;
        }
    }
}
