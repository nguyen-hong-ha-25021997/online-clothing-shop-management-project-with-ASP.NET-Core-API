using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteData.Interfaces
{
    public interface IHasSoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
