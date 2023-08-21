using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Object;

namespace Wpf.Object
{
    public class ComponentWarehouse
    {
        [Key] public int Id { get; set; }
        public string ?Name_component { get; set; }
        public DateTime Date_reg { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Category")] public int Id_category { get; set; }
        public Category ?Category { get; set; }
        public List<ListComponent> ?ListComponents { get; set; }
    }
}
