using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microsoft.EntityFrameworkCore;
using Wpf.Database;
using Wpf.Object;

namespace Wpf
{
    /// <summary>
    /// Логика взаимодействия для AddComponentWarehouse.xaml
    /// </summary>
    public partial class AddComponentWarehouse : Window
    {
        public ObservableCollection<Category> Categories { get; set; }
        public AddComponentWarehouse()
        {
            InitializeComponent();
            Categories = new ObservableCollection<Category>(); // Инициализируйте и заполните коллекцию категорий

            List<Category> categoriesFromDatabase = DatabaseControl.GetCategoryForView(); // Замените это соответствующим кодом получения категорий из базы данных
                                                                                          // Добавьте полученные категории в коллекцию
            foreach (Category category in categoriesFromDatabase)
            {
                Categories.Add(category);
            }

            DataContext = this; // Установите контекст данных для привязки
        }
        private void categoryComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // Выполните действия по обработке выбранной категории
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли вводимый символ числовым
            if (!IsNumericInput(e.Text))
            {
                e.Handled = true; // Отменяем ввод символа
            }
        }

        private bool IsNumericInput(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }

        private void cancelButton_component_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void registrationEndButton_component_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new DatabaseContext())
            {
                Category selectedCategory = (Category)categoryComboBox.SelectedItem;
                string componentName = textComponent.Text;
                int categoryId = selectedCategory.Id;

                ComponentWarehouse existingComponent = dbContext.ComponentWarehouse.FirstOrDefault(c => c.Name_component == componentName && c.Id_category == categoryId);

                if (existingComponent != null)
                {
                    existingComponent.Quantity += int.Parse(numberTextBox.Text);
                    dbContext.SaveChanges();
                }
                else
                {
                    DatabaseControl.AddComponent(new ComponentWarehouse
                    {
                        Name_component = componentName,
                        Date_reg = DateTime.UtcNow,
                        Quantity = int.Parse(numberTextBox.Text),
                        Id_category = categoryId
                    });
                }
            }
            this.Close();
        }


        //private void registrationEndButton_component_Click(object sender, RoutedEventArgs e)
        //{
        //    AddComponentToWarehouse(); // Вызываем метод для добавления компонента в ComponentWarehouse
        //    this.Close(); // Закрываем окно после добавления компонента
        //}
    }
}
