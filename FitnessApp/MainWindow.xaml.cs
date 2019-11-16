﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FitnessApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartDispatchTimer();
            
            
        }

        /// <summary>
        /// Startet Dispatch Timer für Uhrzeit und Datum
        /// </summary>
        private void StartDispatchTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Aktuallisiert Zeit und Datum
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            CurrentTime.Text = DateTime.Now.ToLongTimeString();
            CurrentDate.Text = DateTime.Now.ToString("dddd , dd.MMM.yyyy");
        }

        /// <summary>
        /// Versteckt Zeit/Datum beim eingeklappten Menü - Zeigt beim ausgeklappten
        /// </summary>
        private void ManageDate()
        {
            if (CurrentDate.Visibility == Visibility.Hidden)
            {
                CurrentDate.Visibility = Visibility.Visible;
                CurrentTime.Visibility = Visibility.Visible;
            }
            else
            {
                CurrentTime.Visibility = Visibility.Hidden;
                CurrentDate.Visibility = Visibility.Hidden;
            }
        }

        #region Navigation
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ManageDate();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ManageDate();
        }

        /// <summary>
        /// Wechselt Fenster je nach ausgewähltem ListViewItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new KalorienTracker());
                    break;
                case 1:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Trainingsplan());
                    break;
                case 2:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Ernährungsplan());
                    break;
                case 3:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Fortschritt());
                    break;
                case 4:
                    GridMain.Children.Clear();
                    GridMain.Children.Add(new Lebensmittel());
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}