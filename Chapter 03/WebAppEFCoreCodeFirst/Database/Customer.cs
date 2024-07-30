using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEFCoreCodeFirst.Database
{
    public class Customer
    {
        public int Id { get; set; }
        [Column("CustomerName", Order = 5)]
        public string Name { get; set; }
        public string Address { get; set; }
        [Precision(2)]
        public int Age { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
