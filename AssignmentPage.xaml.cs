namespace ProctorMVP;

public partial class AssignmentPage : ContentPage
{
	public AssignmentPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        base.OnAppearing();
		Title.Text = Session.CurrentViewingAssignment.Name + " Dashboard"; //STRINGBUILDER
    }
	public async void GoToSubmissions(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//Submissions");
	}
    public async void GoBack(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//Assignments");
	}
}