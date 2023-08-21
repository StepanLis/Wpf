using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Object;

namespace Wpf.Object
{
    public class Category
    {
        public int Id { get; set; }
        public string Name_category { get; set; }
        public List<ComponentWarehouse> ComponentWarehouses { get; set; }
    }
}
