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
using System.Data.SqlClient;

namespace marafon
{

    public partial class Registr : Page
    {

        readonly DispatcherTimer timer = new DispatcherTimer();
        public Registr()
        {
            InitializeComponent();
            //Заголовок
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.Title = "Marathon skills 2016 - Login";
            //Таймер
            TimerStarter();
        }

        //Навигация        
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        //Навигация
        private void Button_Back(object sender, RoutedEventArgs e)
        {
            {
                NavigationService.Navigate(new Page2());
            }
        }

        private void Button_Click_Begun(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuBeguna());
        }

        //Обработка нажатия кнопки для входа
        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            Login();
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
            TimeSpan timeSpan = new TimeSpan(8, 18, 50, 0);
            TimeSpan countDate = timeSpan.Subtract(today);

            Day.Text = countDate.Days.ToString();
            Hours.Text = countDate.Hours.ToString();
            Minute.Text = countDate.Minutes.ToString();
        }

        //Server=bebramq.mssql.somee.com; Database=bebramq; User Id = bebramanger_SQLLogin_1; Password=qzkwsnbv5g;

        //string connectionString = "Server=bebramq.mssql.somee.com;Database=bebramq;User Id = bebramanger_SQLLogin_1;Password=qzkwsnbv5g;"


        //string sqlExpression = "SELECT * FROM[User] WHERE Email = @email AND Password = @Password AND RoleId = @role     " ;







        //Авторизаия к базе)
        public void Login()
        {

            string connectionString = "Server=bebramq.mssql.somee.com;Database=bebramq;User Id = bebramanger_SQLLogin_1;Password=qzkwsnbv5g;";

            List<string> list = new List<string>();
            string sqlExpression = "SELECT * FROM[User] WHERE Email = @email AND Password = @Password ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //Логин
                SqlParameter loginParam = new SqlParameter("@email", login.Text);
                command.Parameters.Add(loginParam);

                //Пароль
                SqlParameter passParam = new SqlParameter("@Password", pass.Text);
                command.Parameters.Add(passParam);

                SqlDataReader reader = command.ExecuteReader();
                
                
                if (reader.HasRows)
                   
                {
                  while (reader.Read())
                  {
                   list.Add( Convert.ToString(reader["RoleId"]));
                       
                  }
                    
                }

                if (list.Count == 0) // если 
                {
                    login.Clear();
                    pass.Clear();
                    MessageBox.Show("Логин или пароль неверен");
                }

                else if (list[0] == "A") // если есть данные
                {
                    NavigationService.Navigate(new AdminPage());
                }
                else if (list[0] == "С") // если есть данные
                {
                    NavigationService.Navigate(new CoordPage());
                }
                else if (list[0] == "R") // если есть данные
                {
                    NavigationService.Navigate(new RunnerPage());
                }
            }
        }
    }
}

    
