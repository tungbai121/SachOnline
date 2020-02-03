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
    public partial class QuanLyTheLoai : System.Web.UI.Page
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
                    GetTheLoai();
                }
            }
        }

        public void GetTheLoai()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy dữ liệu từ bảng TheLoai
            string sql = "select * from TheLoai";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            // Gán dữ liệu lên GridView
            GvTheLoai.DataSource = dr;
            GvTheLoai.DataBind();
        }

        protected void BtnThem_Click(object sender, EventArgs e)
        {
            GvTheLoai.SelectedIndex = -1;

            LblThongBao.Visible = false;

            TxtMaLoai.Enabled = false;

            TxtTenLoai.Enabled = true;

            TxtMaLoai.Text = "";
            TxtTenLoai.Text = "";

            TxtTenLoai.Focus();

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

            // Thêm thể loại vào CSDL
            string sql = "insert into TheLoai(TenLoai) Values(N'" + TxtTenLoai.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã thêm thành công!";
                GetTheLoai();
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

            // Xoá thể loại khỏi CSDL
            string sql = "delete TheLoai where MaLoai='" + TxtMaLoai.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã xóa thành công!";

                TxtMaLoai.Enabled = false;
                TxtTenLoai.Enabled = false;

                TxtMaLoai.Text = "";
                TxtTenLoai.Text = "";

                BtnXoa.Enabled = false;
                BtnSua.Enabled = false;
                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;
                BtnCo.Visible = false;
                BtnKhong.Visible = false;

                GetTheLoai();
                GvTheLoai.SelectedIndex = -1;
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

            TxtMaLoai.Enabled = false;

            TxtTenLoai.Enabled = true;

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

            // Sửa thể loại trong CSDL
            string sql = "update TheLoai set TenLoai=N'" + TxtTenLoai.Text + "' where MaLoai='" + TxtMaLoai.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa thành công!";
                GetTheLoai();
            }
            else
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa không thành công!";
            }
        }

        protected void BtnLuu_Click(object sender, EventArgs e)
        {
            TxtMaLoai.Enabled = false;
            TxtTenLoai.Enabled = false;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                Them();

                TxtMaLoai.Text = "";
                TxtTenLoai.Text = "";

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
            TxtMaLoai.Enabled = false;
            TxtTenLoai.Enabled = false;

            BtnThem.Enabled = true;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                TxtMaLoai.Text = "";
                TxtTenLoai.Text = "";

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

                GvTheLoai_SelectedIndexChanged(sender, e);
            }

            LblThongBao.Visible = true;
            LblThongBao.Text = "Đã hủy!";
        }

        protected void GvTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblThongBao.Visible = false;

            TxtMaLoai.Enabled = false;
            TxtTenLoai.Enabled = false;

            BtnThem.Enabled = true;

            BtnXoa.Enabled = true;
            BtnSua.Enabled = true;

            BtnLuu.Enabled = false;
            BtnHuy.Enabled = false;

            int selectedRow = GvTheLoai.SelectedIndex;

            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy dữ liệu từ bảng TheLoai
            string sql = "select * from TheLoai";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Gán dữ liệu dòng được chọn lên Textbox
            TxtMaLoai.Text = dt.Rows[selectedRow][0].ToString();
            TxtTenLoai.Text = dt.Rows[selectedRow][1].ToString();
        }
    }
}