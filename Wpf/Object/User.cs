using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Object;

namespace Wpf.Object
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Date_reg { get; set; }
        public string Role { get; set; } 
        public List<Order> OrderEntity { get; set; }
    }
}
