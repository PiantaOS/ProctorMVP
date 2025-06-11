using DocumentFormat.OpenXml.Wordprocessing;

namespace ProctorMVP {
    public partial class MainPage : ContentPage {
        private AssignmentBase CurrentAssignment;

        private IFile loadedFile;
        private Student loadedStudent;
        public MainPage() {
            InitializeComponent();
        }
        private async void FilePrompt(object sender, EventArgs e) {
            Console.WriteLine("Successfully Prompted");

            var fileData = await Fileprompt.PickAndLoadFileAsync();

            if(fileData == null) { throw new ArgumentNullException();  }

            loadedFile = fileData;

            UploadedName.Text = "Filename: " + loadedFile.name;

        }

        public void LoadAssignmentBase(AssignmentBase assignment) {
            CurrentAssignment = assignment;
            SubmissionName.Text = assignment.Name;
        }

        private void CreateAssignmentFromCurrentFile() {
            
            if(loadedFile == null) { throw new ArgumentNullException(nameof(loadedFile)); }
            if(loadedStudent == null) { throw new ArgumentNullException($"{nameof(loadedStudent)}"); }

            switch (loadedFile) {
                case WordFile:
                    throw new NotImplementedException();
                   // Assignment newAssignment = new WordAssignment(loadedFile.name, loadedFile);
                    break;

                case ImageFile:
                    Submission newAssignment = new ImageAssignment();
                    newAssignment.Setup(loadedFile.name, loadedFile);
                    loadedFile = default;
                    
                    //CurrentAssignment.SubmittedAssignments.Add(newAssignment);
                   // loadedStudent.AddAssignment(newAssignment);

                    loadedStudent = default;

                    break;
                case PDFFile:
                    throw new NotImplementedException();
                    //Assignment newAssignment = new Assignment(loadedFile.name, loadedFile);
                    break;
            }
        }
    }

}
