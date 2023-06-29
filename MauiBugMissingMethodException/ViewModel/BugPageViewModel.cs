using CommunityToolkit.Mvvm.ComponentModel;
using MauiBugMissingMethodException.Model;
using MauiBugMissingMethodException.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBugMissingMethodException.ViewModel
{
    public partial class BugPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<City> cities= CityService.GetCities();

        [ObservableProperty]
        public City city = CityService.GetCities()[0];
    }
}
