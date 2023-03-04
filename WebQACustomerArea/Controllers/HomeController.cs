using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQACustomerArea.Models;

namespace WebQACustomerArea.Controllers
{
    public class HomeController : Controller
    {
        DbWebQAEntities db = new DbWebQAEntities();

        public static string loaiSP;
        //Trang chur
        public ActionResult TrangChu()
        {
            return View();
        }
        //San pham ban chay
        public PartialViewResult SanPhamBanChay(int? page)
        {
            //Tạo số sản phẩm của trang
            int pageSize = 4;
            //tao so trang
            int pageNumber = (page ?? 1);//nesu khong du 8 san pham thi mac dinh la 1 trang
            return PartialView(db.Products.Where(n => n.Product_Note == "Bán Chạy").ToList().OrderBy(n => n.Product_Price).ToPagedList(pageNumber, pageSize));
        }
        //san pham sales
        public PartialViewResult SanPhamSalesShow()
        {
            return PartialView(db.Products.Where(n => n.Product_Note == "Sales").Take(4).ToList());
        }
        public PartialViewResult SanPhamSales(int? page)
        {
            //Tạo số sản phẩm của trang
            int pageSize = 4;
            //tao so trang
            int pageNumber = (page ?? 1);//nesu khong du 8 san pham thi mac dinh la 1 trang
            return PartialView(db.Products.Where(n => n.Product_Note == "Sales").ToList().OrderBy(n => n.Product_Price).ToPagedList(pageNumber, pageSize));


        }
        //san pham moi
        public PartialViewResult SanPhamMoi(int? page)
        {
            //Tạo số sản phẩm của trang
            int pageSize = 7;
            //tao so trang
            int pageNumber = (page ?? 1);//nesu khong du 8 san pham thi mac dinh la 1 trang
            return PartialView(db.Products.Where(n => n.Product_Note == "Mới").ToList().OrderBy(n => n.Product_Price).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult DanhMuc()
        {
            //var rs = from ct in db.Categories
            //         select new CategoryViewModel
            //         {
            //             Category_Id = ct.Category_Id,
            //             Category_Name = ct.Category_Name,
            //             Category_Quantity = ct.Category_Quantity
            //         };

            //return PartialView(rs.ToList());
            return PartialView(db.Categories.ToList());
        }
        //chi tiet
        public PartialViewResult XemChiTietSanPham(int MaSanPham = 0 )
        {
            Product sp = db.Products.SingleOrDefault(n => n.Product_Id == MaSanPham);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(sp);
        }

        //cac san pham
        public ViewResult CacSanPham(string type, int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            loaiSP = type;
            return View(db.Products.Where(n => n.Product_Style == type).ToList().ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult SanPhamMoiShow()
        {
            return PartialView(db.Products.Where(n => n.Product_Note == "Mới").Take(4).ToList());
        }
        //tung loai san pham
        public ViewResult TungLoaiSanPham(string loai, int? page)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);

            loaiSP = loai;


            return View(db.Products.Where(n => n.Category_Id.ToString() == loai).ToList().ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult dau()
        {
            return PartialView();
        }
        public PartialViewResult cuoi()
        {
            return PartialView();
        }
    }
}