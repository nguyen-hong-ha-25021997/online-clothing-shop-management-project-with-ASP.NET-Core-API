using System;
using System.Collections.Generic;
using System.Text;

namespace WebQA.Application.ViewModels
{
    public class ReportsViewModel
    {
    }
    public class ReportsDaily
    {
        public int NumberOfProduct { get; set; }
        public int Profit { get; set; }
        public int NumberOfOrder { get; set; }
    }
    public class ReportsAnnual
    {
        public int Month { get; set; }
        public int NumberOfProduct { get; set; }
        public int Profit { get; set; }
        public int NumberOfOrder { get; set; }
    }
}
