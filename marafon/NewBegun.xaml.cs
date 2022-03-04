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

namespace marafon
{
    /// <summary>
    /// Логика взаимодействия для NewBegun.xaml
    /// </summary>
    public partial class NewBegun : Page
    {
        public NewBegun()
        {
            InitializeComponent();
        }
        private void Button_Back12(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
