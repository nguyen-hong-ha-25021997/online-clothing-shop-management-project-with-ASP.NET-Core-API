using System;
using System.Collections.Generic;
using System.Text;
using WebsiteData.Entities;

namespace WebQA.Application.ViewModels
{
    public class ReportChartViewModel
    {
        public int Month { get; set; }

        public int OrderAmount { get; set; }
        public int Quantity { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
