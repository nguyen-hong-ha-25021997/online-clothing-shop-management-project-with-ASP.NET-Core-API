using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQACustomerArea.Models
{
    public class OrderViewModel
    {
        public int Order_Id { get; set; }
        public int? Account_Id { get; set; }
        public Account Account { get; set; }
        public string CustomerName { set; get; }
        public string CustomerAddress { set; get; }
        public string CustomerEmail { set; get; }
        public string CustomerMobile { set; get; }
        public DateTime Order_PurchaseTime { get; set; }
        public DateTime Order_DeliveryTime { get; set; }
        public string Order_DeliveryAddress { get; set; }
        public string Order_DeliveryContact { get; set; }
        public string PaymentMethod { set; get; }
        public int Order_Amount { get; set; }
        public string BankCode { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}