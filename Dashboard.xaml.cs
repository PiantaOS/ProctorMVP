namespace ProctorMVP;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

	public void GoToPeriods(object sender, EventArgs e) {
		Shell.Current.GoToAsync("//Periods");
	}
}