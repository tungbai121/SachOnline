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
    public partial class UC_Sach : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSach();
            }
        }

        public void GetSach()
        {
            // Tạo kết nối đến CSDL
            string connStr = WebConfigurationManager.ConnectionStrings["SachOnline"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy toàn bộ sách trong bảng Sach
            string sql = "select * from Sach";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            // Gán dữ liệu lên DataList
            DlSach.DataSource = dr;
            DlSach.DataBind();
        }
    }
}