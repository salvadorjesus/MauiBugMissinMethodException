using MauiBugMissingMethodException.ViewModel;

namespace MauiBugMissingMethodException.View;

public partial class BugPage : ContentPage
{
	public BugPage(BugPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}