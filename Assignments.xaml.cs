namespace ProctorMVP;

public partial class Assignments : ContentPage
{
	public Assignments()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing() {
        base.OnAppearing();

        AssignmentList.Clear();
        AssignmentBase? assignment = Session.CreatedAssignment;
        if (assignment != null) {
            await AppAuth.AddAssignmentToPeriodAsync(assignment, Session.CurrentViewingPeriod.Id); //LOST 20 MINS BECAUSE I FORGOT TO ADD AWAIT

            Session.CreatedAssignment = null;
        }
        LoadAssignments();
    }

	private async void LoadAssignments() {
		List<AssignmentBase> assignments = await AppAuth.GetAssignmentsForPeriodAsync(Session.CurrentViewingPeriod.Id);

        for(int i = 0; i < assignments.Count; i++) {
            AddAssignmentButton(assignments[i].Name, assignments[i].Description, assignments[i]);
        }
	}
    private async void AddAssignment(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("//AssignmentCreator");
    }
    private void AddAssignmentButton(string name, string description, AssignmentBase assignment) {

        var titleLabel = new Label {
            Text = name,
            FontAttributes = FontAttributes.Bold,
            FontSize = 16,
            TextColor = Colors.Black,
        };

        var descriptionLabel = new Label {
            Text = description,
            FontSize = 12,
            TextColor = Colors.Gray,
            Margin = new Thickness(0, 2, 0, 0)
        };

        var stack = new StackLayout {
            Spacing = 0,
            Children = { titleLabel, descriptionLabel }
        };

        var frame = new Frame {
            Content = stack,
            Padding = new Thickness(10),
            BackgroundColor = Color.FromArgb("#e0e0e0"),
            CornerRadius = 10,
            HasShadow = false,
            Margin = new Thickness(0, 0, 0, 10)
        };

        // TapGestureRecognizer to handle clicks
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += async (s, e) =>
        {
            Session.CurrentViewingAssignment = assignment;
            await Shell.Current.GoToAsync("//AssignmentPage");
        };
        frame.GestureRecognizers.Add(tapGesture);

        AssignmentList.Children.Add(frame);
    }

    public async void GoBack(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//PeriodPage");
	}
}