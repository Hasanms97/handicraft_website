using System;
using System.Collections.Generic;

#nullable disable

namespace Handicraft_Website.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProduct>();
        }

        public decimal Id { get; set; }
        public decimal? UserrId { get; set; }
        public DateTime? DateOfPruchase { get; set; }
        public decimal? OrderStatus { get; set; }

        public virtual Userr Userr { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }
    }
}
