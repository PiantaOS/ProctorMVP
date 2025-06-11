namespace ProctorMVP;

public partial class AssignmentCreator : ContentPage
{
    public AssignmentCreator() {
        InitializeComponent();
    }

    private async void OnCreateClicked(object sender, EventArgs e) {
        string name = NameEntry.Text?.Trim();
        string description = DescriptionEditor.Text?.Trim();

        if (string.IsNullOrEmpty(name)) {
            await DisplayAlert("Error", "Please enter a name for the assignment.", "OK");
            return;
        }

        AssignmentBase newAssignment = new AssignmentBase();


        newAssignment.Name = name;
        newAssignment.Description = description;
        newAssignment.Type = Type.Text;

        Session.CreatedAssignment = newAssignment;

        await Shell.Current.GoToAsync("//Assignments");
    }
}