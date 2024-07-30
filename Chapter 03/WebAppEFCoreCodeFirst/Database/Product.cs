using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppEFCoreCodeFirst.Database
{
    [Table("NewProductTable")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public double Price { get; set; }
        [MaxLength(50, ErrorMessage = "Max length is 50!")]
        public string Description { get; set; }
        public List<ProductCategory> ProductCategories { get; } = new List<ProductCategory>();
    }
}
