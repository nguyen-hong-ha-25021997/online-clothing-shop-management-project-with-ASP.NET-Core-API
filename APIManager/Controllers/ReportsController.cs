using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebQA.Application.ViewModels;
using WebsiteData.Data.Context;
using System.Linq;

namespace APIManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly WebsiteDbContext _context;

        public ReportsController(WebsiteDbContext context)
        {
            _context = context;
        }
        [HttpGet("ReportsDaily")]
        public ActionResult<ReportsDaily> ReportsDaily()
        {
            var query = from od in _context.Orders
                        where od.Order_PurchaseTime.Value.Day == DateTime.Now.Day
                        select new
                        {
                            OrderAmount = od.Order_Amount,
                            Quantity = (from odt in _context.OrderDetails
                                        where odt.Order_Id == od.Order_Id
                                        select odt.OrderDetail_Quantity).Sum(),
                        };
            ReportsDaily a = new()
            {
                NumberOfOrder = query.Count(),
                Profit = query.Sum(x => x.OrderAmount),
                NumberOfProduct = query.AsEnumerable().Sum(x => x.Quantity)
            };
            return Ok(a);
        }
        [HttpGet("ReportsAnnual")]
        public ActionResult<ReportsAnnual> ReportsAnnual()
        {
            var query = from od in _context.Orders
                        where od.Order_PurchaseTime.Value.Year == DateTime.Now.Year
                        orderby od.Order_PurchaseTime.Value.Month
                        select new
                        {
                            Month = od.Order_PurchaseTime.Value.Month,
                            OrderAmount = od.Order_Amount,
                            Quantity = (from odt in _context.OrderDetails
                                        where odt.Order_Id == od.Order_Id
                                        select odt.OrderDetail_Quantity).Sum(),
                        };
            //var a = from x in query
            //        group x by x.Month into y
            //        select new
            //        {
            //            Month = y.Key,
            //            OrderAmount = (from z in y
            //                           select z.OrderAmount).Sum(),
            //            Quantity = (from z in y
            //                        select z.Quantity).Sum(),
            //        };
            var a = query.GroupBy(x => new { x.Month }).Select(x => new
            {
                Month = x.Key.Month,
                OrderAmount = x.Sum(y => (y.OrderAmount)),
                //Quantity = x.Sum(y => (y.Quantity))
            }).ToList();
            return Ok(a);
        }
    }
}
