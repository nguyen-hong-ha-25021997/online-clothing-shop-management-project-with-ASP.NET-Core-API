using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQACustomerArea.Models;

namespace WebQACustomerArea.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        DbWebQAEntities db = new DbWebQAEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KetQuaTimKiem(string tukhoa, int? page)
        {

            ViewBag.TuKhoa = tukhoa;
            List<Product> listkq = db.Products.Where(n => n.Product_Name.Contains(tukhoa) || n.Product_Show.Contains(tukhoa) || n.Product_Price.ToString().Contains(tukhoa) || n.Product_Style.Contains(tukhoa)).ToList();


            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (listkq.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";

            }

            return View(listkq.OrderBy(n => n.Product_Price).ToPagedList(pageNumber, pageSize));

        }
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string tukhoa = f["txtTimKiem"].ToString();

            List<Product> listkq = db.Products.Where(n => n.Product_Name.Contains(tukhoa) || n.Product_Show.Contains(tukhoa) || n.Product_Price.ToString().Contains(tukhoa) || n.Product_Style.Contains(tukhoa)).ToList();
            ViewBag.TuKhoa = tukhoa;

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            if (listkq.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm";

            }

            return View(listkq.OrderBy(n => n.Product_Price).ToPagedList(pageNumber, pageSize));

        }
    }
}