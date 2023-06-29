# MauiBugMissinMethodException
A public repo to demonstrate a possible bug in .Net Maui when binding to an array.

The main purpose of this repo is to demonstrate **some code that works in debug configuration but fails in release configuration**. I assume that this is not an intended behavior. Some of the design choices made for this app might be questionable, but this is out of the scope of the purpose of this repo.

## App overview
The repo features a mockup app that follows a structure that is common in normal apps. I'm using the CommunityToolkit.Mvvm.

There is a Service class that load a series of objects of a class defined in the model and serve them to the the viewModel.

**Model** (excerpt) [City.cs](https://github.com/salvadorjesus/MauiBugMissingMethodException/blob/master/MauiBugMissingMethodException/Model/City.cs):

``` c#
    public class City
    {
        public string CityName { get; set; }
        public string [] FriendsThere { get; set; }

        public City()
        {
            FriendsThere = new string[2];
        }
    }
```

**ViewModel** (excerpt) [BugPageViewModel.cs](https://github.com/salvadorjesus/MauiBugMissingMethodException/blob/master/MauiBugMissingMethodException/ViewModel/BugPageViewModel.cs):

``` c#
    public partial class BugPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public List<City> cities= CityService.GetCities();

        [ObservableProperty]
        public City city = CityService.GetCities()[0];
    }
```

The view binds to properties exposed by the viewModel (that are references to model objects). In this case we have a List and a property.

**View** (excerpt) [BugPage.xaml](https://github.com/salvadorjesus/MauiBugMissingMethodException/blob/master/MauiBugMissingMethodException/View/BugPage.xaml):

``` XAML
<!--Accesing the list-->
        <CarouselView ItemsSource="{Binding Cities}">
        <!-- [...] -->
        <VerticalStackLayout>
            <Label Text="{Binding CityName}"/>
            <Label Text="{Binding FriendsThere[0], StringFormat='My friend {0} lives there'}"/>
        </VerticalStackLayout>
<!--Accessing the property-->
<!-- [...] -->
        <Label Text="{Binding City.CityName}"/>
        <Label Text="{Binding City.FriendsThere[0], StringFormat='My friend {0} lives there'}"/>
```

# Behavior on Android
## On Debug Mode
Everything works:

https://github.com/salvadorjesus/MauiBugMissinMethodException/assets/637125/1aa3337b-041b-4d7d-a9c3-a2bd914ed242


## On Release Mode
### Binding only to the list.
The code in the carrousel will raise a No Such Method Exception. Keep lines binding to the propery "City" commented:

https://github.com/salvadorjesus/MauiBugMissinMethodException/assets/637125/f4783562-2d6f-4f96-9f89-78a3a4ca73fe

![image](https://github.com/salvadorjesus/MauiBugMissinMethodException/assets/637125/6e880ff1-2e4e-4234-b425-9bbc05e68b75)

### Binding to the property City
Uncomment the XAML code binding to the "City" property of the viewModel will cause a different behavior. The page won’t load. The application will not crash nor raise any exception.
``` XAML
        <!--Uncomment this code to get a different behavior. The page won’t load. It will not raise any exception.-->
        <Label FontSize="Subtitle"
            Text="This will work on debug. The page just won't load on release."/>
        <Label Text="{Binding City.CityName}"/>
        <Label Text="{Binding City.FriendsThere[0], StringFormat='My friend {0} lives there'}"/>
```
https://github.com/salvadorjesus/MauiBugMissinMethodException/assets/637125/b89689e9-728b-44f5-ba23-0d17335d221c

# Behavior on Windows
The behavior on Windows is somewhat similar.
On debug, it will work properly.
On Release, binding only to the list the application will not crash, but the data won’t show on labels.
Binding to the property, the bug page will not load.


