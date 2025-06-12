namespace ProctorMVP;

public partial class StudentCreator : ContentPage
{
	public StudentCreator()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        NameEntry.Text = "";
    }
    private async void OnCreateClicked(object sender, EventArgs e) {
        string name = NameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(name)) {
            await DisplayAlert("Error", "Please enter a name for the student.", "OK");
            return;
        }

        Student student = new Student();


        student.Name = name;

        Session.CreatedStudent = student;

        await Shell.Current.GoToAsync("//Students");
    }
}