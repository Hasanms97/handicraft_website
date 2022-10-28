﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace Handicraft_Website.Models
{
  public partial class Category
  {
    public Category()
    {
      Products = new HashSet<Product>();
    }

    public decimal Id { get; set; }
    public string CategoryName { get; set; }
    public string ImagePath { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    public virtual ICollection<Product> Products { get; set; }
  }
}
