using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebsiteData.Entities;
using WebsiteData.Entities.Enums;

namespace WebsiteData.Entities
{
    public class Product
    {
        public int Product_Id { get; set; }
        public int? Category_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Style { get; set; }
        public string Product_Size { get; set; }
        public string Product_Image { get; set; }
        public string Product_Show { get; set; }
        public int Product_Price { get; set; }
        public int Product_SalePrice { get; set; }
        public string Product_Note { get; set; }
        public int Product_Quantity { get; set; }
        public ProductStatusPriceEnum StatusPrice { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
