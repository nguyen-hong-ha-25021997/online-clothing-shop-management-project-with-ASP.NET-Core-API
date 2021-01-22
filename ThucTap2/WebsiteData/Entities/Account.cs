using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebsiteData.Interfaces;

namespace WebsiteData.Entities
{
    [Table("Account")]
    public class Account :IdentityUser<int>, IDateTracking
    {
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public List<Order> Orders { get; set; }

        public List<Permission> Permissions { get; set; }
    }
}
