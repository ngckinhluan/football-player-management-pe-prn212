using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;
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

namespace GermanyEuro2024_TranNgocKinhLuan
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UefaacountService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

       

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Uefaaccount uefaaccount = _service.GetOne(EmailTextBox.Text, PasswordTextBox.Text);
            if (uefaaccount == null)
            {
                MessageBox.Show("You have no permission to acess this function!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MainWindow main = new MainWindow(uefaaccount);
            main.Show();
            this.Close();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
