using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(3,ErrorMessage="The lenght should be at least 3 symbols.")]
        [MaxLength(15, ErrorMessage="The lenght should be at least 15 symbols.")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products 
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
