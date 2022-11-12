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
    /// <summary>
    /// Interaction logic for Sign.xaml
    /// </summary>
    public partial class Sign : Window
    {
        private Sqlclass sql = new();
        public Sign()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
       
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Login n = new();
            MainWindow m = new(n);
            Close();
            m.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Password_textbox.Text.Length <= 6 && Name_textBox.Text.Length >= 3)
            {
                string name = Password_textbox.Text;
                string password = Name_textBox.Text;
                if (!sql.Check(name, password)) sql.AddUser(name, password);
                else MessageBox.Show("Bu user var");
            }
            else MessageBox.Show("Password > 5 and Name>3");
        }
    }
}
