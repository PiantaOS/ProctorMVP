using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ProctorMVP {
    public partial class MainPage : ContentPage {
        private IFile loadedFile;
        private Student loadedStudent;
        public MainPage() {
            InitializeComponent();
        }

        protected override async void OnAppearing() {
            base.OnAppearing();

            if (StudentPicker.ItemsSource == null) {
                await LoadStudentsAsync();
            }
        }
        private async void FilePrompt(object sender, EventArgs e) {

            var fileData = await Fileprompt.PickAndLoadFileAsync();

            if (fileData == null) { throw new ArgumentNullException(); }

            loadedFile = fileData;

            UploadedName.Text = "Filename: " + loadedFile.name;

        }
        private async Task LoadStudentsAsync() {
            // Replace this with your actual async call to fetch students
            var _students = await AppAuth.GetStudentsFromPeriodAsync(Session.CurrentViewingPeriod.Id);

            StudentPicker.ItemsSource = _students;
        }

        private void OnStudentSelected(object sender, EventArgs e) {
            var selectedStudent = StudentPicker.SelectedItem as Student;

            if (selectedStudent != null) {
                loadedStudent = selectedStudent;
            }
        }

        private async void CreateSubmissionFromCurrentFile(object sender, EventArgs e) {
            
            if(loadedFile == null) { throw new ArgumentNullException(nameof(loadedFile)); }
            if(loadedStudent == null) { throw new ArgumentNullException($"{nameof(loadedStudent)}"); }

            Submission newSubmissions = new Submission();
            newSubmissions.File = loadedFile;
            newSubmissions.SubmittingStudentId = loadedStudent.Id;

            Session.CreatedSubmission = newSubmissions;

            await Shell.Current.GoToAsync("//Submissions");
        }
    }

}
