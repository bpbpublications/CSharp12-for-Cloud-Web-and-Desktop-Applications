using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirst.Database
{
    public class Supermarket
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
