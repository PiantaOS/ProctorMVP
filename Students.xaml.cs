using DocumentFormat.OpenXml.Drawing.Charts;

namespace ProctorMVP;

public partial class Students : ContentPage
{
	public Students()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        base.OnAppearing();

        StudentList.Clear();
        Student? student = Session.CreatedStudent;
        if (student != null) {
            await AppAuth.AddStudentToPeriodAsync(student, Session.CurrentViewingPeriod.Id); //LOST 20 MINS BECAUSE I FORGOT TO ADD AWAIT

            Session.CreatedStudent = null;
        }
        LoadStudents();
    }

    private async void LoadStudents() {
        List<Student> students = await AppAuth.GetStudentsFromPeriodAsync(Session.CurrentViewingPeriod.Id);

        for (int i = 0; i < students.Count; i++) {
            AddStudentButton(students[i].Name, students[i]);
        }
    }
    private async void AddStudent(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//StudentCreator");
    }
    private void AddStudentButton(string name, Student student) {

        var newButton = new Button {
            Text = name,
            FontAttributes = FontAttributes.Bold,
            HeightRequest = 50,
            CornerRadius = 10,
            BackgroundColor = Color.FromArgb("#e0e0e0"),
            Margin = new Microsoft.Maui.Thickness(0, 0, 0, 10),
            BindingContext = student
        };

        newButton.Clicked += async (s, args) => {
            var btn = (Button)s;
            var selectedStudent = (Student)btn.BindingContext;
            Session.CurrentViewingStudent = selectedStudent;

            await Shell.Current.GoToAsync("//StudentPage");
        };
        StudentList.Children.Add(newButton);
    }

    public async void GoBack(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//PeriodPage");
    }
}