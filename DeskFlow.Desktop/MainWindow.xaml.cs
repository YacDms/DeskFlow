using System.Windows;
using System.Windows.Controls;

namespace DeskFlow.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Page par défaut
            MainFrame.Navigate(new Views.Pages.DashboardPage());
        }

        private void Nav_Dashboard(object sender, RoutedEventArgs e)
            => MainFrame.Navigate(new Views.Pages.DashboardPage());

        private void Nav_Projects(object sender, RoutedEventArgs e)
            => MainFrame.Navigate(new Views.Pages.ProjectsPage());

        private void Nav_Tasks(object sender, RoutedEventArgs e)
            => MainFrame.Navigate(new Views.Pages.TasksPage());

        private void Nav_Notes(object sender, RoutedEventArgs e)
            => MainFrame.Navigate(new Views.Pages.NotesPage());
    }
}
