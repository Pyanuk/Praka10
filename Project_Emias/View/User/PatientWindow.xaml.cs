﻿using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Project_Emias.Model;
using Project_Emias.View.User.Pages;
using Project_Emias.ViewModel.PatientViewModels;

namespace Project_Emias.View.User
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>v
    public partial class PatientWindow : Window
    {

        public PatientWindow()
        {
            InitializeComponent();
            DataContext = new PatientViewModel();
            Frame.Content = new MainPage();
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UnwrapButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void TreeHandler(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tree = sender as TreeView;
            TreeViewItem item = tree.SelectedItem as TreeViewItem;
            switch(item.Header)
            {
                case "Приёмы":
                    Frame.Content = new MedicalAppointmentsCardPage();
                    break;
                case "Анализы":
                    Frame.Content = new MedCardAnalysesPage();
                    break;
                case "Исследования":

                    break;
                case "Записи и направления":
                    Frame.Content = new MainPage();
                    break;
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ProfilePage();
        }
    }
}
