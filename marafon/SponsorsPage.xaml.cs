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
using System.Data.SqlClient;

namespace marafon
{
    /// <summary>
    /// Логика взаимодействия для SponsorsPage.xaml
    /// </summary>
    public partial class SponsorsPage : Page
    {
        public SponsorsPage()
        {
            InitializeComponent();
            spisok();
            

        }
        public void spisok()
        {

            string sqlExpression = "Select FirstName + ' ' + LastName as Name From Runner full join[User] on Runner.Email = [User].Email Where RoleId = 'R'";
            //Подрубаемся к базе
            string connectionString = "Server=bebramq.mssql.somee.com;Database=bebramq;User Id = bebramanger_SQLLogin_1;Password=qzkwsnbv5g;";

            List<string> begun = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        begun.Add(Convert.ToString(reader.GetValue(0)));
                    }
                }
                connection.Close();
            }

            chagebegun.ItemsSource = begun;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
 ;
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(txtDonate.Text) >= 10)
            {
                txtDonate.Text = (int.Parse(txtDonate.Text) - 10).ToString();
            }

        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            txtDonate.Text = (int.Parse(txtDonate.Text) + 10).ToString();
        }

        private void ListBegunov(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Zaplatit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Sponsor_confirmation());
        }

        private void Button_Click_Otmena(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
        
        //Ограничение на ввод символов
        private void card_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (sender is TextBox textBox)
            {
                
                     textBox.Text = new string
                    (
                         textBox
                         .Text
                         .Where
                         (ch =>
                             ch >= 'a' && ch <= 'z'
                            || (ch >= 'A' && ch <= 'z')
                            
                         )
                         .ToArray()
                    );
            }

        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox
                         .Text
                         .Where
                         (ch => ch >= '0' && ch <= '9'

                         )
                         .ToArray()
                    );
            }
        }

        private void srok_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox
                         .Text
                         .Where
                         (ch => ch >= '0' && ch <= '9'

                         )
                         .ToArray()
                    );
            }
        }

        private void cvv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = new string
                    (
                         textBox
                         .Text
                         .Where
                         (ch => ch >= '0' && ch <= '9'

                         )
                         .ToArray()
                    );
            }
        }

        private void lol_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {

                textBox.Text = new string
               (
                    textBox
                    .Text
                    .Where
                    (ch =>
                        ch >= 'a' && ch <= 'z'
                       || (ch >= 'A' && ch <= 'z')

                    )
                    .ToArray()
               );
            }
        }
        
    }
}
