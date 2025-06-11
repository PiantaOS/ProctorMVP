namespace ProctorMVP;

public partial class PeriodPage : ContentPage
{
	private Period CurrentPeriod;
	public PeriodPage()
	{
		InitializeComponent();

		
	}

	protected override async void OnAppearing() {
        CurrentPeriod = Session.CurrentViewingPeriod;
        DashboardName.Text = "Period " + CurrentPeriod.PeriodNumber + " Dashboard";
    }

    public async void GoBack(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//Periods");
    }


}