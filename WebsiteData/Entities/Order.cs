using System;
using System.Collections.Generic;
using WebsiteData.Entities.Enums;

namespace WebsiteData.Entities
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int? Account_Id { get; set; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerEmail { set; get; }
        public string CustomerMobile { set; get; }
        public Account Account { get; set; }
        public DateTime? Order_PurchaseTime { get; set; }
        public DateTime? Order_DeliveryTime { get; set; }
        public string Order_DeliveryAddress { get; set; }
        public string Order_DeliveryContact { get; set; }
        public string PaymentMethod { set; get; }
        public OrderStatusEnum  Order_Status { get; set; }
        public int Order_Amount { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
