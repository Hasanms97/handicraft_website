using System;
using System.Collections.Generic;

#nullable disable

namespace Handicraft_Website.Models
{
    public partial class UserLogin
    {
        public decimal Id { get; set; }
        public string UserName { get; set; }
        public string Passwordd { get; set; }
        public string Email { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? UserrId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Userr Userr { get; set; }
    }
}
