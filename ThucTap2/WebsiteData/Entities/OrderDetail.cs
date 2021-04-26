using WebsiteData.Entities;

namespace WebsiteData.Entities
{
    public class OrderDetail
    {
        public int OrderDetail_Id { get; set; }
        public int? Order_Id { get; set; }
        public Order Order { get; set; }

        public int? Product_Id { get; set; }
        public Product Product { get; set; }

        public int OrderDetail_Quantity { get; set; }
        public int OrderDetail_Amount { get; set; }
       
    }
}
