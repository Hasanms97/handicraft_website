using System;
using System.Collections.Generic;

#nullable disable

namespace Handicraft_Website.Models
{
    public partial class PaymentMethod
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public byte? CvvNumber { get; set; }
        public long? CardNumber { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public decimal? UserrId { get; set; }

        public virtual Userr Userr { get; set; }
    }
}
