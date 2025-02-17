﻿using Newtonsoft.Json.Linq;
using System.Windows.Controls;

namespace Project_Emias.View.User.UserEl
{
    /// <summary>
    /// Логика взаимодействия для DoctorElement.xaml
    /// </summary>
    public partial class DoctorElement : UserControl
    {
        public string ImagePath { get; set; }
        public string Doctor { get; set; }

        public DoctorElement(int Image, string Doctor)
        {
            InitializeComponent();
            DataContext = this;
            this.ImagePath = $"../../../Images/{Image}.png";
            this.Doctor = Doctor;
        }
    }
}
