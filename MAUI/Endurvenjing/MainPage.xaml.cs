
using Endurvenjing.ViewModel;

namespace Endurvenjing;

public partial class MainPage : ContentPage
{
	

	public MainPage(ChallengeViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{

	}

    void Option1_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void Option2_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void Option3_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void Option4_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}


