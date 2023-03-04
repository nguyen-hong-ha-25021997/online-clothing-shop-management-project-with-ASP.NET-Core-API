using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteData.Interfaces;

namespace WebsiteData.Entities
{
    public class Function: IdentityRole<int>, IDateTracking, IHasSoftDelete
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
