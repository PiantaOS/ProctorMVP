using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2019.Excel.ThreadedComments;

namespace ProctorMVP;

public partial class Submissions : ContentPage
{
	public Submissions()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        base.OnAppearing();

        SubmissionList.Clear();
        Submission? submission = Session.CreatedSubmission;
        if (submission != null) {
            await AppAuth.AddSubmissionToAssignmentAsync(submission, Session.CurrentViewingAssignment.Id); //LOST 20 MINS BECAUSE I FORGOT TO ADD AWAIT

            Session.CreatedSubmission = null;
        }
        LoadSubmissions();
    }

    private async void LoadSubmissions() {
        List<Submission> submissions = await AppAuth.GetSubmissionsFromAssignmentAsync(Session.CurrentViewingAssignment.Id);

        for (int i = 0; i < submissions.Count; i++) {
            AddSubmissionButton(submissions[i].SubmittingStudentId, submissions[i]);
        }
    }
    private async void AddSubmission(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//MainPage");
    }
    private async void AddSubmissionButton(int studentId, Submission submission) {
        Student student = await AppAuth.GetSpecificStudentAsync(Session.CurrentViewingPeriod.Id, studentId);

        var newButton = new Button {
            Text = student.Name + "'s Submission",
            FontAttributes = FontAttributes.Bold,
            HeightRequest = 50,
            CornerRadius = 10,
            BackgroundColor = Color.FromArgb("#e0e0e0"),
            Margin = new Microsoft.Maui.Thickness(0, 0, 0, 10),
            BindingContext = submission
        };

        newButton.Clicked += async (s, args) => {
            var btn = (Button)s;
            var selectedSubmission = (Submission)btn.BindingContext;
            Session.CurrentViewingSubmission = selectedSubmission;

            await Shell.Current.GoToAsync("//SubmissionPage");
        };

        SubmissionList.Children.Add(newButton);
    }

    public async void GoBack(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//AssignmentPage");
    }
}