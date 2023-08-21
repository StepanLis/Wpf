using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Wpf.Database;
using Wpf.Object;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для Component.xaml
    /// </summary>
    public partial class Component : Window
    {
        public User dbUser;
        public Order selectedOrders;
        public List<ComponentWarehouse> Components { get; set; }
        // Создание отфильтрованной коллекции только с компонентами, количество которых больше 0
        

        public Component(User _dbUser, List<Order> orders, Order _selectedOrders)
        {
            InitializeComponent();
            RefreshComponentList();


            DataContext = this;
            selectedOrders = _selectedOrders;
            dbUser = _dbUser;

            List<ListComponent> allComponents = new List<ListComponent>();


            foreach (var order in orders)
            {
                List<ListComponent> orderComponents = LoadComponentsForOrder(order);
                allComponents.AddRange(orderComponents);
            }

            if (allComponents.Any())
            {
                ComponentDataGrid.ItemsSource = allComponents;
            }

            Components = DatabaseControl.GetWarehouseForView();
            // Создание отфильтрованной коллекции только с компонентами, количество которых больше 0
            List<ComponentWarehouse> filteredComponents = Components.Where(c => c.Quantity > 0).ToList();

            // Установка отфильтрованной коллекции в качестве источника данных для ComboBox
            componentComboBox.ItemsSource = filteredComponents;


        }
        private List<ListComponent> LoadComponentsForOrder(Order order)
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.ListComponent.Where(component => component.Order_id == order.Id).ToList();
            }
        }

        public void RefreshTable(Order selectedOrders)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                List<ListComponent> components = dbContext.ListComponent
                    .Where(component => component.Order_id == selectedOrders.Id)
                    .ToList();
                ComponentDataGrid.ItemsSource = components;
            }
        }

        private void del_button_Click_com(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный компонент
            ListComponent selectedComponent = ComponentDataGrid.SelectedItem as ListComponent;

            if (selectedComponent != null)
            {
                DatabaseControl.DelComponent(selectedComponent);
                RefreshTable(selectedOrders);
            }
            else
            {
                MessageBox.Show("Выберите компонент для удаления.");
            }
        }

        private void AddButton_clickComponent_Click(object sender, RoutedEventArgs e)
        {
            // Получение выбранного компонента из комбобокса
            ComponentWarehouse selectedComponent = componentComboBox.SelectedItem as ComponentWarehouse;

            // Проверка наличия выбранного компонента
            if (selectedComponent == null)
            {
                MessageBox.Show("Пожалуйста, выберите компонент.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Получение значения количества из текстового поля
            int quantity;
            if (!int.TryParse(quantityTextBox.Text, out quantity))
            {
                // Вывод ошибки, если введено некорректное значение количества
                MessageBox.Show("Некорректное значение количества.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Проверка наличия достаточного количества компонентов
            if (selectedComponent.Quantity < quantity)
            {
                MessageBox.Show("Недостаточное количество компонентов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание нового объекта ListComponent
            ListComponent listComponent = new ListComponent
            {
                Quantity = quantity,
                Component_warehouse_id = selectedComponent.Id,
                Order_id = selectedOrders.Id
            };

            // Добавление объекта ListComponent в контекст базы данных
            DatabaseControl.AddList(listComponent);

            // Уменьшение количества компонентов в ComponentWarehouse
            selectedComponent.Quantity -= quantity;

            // Обновление компонента в базе данных
            DatabaseControl.UpdateComponent(selectedComponent);

            // Очистка полей комбобокса и текстового поля
            componentComboBox.SelectedItem = null;
            quantityTextBox.Text = string.Empty;

            // Вывод сообщения об успешном добавлении
            MessageBox.Show("Компонент успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            RefreshTable(selectedOrders);
        }




        private void RefreshComponentList()
        {
            using (var dbContext = new DatabaseContext())
            {
                List<ComponentWarehouse> components = dbContext.ComponentWarehouse.ToList();
                componentComboBox.ItemsSource = components;
            }
        }


        //private void componentComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    ComboBox comboBox = (ComboBox)sender;
        //    if (comboBox.SelectedItem != null)
        //    {
        //        string selectedComponent = comboBox.SelectedItem.ToString();
        //    }
        //}

    }
}
