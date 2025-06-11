namespace ProctorMVP;

public partial class LoginPage : ContentPage {
	public LoginPage() {
		InitializeComponent();
	}
	protected override async void OnAppearing() {
		base.OnAppearing();
		await AppAuth.InitAsync();
		ErrorText("INIT");
	}
    public async void TryLogin(object sender, EventArgs e) {
		string email = Email.Text;
		string pass = Password.Text;

		if (email == "" || pass == "") {
			ErrorText("Missing field");
			return;
		}


		Teacher? teacher = await AuthenticationDB.LoginAsync(email, pass);

		if(teacher == null) {
			ErrorText("Account not found");
			return;
		}
		ErrorText("Logged in");
		Session.CurrentTeacher = teacher;

		//MOVE TO NEXT PAGE WITH THE REFERENCE OF TEACHER
		//if(email == validemail)  ADD EMAIL VALIDATION LATER
	}

	public async void TryCreateAccount(object sender, EventArgs e) {
        string email = Email.Text;
        string pass = Password.Text;

        if (email == "" || pass == "") {
            ErrorText("Missing field");
            return;
        }

        bool registrationSuccess = await AuthenticationDB.RegisterAsync(email, pass);
        if (!registrationSuccess) {
            ErrorText("Registration fail");
            return;
        }
		ErrorText("Registered Successfully");
		TryLogin(sender, e);
    }
	private void ErrorText(string errorText) {
		Errors.Text = errorText;
	}
}