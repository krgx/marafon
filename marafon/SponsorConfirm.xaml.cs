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

namespace marafon
{
   
    public partial class Sponsor_confirmation : Page
    {
        public Sponsor_confirmation()
        {
            InitializeComponent();
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.Title = "Marathon skills 2016 - Sponsorship confirmation";
        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
