using Newtonsoft.Json;
using System.Windows;
using Project_Emias.Model;
using Project_Emias.Properties;
using Project_Emias.Utilities;
using Project_Emias.View.User;
using Project_Emias.View.User.Pages;

namespace Project_Emias.ViewModel.PatientViewModels
{
    public class PatientViewModel: ApiHelper
    {

        public List<SavingPatient> Patients { get; set; }
        public SavingPatient CurrentPatient { get; set; }

        public PatientViewModel()
        {
            Patients = JsonConvert.DeserializeObject<List<SavingPatient>>(Settings.Default.Patients);
            CurrentPatient = Patients.First(x => x.Oms == Settings.Default.Patient);
        }

        public void SelectionPatient()
        {
            Settings.Default.Patient = CurrentPatient.Oms;
            Settings.Default.Save();
            var window = Application.Current.Windows.OfType<PatientWindow>().First()!;
            window.Frame.Content = new ProfilePage();
        }

    }
}
