using System;
using System.Collections.Generic;
using System.Text;

namespace WebQA.Application.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderDetail_Id { get; set; }
        public int? Order_Id { get; set; }
        public DateTime Order_PurchaseTime { get; set; }

        public int? Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Style { get; set; }
        public string Product_Size { get; set; }
        public string Product_Image { get; set; }
        public int Product_Price { get; set; }

        public int OrderDetail_Quantity { get; set; }
        public int OrderDetail_Amount { get; set; }
    }
}
