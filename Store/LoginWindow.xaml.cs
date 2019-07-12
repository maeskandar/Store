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

namespace Store
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Repo<User> userRepo;
        public LoginWindow()
        {
            InitializeComponent();
            userRepo = new Repo<User>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var users = userRepo.GetItems();
            var match = users.FirstOrDefault(user => user.Match(ID.Text, Pass.Password));
            if (match == null)
            {
                MessageBox.Show("نام کاربری یا رمز عبور غلط می باشد.", "خطا", MessageBoxButton.OK);
            }
            else
            {
                MasterWindow window = new MasterWindow();
                window.Show();
                this.Close();
            }
        }
    }
}
