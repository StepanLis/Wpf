using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wpf.Database;
using Wpf.Object;
using System.Data.SqlClient;
using System.Windows;

namespace Wpf.Database
{
    public static class DatabaseControl
    {
        public static List<User> GetUsersForView()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.User.ToList();
            }
        }
        public static List<Order> GetOrdersForView()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.Order.ToList();
            }
        }

        public static List<ComponentWarehouse> GetWarehouseForView()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.ComponentWarehouse.Include(p => p.Category).ToList();
            }
        }

        public static void UpdateWarehouse(ComponentWarehouse component)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ComponentWarehouse _component = ctx.ComponentWarehouse.FirstOrDefault(p => p.Id == component.Id);

                _component.Name_component = component.Name_component;
                _component.Quantity = component.Quantity;
                _component.Category = component.Category;

                ctx.SaveChanges();
            }
        }

        public static List<Category> GetCategoryForView()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.Category.ToList();
            }
        }

        public static List<User> GetUserNotAdminForView()
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                return ctx.User.Skip(1).ToList();
            }
        }

        public static void DelUser(User user)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.User.Remove(user);

                ctx.SaveChanges();
            }
        }

        public static List<User> GetUsers()
        {
            using (var context = new DatabaseContext()) // Замените YourDbContext на ваш контекст базы данных
            {
                return context.User.ToList();
            }
        }

        public static void AddUser(User user)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.User.Add(user);
                ctx.SaveChanges();
            }
        }


        public static void AddOrder(Order order)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Order.Add(order);
                ctx.SaveChanges();
            }
        }

        public static void AddComponent(ComponentWarehouse component)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.ComponentWarehouse.Add(component);
                ctx.SaveChanges();
            }
        }

        public static void AddList(ListComponent list)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.ListComponent.Add(list);
                ctx.SaveChanges();
            }
        }

        public static void UpdateList(ListComponent list)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ListComponent _list = ctx.ListComponent.FirstOrDefault(p => p.Id == list.Id);

                _list.Quantity = list.Quantity;
                ctx.SaveChanges();
            }
        }

        public static void DelComponent(ListComponent component)
        {
            using (var dbContext = new DatabaseContext())
            {
                dbContext.ListComponent.Remove(component);
                dbContext.SaveChanges();
            }
        }



        public static void DelOrder(Order order)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Order.Remove(order);

                ctx.SaveChanges();
            }
        }

        public static void DelWarehouse(ComponentWarehouse component)
        {
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.ComponentWarehouse.Remove(component);

                ctx.SaveChanges();
            }
        }

        public static void UpdateComponent(ComponentWarehouse component)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                // Проверяем, что компонент существует в базе данных
                ComponentWarehouse existingComponent = context.ComponentWarehouse.FirstOrDefault(c => c.Id == component.Id);
                if (existingComponent != null)
                {
                    // Обновляем свойства компонента
                    existingComponent.Quantity = component.Quantity;

                    // Сохраняем изменения в базе данных
                    context.SaveChanges();
                }
                else
                {
                    // Обработка ошибки: компонент не найден в базе данных
                    MessageBox.Show("Компонент не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }
}
