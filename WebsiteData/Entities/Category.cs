using System;
using System.Collections.Generic;
using System.Text;

namespace WebsiteData.Entities
{
    public class Category
    {
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public int Category_Quantity { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
