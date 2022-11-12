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
using System.Windows.Shapes;

namespace wpf
{
    public partial class Login : Window
    {
        private Sqlclass sql = new();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>Close();
        

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Sign n = new();
            MainWindow m = new(n);
            Close();
            m.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sql.Check(Name_txt.Text, Password_txt.Text))
            {
                MessageBox.Show("Hello");
            }
            else MessageBox.Show("No User");
        }
    }
}
