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
using Wpf.Database;
using Wpf.Object;
using Npgsql;
using Wpf;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> users;
        public LisShopWindow lisShopWindow;
        public MainWindow()
        {
            InitializeComponent();
            users = DatabaseControl.GetUsersForView();
        }
        private void button_Enter_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            foreach (User user in users)
            {
                if (user.Login == textBox_login.Text && user.Password == textBox_password.Password)
                {
                    flag = true;
                    lisShopWindow = new LisShopWindow(user);
                    lisShopWindow.dbUser = user;
                    lisShopWindow.Show();
                    //lisShopWindow.dbUserRole = user.Role;
                    break;
                }
            }
            if (!flag)
            {
                textBlock_Error.Visibility = Visibility.Visible;
            }
            else
            {
                this.Close();
            }
        }

        
    }
}
