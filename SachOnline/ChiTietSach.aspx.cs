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
    public partial class ChiTietSach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int maSach = int.Parse(Request.QueryString.Get("MaSach"));
                GetChiTietSach(maSach);
            }
        }

        public void GetChiTietSach(int maSach)
        {
            // Tạo kết nối đến CSDL
            string connStr = WebConfigurationManager.ConnectionStrings["SachOnline"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy sách theo MaSach
            string sql = "select * from Sach where MaSach=" + maSach;
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            // Gán dữ liệu lên GridView
            GvChiTietSach.DataSource = dr;
            GvChiTietSach.DataBind();
        }
    }
}