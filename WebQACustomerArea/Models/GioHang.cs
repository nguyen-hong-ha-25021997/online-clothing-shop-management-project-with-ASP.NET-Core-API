using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQACustomerArea.Models
{
    public class GioHang
    {
        DbWebQAEntities db = new DbWebQAEntities();
        public int maSP { get; set; }
        public string tenSP { get; set; }
        public string hinhanh { get; set; }
        public int dongia { get; set; }
        public int soluong { get; set; }
        public double thanhtien
        {
            get { return dongia * soluong; }
        }
        //ham tao cho gio hang
        public GioHang(int imaSP)
        {
            maSP = imaSP;//gán tham số truyền vào
            Product sp = db.Products.Single(n => n.Product_Id == maSP);
            tenSP = sp.Product_Name;
            hinhanh = sp.Product_Image;
            dongia = sp.Product_Price;
            soluong = 1;

        }

    }
}