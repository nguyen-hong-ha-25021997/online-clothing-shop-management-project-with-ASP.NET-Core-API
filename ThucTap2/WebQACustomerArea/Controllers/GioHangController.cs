using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQACustomerArea.Models;

namespace WebQACustomerArea.Controllers
{
    public class GioHangController : Controller
    {
        DbWebQAEntities db = new DbWebQAEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        //lay gio hang
        #region Giỏ hàng
        public List<GioHang> laygiohang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;//ép kiểu sesion giỏ hàng khi giỏ hàng tồn tại ,nếu không tồn tại trả về null
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //them gio hang
        public ActionResult themgiohang(int masp, string url)
        {
            //lấy ra sesion giỏ hàng
            List<GioHang> lstgiohang = laygiohang();
            Product sp = db.Products.SingleOrDefault(n => n.Product_Id == masp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //kiểm tra sản phẩm đã tồn tại trong giỏ hàng chưa
            GioHang sanpham = lstgiohang.Find(n => n.maSP == masp);
            if (sanpham == null)
            {
                sanpham = new GioHang(masp);
                lstgiohang.Add(sanpham);
                return Redirect(url);
            }
            else
            {
                sanpham.soluong++;
                return Redirect(url);
            }
        }
        //cập nhật giỏ hàng
        public ActionResult capnhatgiohang(int maSP, FormCollection f)
        {
            //Kiểm tra mã sản phẩm
            Product sp = db.Products.SingleOrDefault(n => n.Product_Id == maSP);
            //nếu get sai mã sản phẩm thì trả về trang lỗi
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra
            List<GioHang> lstgiohang = laygiohang();
            //Kiểm tra sản phẩm có tồn tại trong sesion giỏ hàng k
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.maSP == maSP);
            if (sanpham != null)
            {
                sanpham.soluong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");//không sử dụng View vì k có định nghĩa kiểu Model
        }
        public ActionResult xoagiohang(int maSP)
        {
            Product sp = db.Products.SingleOrDefault(n => n.Product_Id == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra session
            List<GioHang> lstgiohang = laygiohang();
            GioHang sanpham = lstgiohang.SingleOrDefault(n => n.maSP == maSP);
            //
            if (sanpham != null)
            {
                lstgiohang.RemoveAll(n => n.maSP == maSP);
            }
            if (lstgiohang.Count == 0)
            {
                return RedirectToAction("TrangChu", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("TrangChu", "Home");
            }
            List<GioHang> lstgiohang = laygiohang();
            return View(lstgiohang);
        }
        public ActionResult Home()
        {
            if (Session["GioHang"] != null)
            {
                Session["GioHang"] = null;

            }
            return RedirectToAction("TrangChu", "Home");
        }
        private int tongsoluong()
        {
            int soluong = 0;
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if (lstgiohang != null)
            {
                soluong = lstgiohang.Sum(n => n.soluong);
            }
            return soluong;
        }
        public PartialViewResult TongSL()
        {
            ViewBag.TongSL = tongsoluong();
            return PartialView();
        }
        private double tongtien()
        {
            double tien = 0;
            List<GioHang> lstgiohang = Session["GioHang"] as List<GioHang>;
            if (lstgiohang != null)
            {
                tien = lstgiohang.Sum(n => n.thanhtien);
            }
            return tien;
        }
        public PartialViewResult TongTien()
        {
            ViewBag.TongTien = tongtien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("TrangChu", "Home");
            }
            List<GioHang> lstgiohang = laygiohang();
            return View(lstgiohang);
        }
        #endregion
        #region Đặt hàng

        [HttpPost]
        public ActionResult DatHang()
        {


            //Kiem tra dang nhap
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("TrangChu", "Home");

            }
            //Thêm đơn đặt hàng

            //Kiểm tra tài khoản 
            Order dk = new Order();

            Order hd = (Order)Session["HoaDon"];
            Account kh = (Account)Session["TaiKhoan"];
            List<GioHang> gh = laygiohang();
            dk.Account_Id = kh.Id;
            dk.Order_PurchaseTime = DateTime.Now;
            dk.Order_DeliveryAddress = hd.Order_DeliveryAddress;
            dk.Order_DeliveryContact = hd.Order_DeliveryContact;

            db.Orders.Add(dk);

            db.SaveChanges();//luu vao csdl


            foreach (var item in gh)
            {
                OrderDetail ct = new OrderDetail();
                ct.Order_Id = dk.Order_Id;
                ct.Product_Id = item.maSP;
                ct.OrderDetail_Quantity = item.soluong;
                db.OrderDetails.Add(ct);
            }




            //Luu lai chi tiet don hang


            db.SaveChanges();


            return RedirectToAction("TrangChu", "Home");
        }
        #endregion


    }
}