using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIManager.Extentions;
using APIManager.Hepler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQA.Application.ViewModels;
using WebsiteData.Data.Context;
using WebsiteData.Entities;

namespace APIManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly WebsiteDbContext _context;

        public OrderDetailsController(WebsiteDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            var a = await _context.OrderDetails.Include(p => p.Product).Include(o => o.Order).ToListAsync();
            return a;
        }

        // GET: api/OrderDetails/5
        [HttpGet("{id}")]
        public ActionResult<OrderDetail> GetOrderDetailByOrderId(int id)
        {
            var orderDetail = _context.OrderDetails.Where(od => od.Order_Id == id).Include(p => p.Product).Include(o => o.Order);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        [HttpGet("GetAllPaging")]
        public async Task<ActionResult> GetAllPagingAsync([FromQuery] PagingParams pagingParams, int order_Id)
        {
            var query = from odt in _context.OrderDetails
                        join od in _context.Orders on odt.Order_Id equals od.Order_Id
                        join pd in _context.Products on odt.Product_Id equals pd.Product_Id
                        where odt.Order_Id == order_Id
                        orderby od.Order_PurchaseTime descending
                        select new OrderDetailViewModel
                        {
                            OrderDetail_Id = odt.OrderDetail_Id,
                            Order_Id = odt.Order_Id,
                            Product_Name = pd.Product_Name,
                            Product_Style = pd.Product_Style,
                            Product_Size = pd.Product_Size,
                            Product_Image = pd.Product_Image,
                            Product_Price = pd.Product_Price,
                            OrderDetail_Quantity = odt.OrderDetail_Quantity,
                            OrderDetail_Amount = odt.OrderDetail_Amount,
                            Order_PurchaseTime = od.Order_PurchaseTime ?? DateTime.Now,
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
                                        (x.Product_Name ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||
                                        (x.Product_Style ?? string.Empty).ToUpper().Contains(keyword) ||
                                        (x.Product_Size ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) ||

                                    // Lọc số

                                    (x.OrderDetail_Quantity.ToString("0.00").Contains(keyword)) ||
                                    (x.Product_Price.ToString("0.00").Contains(keyword)) ||
                                    (x.OrderDetail_Amount.ToString("0.00").Contains(keyword))
                                    );
            }
            if (!string.IsNullOrEmpty(pagingParams.KeywordCol))
            {
                var keyword = pagingParams.KeywordCol.ToUpper().ToTrim();
                if (pagingParams.ColName == "Order_PurchaseTime")
                {
                    query = query.Where(x => (x.Order_PurchaseTime.ToString("dd/MM/yyyy").Contains(keyword)));

                }
                if (pagingParams.ColName == "Product_Name")
                {
                    query = query.Where(x => (x.Product_Name ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.Product_Name ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "Product_Style")
                {
                    query = query.Where(x => (x.Product_Style ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.Product_Style ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "Product_Size")
                {
                    query = query.Where(x => (x.Product_Size ?? string.Empty).ToUpper().ToUnSign().Contains(keyword.ToUnSign()) || (x.Product_Size ?? string.Empty).ToUpper().Contains(keyword));
                }
                if (pagingParams.ColName == "OrderDetail_Amount")
                {
                    query = query.Where(x => (x.OrderDetail_Amount.ToString().Contains(keyword)));

                }
            }
            if (!string.IsNullOrEmpty(pagingParams.SortKey))
            {
                if (pagingParams.SortKey == "Product_Name" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.Product_Name);
                }
                if (pagingParams.SortKey == "Product_Name" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.Product_Name);
                }

                if (pagingParams.SortKey == "Product_Style" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.Product_Style);
                }
                if (pagingParams.SortKey == "Product_Style" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.Product_Style);
                }

                if (pagingParams.SortKey == "Product_Size" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.Product_Size);
                }
                if (pagingParams.SortKey == "Product_Size" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.Product_Size);
                }

                if (pagingParams.SortKey == "OrderDetail_Amount" && pagingParams.SortValue == "ascend")
                {
                    query = query.OrderBy(x => x.OrderDetail_Amount);
                }
                if (pagingParams.SortKey == "OrderDetail_Amount" && pagingParams.SortValue == "descend")
                {
                    query = query.OrderByDescending(x => x.OrderDetail_Amount);
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
            var paged = await PagedList<OrderDetailViewModel>.CreateAsync(query, pagingParams.PageNumber, pagingParams.PageSize);
            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);
            return Ok(new { paged.Items, paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages });
        }

        // PUT: api/OrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetail_Id)
            {
                return BadRequest();
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
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

        // POST: api/OrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderDetail_Id }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetail_Id == id);
        }
    }
}
