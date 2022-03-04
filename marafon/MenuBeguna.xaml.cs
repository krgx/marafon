using System;
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
   
    public partial class MenuBeguna : Page
    {
        readonly DispatcherTimer timer = new DispatcherTimer();
        public MenuBeguna()
        {
            InitializeComponent();
            //Заголовок
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.Title = "Marathon skills 2016 - Registr as a runner";
            //Таймер
            TimerStarter();
        }

        
        //Навигация
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click_Begun(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registr());
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registr());
        }

        
        //Таймер
        public void TimerStarter()
        {
            timer.Interval += new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan today = new TimeSpan(dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            TimeSpan timeSpan = new TimeSpan(5, 18, 50, 0);
            TimeSpan countDate = timeSpan.Subtract(today);

            Day.Text = countDate.Days.ToString();
            Hours.Text = countDate.Hours.ToString();
            Minute.Text = countDate.Minutes.ToString();
        }
    }
}
