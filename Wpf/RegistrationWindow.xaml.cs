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
using Wpf.Database;
using Wpf.Object;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void registrationEndButton_Click(object sender, RoutedEventArgs e)
        {
            string login = text.Text;
            string password = new System.Net.NetworkCredential(string.Empty, passwordBox.SecurePassword).Password;
            string passwordCopy = new System.Net.NetworkCredential(string.Empty, password_copy.SecurePassword).Password;

            if (password != passwordCopy)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            // Создание нового пользователя с ролью "Manager"

            DateTime dateTimeUtc = DateTime.UtcNow;

            DatabaseControl.AddUser(new User
            {
                Login = login,
                Password = password,
                Role = "Manager",
                Date_reg = dateTimeUtc
            });
            // Дополнительные действия по сохранению нового пользователя в базе данных

            // Закрытие текущего окна регистрации
            this.Close();
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие текущего окна регистрации
            this.Close();
        }
        private List<ComponentWarehouse> components;

        
    }
}
