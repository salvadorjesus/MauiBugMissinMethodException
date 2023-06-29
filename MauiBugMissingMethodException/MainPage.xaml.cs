namespace MauiBugMissingMethodException;
using MauiBugMissingMethodException.View;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("BugPage");
        //Shell.Current.Navigation.PushAsync(new BugPage(new ViewModel.BugPageViewModel()));
    }
}

