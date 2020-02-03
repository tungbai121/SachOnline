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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnDangNhap_Click(object sender, EventArgs e)
        {
            // Tạo kết nối đến CSDL
            string connStr = WebConfigurationManager.ConnectionStrings["SachOnline"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy toàn bộ dữ liệu trong bảng NguoiDung
            string sql = "Select * from NguoiDung where (TenDangNhap=N'" + TxtTenDangNhap.Text + "') and (MatKhau=N'" + TxtMatKhau.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Dữ liệu lấy ra được lưu vào biến dr
            SqlDataReader dr = cmd.ExecuteReader();

            // HasRows là thuộc tính kiểu boolean của DataReader, cho biết DataReader có chứa dữ liệu hay không?
            if (dr.HasRows == true)
            {
                Session["TenDangNhap"] = TxtTenDangNhap.Text;
                Response.Redirect("DefaultAdmin.aspx");
            }
            else
            {
                LblLoiDangNhap.Text = "Đăng nhập thất bại! Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }
    }
}