using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class EditComponentWarehouse : Window, INotifyPropertyChanged
    {
        private ComponentWarehouse selectedComponent;
        private Category selectedCategory;
        public List<Category> Categories { get; set; }

        public EditComponentWarehouse(ComponentWarehouse component)
        {
            InitializeComponent();

            selectedComponent = component;

            // Инициализация списка категорий
            Categories = DatabaseControl.GetCategoryForView(); // Здесь нужно заменить GetCategories() на ваш метод получения списка категорий

            // Заполнение полей формы значениями выбранного элемента
            textComponent.Text = selectedComponent.Name_component;
            numberTextBox.Text = selectedComponent.Quantity.ToString();
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == selectedComponent.Category.Id);
            DataContext = this;
        }

        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        // Обработчик события при закрытии выпадающего списка ComboBox
        private void CategoryComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            SelectedCategory = (Category)comboBox.SelectedItem;
        }

        // Обработчик события при нажатии кнопки "Изменить"
        private void registrationEndButton_component_Click(object sender, RoutedEventArgs e)
        {
            ComponentWarehouse com = new ComponentWarehouse();
            com.Name_component = textComponent.Text;
            if (int.TryParse(numberTextBox.Text, out int quantity))
            {
                com.Quantity = quantity;
            }
            else
            {
                // Обработка ошибки некорректного значения количества
                MessageBox.Show("Некорректное значение количества компонента.");
                return;
            }

            com.Category = selectedCategory;
            com.Id = selectedComponent.Id;
            DatabaseControl.UpdateWarehouse(com);

            this.Close();
        }

        //// Получение значения выбранной категории
        //string selectedCategoryName = SelectedCategory.Name_category;

        //// Обновление выбранного компонента
        //using (var dbContext = new DatabaseContext()) // Замените YourDbContext на ваш контекст базы данных
        //{
        //    // Находим компонент в базе данных по его идентификатору
        //    var componentToUpdate = dbContext.ListComponent.Find(selectedComponent.Id);

        //    if (componentToUpdate != null)
        //    {
        //        // Обновляем значения компонента
        //        componentToUpdate.Name_component = textComponent.Text;
        //        componentToUpdate.Quantity = int.Parse(numberTextBox.Text);
        //        componentToUpdate.Category = SelectedCategory;

        //        // Сохраняем изменения в базе данных
        //        dbContext.SaveChanges();
        //    }
        //}

        // Закрытие окна редактирования

        // Обработчик события при нажатии кнопки "Отмена"
        private void cancelButton_component_Click(object sender, RoutedEventArgs e)
        {
            // Закрытие окна редактирования
            this.Close();
        }

        // Реализация интерфейса INotifyPropertyChanged для обновления привязок данных
        public event PropertyChangedEventHandler? PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        private static bool AreAllValidNumericChars(string str)
        {
            foreach (var c in str)
            {
                if (!Char.IsNumber(c))
                    return false;
            }
            return true;
        }
    }
}
