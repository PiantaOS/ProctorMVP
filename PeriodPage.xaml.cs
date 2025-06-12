

namespace ProctorMVP;

public partial class PeriodPage : ContentPage
{
	private Period CurrentPeriod;
	public PeriodPage()
	{
		InitializeComponent();

	}

	protected override async void OnAppearing() {
		base.OnAppearing();
        CurrentPeriod = Session.CurrentViewingPeriod;
        DashboardName.Text = "Period " + CurrentPeriod.PeriodNumber + " Dashboard";
    }

	public async void GoToAssignments(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//Assignments");
	}

    public async void GoBack(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//Periods");
    }

	public async void GoToStudents(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//Students");
	}


}