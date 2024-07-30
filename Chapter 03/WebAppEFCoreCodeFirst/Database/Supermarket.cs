using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEFCoreCodeFirst.Database
{
    public class Supermarket
    {
        public int Id { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "The City is required.")]
        public string City { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
