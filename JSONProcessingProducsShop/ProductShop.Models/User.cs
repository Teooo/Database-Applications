using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class User
    {


        private ICollection<User> friends;

        private ICollection<Product> sellingProduct;

        private ICollection<Product> boughtProducts;
 
        public User()
        {
            this.friends = new HashSet<User>();
            this.sellingProduct = new HashSet<Product>();
            this.boughtProducts = new HashSet<Product>();
        }
        
        [Key]
        public int Id { get; set; }

      
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> Friends 
        {
            get { return this.friends; }
            set { this.friends = value; }
        }
        public virtual ICollection<Product> SellingProducts
        {
            get { return this.sellingProduct; }
            set { this.sellingProduct = value; }
        }
        public virtual ICollection<Product> BoughtProducts 
        {
            get { return this.boughtProducts; }
            set { this.boughtProducts = value; }
        }


    }
}
