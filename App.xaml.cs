namespace ProctorMVP {
    public partial class App : Application {
        public App() {
            InitializeComponent();

           // Task.Run(async () => await AppAuth.InitAsync()).Wait();
            MainPage = new AppShell();
        }
    }
}
