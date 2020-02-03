using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace SachOnline
{
    public partial class SachTheoTheloai : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["SachOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["MaLoaiLayDuoc"] = int.Parse(Request.QueryString.Get("MaLoai"));
                GetSach();
                GetSoLuong();
            }
        }

        public void GetSach()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy sách theo thể loại
            string sql ="select * from Sach where MaLoai=" + (int)ViewState["MaLoaiLayDuoc"];
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            
            // Gán dữ liệu lên DataList
            DlSach.DataSource = dr;
            DlSach.DataBind();
        }

        public void GetSoLuong()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Đếm số lượng sách theo thể loại
            string sql = "Select Count(*) from Sach where MaLoai=" + (int)ViewState["MaLoaiLayDuoc"];
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Hiển thị kết quả qua Label
            int soLuong = (int)cmd.ExecuteScalar();
            LblTongSoSach.Text = "Tìm được [" + soLuong.ToString() + "] sách";
        }
    }
}