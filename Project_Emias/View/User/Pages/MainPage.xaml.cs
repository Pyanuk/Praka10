using System.Windows.Controls;
using Project_Emias.ViewModel.PatientViewModels;

namespace Project_Emias.View.User.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }
    }
}
