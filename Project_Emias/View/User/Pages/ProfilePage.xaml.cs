using System.Windows;
using System.Windows.Controls;
using Project_Emias.View.Authorization;
using Project_Emias.ViewModel.PatientViewModels;

namespace Project_Emias.View.User.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = new ProfilePageVIewModel();
        }
    }
}
