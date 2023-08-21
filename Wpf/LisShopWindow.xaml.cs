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

using Wpf.Object;
using Wpf;
using Wpf.Database;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для LisShopWindow.xaml
    /// </summary>
    public partial class LisShopWindow : Window
    {
        public User dbUser;

        public LisShopWindow(User _dbUser)
        {
            InitializeComponent();

            using (DatabaseContext dbContext = new DatabaseContext())
            {
                List<ComponentWarehouse> components = dbContext.ComponentWarehouse.Include(c => c.Category).ToList();
                StorageDataGrid.ItemsSource = components;
            }

            UserDataGrid.ItemsSource = DatabaseControl.GetUserNotAdminForView();

            textBox_Username.Text = _dbUser.Login;
            textBox_DateReg.SetBinding(TextBlock.TextProperty, new Binding("Date_reg") { Source = _dbUser, StringFormat = "yyyy-MM-dd" });

            if (_dbUser.Role == "Manager")
            {
                button_Registration.Visibility = Visibility.Collapsed; // Скрытие кнопки "Регистрация"
                                                                       // Запретить доступ к TabItem
                button_User.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Разрешить доступ к TabItem
                button_User.Visibility = Visibility.Visible;
            }

            OrdersDataGrid.ItemsSource = DatabaseControl.GetOrdersForView();

        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        public void RefreshTable()
        {
            OrdersDataGrid.ItemsSource = null;
            OrdersDataGrid.ItemsSource = DatabaseControl.GetOrdersForView();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                List<ComponentWarehouse> components = dbContext.ComponentWarehouse.Include(c => c.Category).ToList();
                StorageDataGrid.ItemsSource = components;

                List<User> users = dbContext.User.Skip(1).ToList();
                UserDataGrid.ItemsSource = users;

            }
        }

        private void del_button_Click(object sender, RoutedEventArgs e)
        {
            Order p = OrdersDataGrid.SelectedItem as Order;

            if (p != null)
            {
                DatabaseControl.DelOrder(p);
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void del_button_Click_storage(object sender, RoutedEventArgs e)
        {
            if (dbUser.Role == "Administrator")
            {
                ComponentWarehouse selectedComponent = StorageDataGrid.SelectedItem as ComponentWarehouse;

                if (selectedComponent != null)
                {
                    DatabaseControl.DelWarehouse(selectedComponent);
                    RefreshTable();
                }
                else
                {
                    MessageBox.Show("Выберите компонент для удаления.");
                }
            }
            else
            {
                MessageBox.Show("Удаление из склада полностью может делать только администратор");
            }
        }


        private void view_button_Click(object sender, RoutedEventArgs e)
        {
            Order selectedOrder = OrdersDataGrid.SelectedItem as Order;

            if (selectedOrder != null)
            {
                List<Order> selectedOrders = new List<Order> { selectedOrder };
                Component componentWindow = new Component(dbUser, selectedOrders, selectedOrder);
                componentWindow.Closed += AddComponentWindow_Closed; // Добавляем обработчик события Closed
                componentWindow.ShowDialog();

            }
            else
            {
                // Если не выбран заказ, показать сообщение об ошибке или предупреждение
                MessageBox.Show("Выберите заказ для просмотра комплектующих.");
            }
        }

        private void button_Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }

        private void AddButton_clickOrder_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseContext()) // замените YourDbContext на ваш контекст базы данных
            {
                List<Order> orderList = dbContext.Order.ToList();
                Order orderWithMaxId = orderList.OrderByDescending(o => o.Id).FirstOrDefault();
                DateTime dateTimeUtc = DateTime.UtcNow;

                DatabaseControl.AddOrder(new Order
                {
                    Id = orderWithMaxId.Id + 1,
                    Comment = "Заказ сотрудника",
                    User_id = 1,
                    Date_reg = dateTimeUtc
                });

                RefreshTable();
            }


            
        }

        private void AddComponentWindow_Closed(object sender, EventArgs e)
        {
            RefreshTable(); // Обновляем данные в таблице склада
        }

        private void AddButton_Warehouse_Click(object sender, RoutedEventArgs e)
        {
            AddComponentWarehouse addComponentWindow = new AddComponentWarehouse();
            addComponentWindow.Closed += AddComponentWindow_Closed; // Добавляем обработчик события Closed
            addComponentWindow.ShowDialog();
        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного элемента из списка
            ComponentWarehouse selectedComponent = (ComponentWarehouse)StorageDataGrid.SelectedItem;

            // Создание экземпляра окна EditComponentWarehouse и передача выбранного элемента в конструктор
            EditComponentWarehouse editWindow = new EditComponentWarehouse(selectedComponent);
            editWindow.Closed += AddComponentWindow_Closed; // Добавляем обработчик события Closed
            // Открытие окна EditComponentWarehouse
            editWindow.ShowDialog();
        }

        private void del_button_user_Click(object sender, RoutedEventArgs e)
        {
            User p = UserDataGrid.SelectedItem as User;

            if (p != null)
            {
                DatabaseControl.DelUser(p);
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
    }
}
