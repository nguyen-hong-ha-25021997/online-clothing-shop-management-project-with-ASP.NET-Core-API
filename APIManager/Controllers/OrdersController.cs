using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIManager.Hepler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteData.Data.Context;
using WebsiteData.Entities;
using Microsoft.EntityFrameworkCore;
using APIManager.Extentions;

namespace APIManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly WebsiteDbContext _context;

        public OrdersController(WebsiteDbContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var a = await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
            return a;
        }

        [HttpGet("GetAllPaging")]
        public async Task<ActionResult> GetAllPagingAsync([FromQuery] PagingParams pagingParams)
        {
            var query = from od in _context.Orders
                        //join acc in _context.Accounts on od.Account_Id equals acc.Id into accGr
                        //from acc in accGr.DefaultIfEmpty()
                        orderby od.Order_PurchaseTime descending
                        select new Order
                        {
                            Order_Id = od.Order_Id,
                            //Account_Id = accGr == null ? 0 : acc.Id,
                            CustomerName = od.CustomerName,
                            CustomerAddress = od.CustomerAddress,
                            CustomerEmail = od.CustomerEmail,
                            CustomerMobile = od.CustomerMobile,
                            Order_Amount = od.Order_Amount,
                            Order_Status = od.Order_Status,
                            Order_PurchaseTime = od.Order_PurchaseTime,
                        };
            if (!string.IsNullOrEmpty(pagingParams.fromDate) && !string.IsNullOrEmpty(pagingParams.toDate))
            {
                DateTime fromDate = DateTime.Parse(pagingParams.fromDate);
                DateTime toDate = DateTime.Parse(pagingParams.toDate);
                query = query.Where(x => (x.Order_PurchaseTime) >= fromDate.Date && (x.Order_PurchaseTime) < toDate.Date.AddDays(1));
            }
            if (!string.IsNullOrEmpty(pagingParams.Keyword))
            {
                var keyword = pagingParams.Keyword.ToUpper().ToTrim();

                query = query.Where(x =>
                                        (x.CustomerName ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        (x.CustomerName ?? string.Empty).ToUpper().Contains(keyword) ||
                                        (x.CustomerEmail ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        (x.CustomerEmail ?? string.Empty).ToUpper().Contains(keyword) ||
                                        (x.CustomerAddress ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        (x.CustomerAddress ?? string.Empty).ToUpper().Contains(keyword) ||
                                        (x.CustomerMobile ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        (x.CustomerMobile ?? string.Empty).ToUpper().Contains(keyword) ||

                                    // Lọc số

                                    (x.Order_Amount.ToString("0.00").Contains(keyword))
                                    );

            }
            if (!string.IsNullOrEmpty(pagingParams.KeywordCol))
            {
                var keyword = pagingParams.KeywordCol.ToUpper().ToTrim();
                if (pagingParams.ColName == "Order_PurchaseTime")
                {
                    query = query.Where(x => (x.Order_PurchaseTime.Value.ToString("dd/MM/yyyy").Contains(keyword)));

                }
                if (pagingParams.ColName == "CustomerName")
                {
                    query = query.Where(x => (x.CustomerName ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.CustomerName ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "CustomerAddress")
                {
                    query = query.Where(x => (x.CustomerAddress ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.CustomerAddress ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "CustomerEmail")
                {
                    query = query.Where(x => (x.CustomerEmail ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.CustomerEmail ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "CustomerMobile")
                {
                    query = query.Where(x => (x.CustomerMobile ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.CustomerMobile ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "Order_Amount")
                {
                    query = query.Where(x => (x.Order_Amount.ToString().Contains(keyword)));

                }
            }
            if (!string.IsNullOrEmpty(pagingParams.SortKey))
            {
                if (pagingParams.SortKey == "CustomerName" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.CustomerName);
                }
                if (pagingParams.SortKey == "CustomerName" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.CustomerName);
                }

                if (pagingParams.SortKey == "CustomerAddress" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.CustomerAddress);
                }
                if (pagingParams.SortKey == "CustomerAddress" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.CustomerAddress);
                }

                if (pagingParams.SortKey == "CustomerEmail" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.CustomerEmail);
                }
                if (pagingParams.SortKey == "CustomerEmail" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.CustomerEmail);
                }

                if (pagingParams.SortKey == "CustomerMobile" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.CustomerMobile);
                }
                if (pagingParams.SortKey == "CustomerMobile" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.CustomerMobile);
                }

                if (pagingParams.SortKey == "Order_Amount" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.Order_Amount);
                }
                if (pagingParams.SortKey == "Order_Amount" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.Order_Amount);
                }
                if (pagingParams.SortKey == "Order_PurchaseTime" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.Order_PurchaseTime);
                }
                if (pagingParams.SortKey == "Order_PurchaseTime" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.Order_PurchaseTime);
                }
            }
            if (pagingParams.PageSize == -1)
            {
                pagingParams.PageSize = await query.CountAsync();
            }
            var paged = await PagedList<Order>.CreateAsync(query, pagingParams.PageNumber, pagingParams.PageSize);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(new { paged.Items, paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages });
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Order_Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Order_Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Order_Id == id);
        }
    }
}
