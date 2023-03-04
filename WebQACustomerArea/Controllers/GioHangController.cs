using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebQACustomerArea.Common;
using WebQACustomerArea.Models;
using WebQACustomerArea.NganLuongAPI;

namespace WebQACustomerArea.Controllers
{
    public class GioHangController : Controller
    {
        private string merchantId = "49440";
        private string merchantPassword = "1db0e9b420e85d4a81cb5f94bbf46620";
        private string merchantEmail = "nguyenhongha250297@gmail.com";

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
        public ActionResult DatHang(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            ////Kiem tra dang nhap
            //if (Session["TaiKhoan"] == null)
            //{
            //    return RedirectToAction("DangNhap", "KhachHang");
            //}
            ////Kiểm tra giỏ hàng
            //if (Session["GioHang"] == null)
            //{
            //    return RedirectToAction("TrangChu", "Home");

            //}
            //Thêm đơn đặt hàng
            //Kiểm tra tài khoản 
            Order od = new Order();
            Account acc = (Account)Session["TaiKhoan"];
            List<GioHang> gh = laygiohang();
            //od.Account_Id = acc.Id;
            od.CustomerName = order.CustomerName;
            od.Order_PurchaseTime = DateTime.Now;
            od.CustomerAddress = order.CustomerAddress;
            od.CustomerEmail = order.CustomerEmail;
            od.CustomerMobile = order.CustomerMobile;
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in gh)
            {
                OrderDetail odt = new OrderDetail();
                odt.Order_Id = od.Order_Id;
                odt.Product_Id = item.maSP;
                odt.OrderDetail_Quantity = item.soluong;
                odt.OrderDetail_Amount = (int)item.thanhtien;
                db.OrderDetails.Add(odt);
                Product pd = db.Products.FirstOrDefault(x => x.Product_Id == item.maSP);
                pd.Product_Quantity = pd.Product_Quantity - item.soluong;
                od.Order_Amount += (int)item.thanhtien;
            }
            //Luu lai csdl
            db.Orders.Add(od);
            db.SaveChanges();
            if (order.PaymentMethod == "CASH")
            {
                return Json(new
                {
                    status = true
                });
            }
            else
            {

                var currentLink = "https://localhost:44336/";
                RequestInfo info = new RequestInfo();
                info.Merchant_id = merchantId;
                info.Merchant_password = merchantPassword;
                info.Receiver_email = merchantEmail;



                info.cur_code = "vnd";
                info.bank_code = order.BankCode;

                info.Order_code = od.Order_Id.ToString();
                info.Total_amount = gh.Sum(x => x.soluong * x.dongia).ToString();
                info.fee_shipping = "0";
                info.Discount_amount = "0";
                info.order_description = "Thanh toán đơn hàng tại TeduShop";
                info.return_url = currentLink + "xac-nhan-don-hang.html";
                info.cancel_url = currentLink + "huy-don-hang.html";

                info.Buyer_fullname = order.CustomerName;
                info.Buyer_email = order.CustomerEmail;
                info.Buyer_mobile = order.CustomerMobile;

                APICheckoutV3 objNLChecout = new APICheckoutV3();
                ResponseInfo result = objNLChecout.GetUrlCheckout(info, order.PaymentMethod);
                if (result.Error_code == "00")
                {
                    return Json(new
                    {
                        status = true,
                        urlCheckout = result.Checkout_url,
                        message = result.Description
                    });
                }
                else
                    return Json(new
                    {
                        status = false,
                        message = result.Description
                    });
            }
        }
        #endregion

    }
}