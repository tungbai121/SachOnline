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
    public partial class QuanLyNguoiDung : System.Web.UI.Page
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["SachOnline"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TenDangNhap"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    GetNguoiDung();
                }
            }
        }

        public void GetNguoiDung()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy dữ liệu từ bảng NguoiDung
            string sql = "select * from NguoiDung";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            
            // Gán dữ liệu lên GridView
            GvNguoiDung.DataSource = dr;
            GvNguoiDung.DataBind();
        }

        protected void BtnThem_Click(object sender, EventArgs e)
        {
            GvNguoiDung.SelectedIndex = -1;

            LblThongBao.Visible = false;

            TxtID.Enabled = false;

            TxtTenDangNhap.Enabled = true;
            TxtMatKhau.Enabled = true;

            TxtID.Text = "";
            TxtTenDangNhap.Text = "";
            TxtMatKhau.Text = "";

            TxtTenDangNhap.Focus();

            BtnLuu.Enabled = true;
            BtnHuy.Enabled = true;

            BtnThem.Enabled = false;
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;

            // Đánh dấu trạng thái thêm
            ViewState["flag"] = true;
        }

        private void Them()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Thêm người dùng vào CSDL
            string sql = "insert into NguoiDung(TenDangNhap,MatKhau) Values(N'" + TxtTenDangNhap.Text + "',N'" + TxtMatKhau.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã thêm thành công!";
                GetNguoiDung();
            }
            else
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã thêm không thành công!";
            }
        }

        protected void BtnXoa_Click(object sender, EventArgs e)
        {
            LblThongBao.Visible = true;
            LblThongBao.Text = "Bạn có muốn xóa không?";
            BtnCo.Visible = true;
            BtnKhong.Visible = true;
        }

        protected void BtnCo_Click(object sender, EventArgs e)
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Xoá người dùng khỏi CSDL
            string sql = "delete NguoiDung where ID='" + TxtID.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã xóa thành công!";

                TxtID.Enabled = false;
                TxtTenDangNhap.Enabled = false;
                TxtMatKhau.Enabled = false;

                TxtID.Text = "";
                TxtTenDangNhap.Text = "";
                TxtMatKhau.Text = "";

                BtnXoa.Enabled = false;
                BtnSua.Enabled = false;
                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;
                BtnCo.Visible = false;
                BtnKhong.Visible = false;

                GetNguoiDung();
                GvNguoiDung.SelectedIndex = -1;
            }
        }

        protected void BtnKhong_Click(object sender, EventArgs e)
        {
            LblThongBao.Visible = false;
            BtnCo.Visible = false;
            BtnKhong.Visible = false;
        }

        protected void BtnSua_Click(object sender, EventArgs e)
        {
            LblThongBao.Visible = false;

            TxtID.Enabled = false;

            TxtTenDangNhap.Enabled = true;
            TxtMatKhau.Enabled = true;

            BtnLuu.Enabled = true;
            BtnHuy.Enabled = true;

            BtnThem.Enabled = false;
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;

            // Đánh dấu trạng thái sửa
            ViewState["flag"] = false;
        }

        private void Sua()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Sửa người dùng trong CSDL
            string sql = "update NguoiDung set TenDangNhap=N'" + TxtTenDangNhap.Text + "',MatKhau=N'" + TxtMatKhau.Text + "' where ID='" + TxtID.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa thành công!";
                GetNguoiDung();
            }
            else
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa không thành công!";
            }

        }

        protected void BtnLuu_Click(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            TxtTenDangNhap.Enabled = false;
            TxtMatKhau.Enabled = false;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                Them();

                TxtID.Text = "";
                TxtTenDangNhap.Text = "";
                TxtMatKhau.Text = "";

                BtnThem.Enabled = true;

                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;

                BtnXoa.Enabled = false;
                BtnSua.Enabled = false;
            }
            // Trạng thái sửa
            else
            {
                Sua();

                BtnThem.Enabled = true;

                BtnXoa.Enabled = true;
                BtnSua.Enabled = true;

                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;
            }
        }

        protected void BtnHuy_Click(object sender, EventArgs e)
        {
            TxtID.Enabled = false;
            TxtTenDangNhap.Enabled = false;
            TxtMatKhau.Enabled = false;

            BtnThem.Enabled = true;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                TxtID.Text = "";
                TxtTenDangNhap.Text = "";
                TxtMatKhau.Text = "";

                BtnXoa.Enabled = false;
                BtnSua.Enabled = false;
                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;
            }
            // Trạng thái sửa
            else
            {
                BtnXoa.Enabled = true;
                BtnSua.Enabled = true;

                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;

                GvNguoiDung_SelectedIndexChanged(sender, e);
            }

            LblThongBao.Visible = true;
            LblThongBao.Text = "Đã hủy!";
        }

        protected void GvNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = GvNguoiDung.SelectedIndex;

            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy dữ liệu từ bảng NguoiDung
            string sql = "select * from NguoiDung";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Gán dữ liệu dòng được chọn lên Textbox
            TxtID.Text = dt.Rows[selectedRow][0].ToString();
            TxtTenDangNhap.Text = dt.Rows[selectedRow][1].ToString();
            TxtMatKhau.Text = dt.Rows[selectedRow][2].ToString();

            LblThongBao.Visible = false;

            TxtID.Enabled = false;
            TxtTenDangNhap.Enabled = false;
            TxtMatKhau.Enabled = false;

            BtnThem.Enabled = true;

            BtnXoa.Enabled = true;
            BtnSua.Enabled = true;

            BtnLuu.Enabled = false;
            BtnHuy.Enabled = false;
        }
    }
}