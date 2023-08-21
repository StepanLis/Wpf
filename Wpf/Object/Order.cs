using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wpf.Object;

namespace Wpf.Object
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date_reg { get; set; }
        public string Comment { get; set; }
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public User UserEntity { get; set; }
        public List<ListComponent> ListComponent { get; set; }
    }
}