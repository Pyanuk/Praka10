using BingingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project_Emias.Model;
using Project_Emias.Properties;
using Project_Emias.Utilities;
using System.Collections.ObjectModel; 
using System.ComponentModel;
using System.Windows.Documents;
using Project_Emias.View.User.Pages;
using System.IO;
using Project_Emias.View.User.UserEl;
using Project_Emias.View.User;

namespace Project_Emias.ViewModel.PatientViewModels
{
    public class MedicalAppointmentViewModel : ApiHelper
    {
        #region Region

        private string _nameAppointment;

        public string NameAppointment
        {
            get => _nameAppointment;
            set => SetField(ref _nameAppointment, value);
        }

        private string _address;

        public string Address
        {
            get => _address;
            set => SetField(ref _address, value);
        }

        private string _nameDoctor;

        public string NameDoctor
        {
            get => _nameDoctor;
            set => SetField(ref _nameDoctor, value);
        }

        private string _day;

        public string Day
        {
            get => _day;
            set => SetField(ref _day, value);
        }

        public FlowDocument RTB { get; set; }

        private ObservableCollection<MedicalAppointmentElement> _elements = new();

        public ObservableCollection<MedicalAppointmentElement> Elements
        {
            get => _elements;
            set => SetField(ref _elements, value);
        }

        private long _oms;

        private int _id;

        #endregion
    

        public MedicalAppointmentViewModel()
        {
            var window = Application.Current.Windows.OfType<PatientWindow>().FirstOrDefault();
            _oms = Settings.Default.Patient;
            RTB = new();
            LoadCustomElements();
            LoadCards();
        }

        private void LoadCustomElements()
        {
            var customElementsFromApi = Get<List<MedicalAppointmentElement>>("CustomElements");
            if (customElementsFromApi != null)
            {
                foreach (var customElement in customElementsFromApi)
                {
                    Elements.Add(customElement);
                }
            }
        }


        private void LoadCards()
        {
            var appointments = Get<List<Appointment>>("Appointments")!.Where(item => item.Oms == _oms).OrderBy(item => item.AppointmentDate).ToList();
            foreach (var appointment in appointments)
            {
                var researchDocument = ApiHelper.Get<ResearchDocument>("AppointmentDocuments", (int)appointment.IdAppointment!);
                if (researchDocument != null)
                {
                    var doctor = ApiHelper.Get<DoctorModel>("Doctors", (int)appointment.DoctorId!);


                    var card = new MedicalAppointmentElement(researchDocument.DocumentName,
                        $"{doctor!.Surname} {doctor.FirstName.Substring(0, 1)}. {doctor.Patronymic.Substring(0, 1)}.",
                        appointment.AppointmentDate.ToString("dd MMMM yyyy"), doctor.WorkAddress, (int)doctor.IdDoctor,
                        (int)appointment.IdAppointment);

                    card.Click += (sender, args) => LoadInfo(sender, args);
                    Elements.Add(card);
                }
            }
        }

        private void LoadInfo(object sender, EventArgs args)
        {
            var card = sender as MedicalAppointmentElement;
            _id = card.IdAppointment;
            NameAppointment = card.NameAppointment;
            NameDoctor = card.NameDoctor;
            Address = card.Address;
            Day = card.Day;
            var document = Get<ResearchDocument>("AppointmentDocuments", card.IdAppointment);
            File.WriteAllText("buffer.rtf", document.Rtf);
            var range = new TextRange(RTB.ContentStart, RTB.ContentEnd);
            var fs = new FileStream("buffer.rtf", FileMode.Open);
            range.Load(fs, DataFormats.Rtf);
            fs.Close();
            File.Delete("buffer.rtf");
        }
    }
}