namespace ProctorMVP;

public partial class Periods : ContentPage
{
	public Periods()
	{
		InitializeComponent();
		LoadExistingPeriods();
	}
	private void LoadExistingPeriods() {
		Teacher teacher = Session.CurrentTeacher;

		if(teacher.Periods.Count > 0 ) {
			for(int i = 0; i < teacher.Periods.Count; i++) {
				AddPeriodButton("Period " + teacher.Periods[i].PeriodNumber.ToString(), teacher.Periods[i]); //ADD STRINGBUILDER
			}
		}
	}

	public async void AddPeriod(object sender, EventArgs e) {
		Teacher teacher = Session.CurrentTeacher;
		Period newPeriod;

		if (teacher.Periods.Count == 0) { newPeriod = new Period(1); }
		else { newPeriod = new Period(teacher.Periods[teacher.Periods.Count - 1].PeriodNumber + 1); }//May be wrong math
			teacher.Periods.Add(newPeriod); 
		await AppAuth.AddPeriodToTeacherAsync(newPeriod, teacher);

		AddPeriodButton("Period " + newPeriod.PeriodNumber.ToString(), newPeriod);
    }
	private void AddPeriodButton(string text, Period period) {
		var newButton = new Button {
			Text = text,
			FontAttributes = FontAttributes.Bold,
			HeightRequest = 50,
			CornerRadius = 10,
			BackgroundColor = Color.FromArgb("#e0e0e0"),
			Margin = new Thickness(0, 0, 0, 10),
			BindingContext = period
        };

        newButton.Clicked += async (s, args) =>
        {
            var btn = (Button)s;
            var selectedPeriod = (Period)btn.BindingContext;
			Session.CurrentViewingPeriod = selectedPeriod;

			await Shell.Current.GoToAsync("//PeriodPage");
        };

        PeriodList.Children.Add(newButton);
    }
	public async void GoBack(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("//LoginPage");
	}
}