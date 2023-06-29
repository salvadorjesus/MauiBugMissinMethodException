using MauiBugMissingMethodException.View;

namespace MauiBugMissingMethodException;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Route registration
        Routing.RegisterRoute(nameof(BugPage), typeof(BugPage));
    }
}
