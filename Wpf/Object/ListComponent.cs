using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.Object;

namespace Wpf.Object
{
    public class ListComponent
    {
        [Key] public int Id { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Order")]  public int Order_id { get; set; }
        public Order Order { get; set; }
        [ForeignKey("ComponentWarehouse")] public int Component_warehouse_id { get; set; }
        public ComponentWarehouse ComponentWarehouse { get; set; }

    }
}
