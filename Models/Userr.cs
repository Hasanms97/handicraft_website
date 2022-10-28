using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

#nullable disable

namespace Handicraft_Website.Models
{
  public partial class Userr
  {
    public Userr()
    {
      Addresses = new HashSet<Address>();
      Carts = new HashSet<Cart>();
      PaymentMethods = new HashSet<PaymentMethod>();
      Testimonials = new HashSet<Testimonial>();
      UserLogins = new HashSet<UserLogin>();
    }

    public decimal Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImagePath { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Cart> Carts { get; set; }
    public virtual ICollection<PaymentMethod> PaymentMethods { get; set; }
    public virtual ICollection<Testimonial> Testimonials { get; set; }
    public virtual ICollection<UserLogin> UserLogins { get; set; }
  }
}
