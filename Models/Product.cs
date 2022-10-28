using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace Handicraft_Website.Models
{
  public partial class Product
  {
    public Product()
    {
      CartProducts = new HashSet<CartProduct>();
    }

    public decimal Id { get; set; }
    public string Name { get; set; }
    public decimal? Price { get; set; }
    public decimal? CategoryId { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
    public decimal? Quantity { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    public virtual Category Category { get; set; }
    public virtual ICollection<CartProduct> CartProducts { get; set; }
  }
}
