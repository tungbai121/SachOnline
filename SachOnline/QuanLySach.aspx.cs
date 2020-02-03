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
    public partial class QuanLySach : System.Web.UI.Page
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
                    GetSach();
                }
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

            // Lấy dữ liệu từ bảng Sach
            string sql = "select * from Sach";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            // Gán dữ liệu lên GridView
            GvSach.DataSource = dr;
            GvSach.DataBind();
        }

        protected void BtnUploadAnh_Click(object sender, EventArgs e)
        {
            string imgName = UplAnh.FileName;

            UplAnh.SaveAs(MapPath("~/Images/" + imgName));

            ImgSach.ImageUrl = "~/Images/" + imgName;

            TxtTenFileAnh.Text = imgName;
        }

        protected void BtnThem_Click(object sender, EventArgs e)
        {
            GvSach.SelectedIndex = -1;

            LblThongBao.Visible = false;

            TxtMaSach.Enabled = false;

            TxtTenSach.Enabled = true;
            TxtTacGia.Enabled = true;
            TxtGia.Enabled = true;
            TxtSoLuong.Enabled = true;
            TxtMoTa.Enabled = true;
            TxtTenFileAnh.Enabled = true;
            TxtMaLoai.Enabled = true;

            UplAnh.Enabled = true;
            BtnUploadAnh.Enabled = true;

            TxtMaSach.Text = "";
            TxtTenSach.Text = "";
            TxtTacGia.Text = "";
            TxtGia.Text = "";
            TxtSoLuong.Text = "";
            TxtMoTa.Text = "";
            TxtTenFileAnh.Text = "";
            TxtMaLoai.Text = "";

            ImgSach.ImageUrl = "";

            TxtTenSach.Focus();

            BtnLuu.Enabled = true;
            BtnHuy.Enabled = true;

            BtnThem.Enabled = false;
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;

            // Đánh dấu trạng thái thêm
            ViewState["flag"] = true;
        }

        public void Them()
        {
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Thêm sách vào CSDL
            string sql = "insert into Sach(TenSach,TacGia,Gia,SoLuong,MoTa,TenFileAnh,MaLoai) Values(N'" + TxtTenSach.Text + "',N'" + TxtTacGia.Text + "','" + TxtGia.Text + "','" + TxtSoLuong.Text + "',N'" + TxtMoTa.Text + "',N'" + TxtTenFileAnh.Text + "','" + TxtMaLoai.Text + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã thêm thành công!";
                GetSach();
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

            // Xoá sách khỏi CSDL
            string sql = "delete Sach where MaSach='" + TxtMaSach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã xóa thành công!";

                TxtMaSach.Enabled = false;
                TxtTenSach.Enabled = false;
                TxtTacGia.Enabled = false;
                TxtGia.Enabled = false;
                TxtSoLuong.Enabled = false;
                TxtMoTa.Enabled = false;
                TxtTenFileAnh.Enabled = false;
                TxtMaLoai.Enabled = false;

                UplAnh.Enabled = false;
                BtnUploadAnh.Enabled = false;

                TxtMaSach.Text = "";
                TxtTenSach.Text = "";
                TxtTacGia.Text = "";
                TxtGia.Text = "";
                TxtSoLuong.Text = "";
                TxtMoTa.Text = "";
                TxtTenFileAnh.Text = "";
                TxtMaLoai.Text = "";

                ImgSach.ImageUrl = "";

                BtnXoa.Enabled = false;
                BtnSua.Enabled = false;
                BtnLuu.Enabled = false;
                BtnHuy.Enabled = false;
                BtnCo.Visible = false;
                BtnKhong.Visible = false;

                GetSach();
                GvSach.SelectedIndex = -1;
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

            TxtMaSach.Enabled = false;

            TxtTenSach.Enabled = true;
            TxtTacGia.Enabled = true;
            TxtGia.Enabled = true;
            TxtSoLuong.Enabled = true;
            TxtMoTa.Enabled = true;
            TxtTenFileAnh.Enabled = true;
            TxtMaLoai.Enabled = true;

            UplAnh.Enabled = true;
            BtnUploadAnh.Enabled = true;

            TxtTenSach.Focus();

            BtnLuu.Enabled = true;
            BtnHuy.Enabled = true;

            BtnThem.Enabled = false;
            BtnXoa.Enabled = false;
            BtnSua.Enabled = false;

            // Đánh dấu trạng thái sửa
            ViewState["flag"] = false;
        }

        public void Sua()
        {   
            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Sửa sách trong CSDL
            string sql = "Update Sach set TenSach=N'" + TxtTenSach.Text + "',TacGia=N'" + TxtTacGia.Text + "',Gia='" + TxtGia.Text + "',SoLuong='" + TxtSoLuong.Text + "',MoTa=N'" + TxtMoTa.Text + "',TenFileAnh=N'" + TxtTenFileAnh.Text + "',MaLoai='" + TxtMaLoai.Text + "' where MaSach='" + TxtMaSach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa thành công!";
                GetSach();
            }
            else
            {
                LblThongBao.Visible = true;
                LblThongBao.Text = "Bạn đã sửa không thành công!";
            }
        }

        protected void BtnLuu_Click(object sender, EventArgs e)
        {
            TxtMaSach.Enabled = false;
            TxtTenSach.Enabled = false;
            TxtTacGia.Enabled = false;
            TxtGia.Enabled = false;
            TxtSoLuong.Enabled = false;
            TxtMoTa.Enabled = false;
            TxtTenFileAnh.Enabled = false;
            TxtMaLoai.Enabled = false;

            UplAnh.Enabled = false;
            BtnUploadAnh.Enabled = false;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                Them();

                TxtMaSach.Text = "";
                TxtTenSach.Text = "";
                TxtTacGia.Text = "";
                TxtGia.Text = "";
                TxtSoLuong.Text = "";
                TxtMoTa.Text = "";
                TxtTenFileAnh.Text = "";
                TxtMaLoai.Text = "";

                ImgSach.ImageUrl = "";

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
            TxtMaSach.Enabled = false;
            TxtTenSach.Enabled = false;
            TxtTacGia.Enabled = false;
            TxtGia.Enabled = false;
            TxtSoLuong.Enabled = false;
            TxtMoTa.Enabled = false;
            TxtMaLoai.Enabled = false;
            TxtTenFileAnh.Enabled = false;

            UplAnh.Enabled = false;
            BtnUploadAnh.Enabled = false;

            BtnThem.Enabled = true;

            // Trạng thái thêm
            if ((bool)ViewState["flag"] == true)
            {
                TxtMaSach.Text = "";
                TxtTenSach.Text = "";
                TxtTacGia.Text = "";
                TxtGia.Text = "";
                TxtSoLuong.Text = "";
                TxtMoTa.Text = "";
                TxtTenFileAnh.Text = "";
                TxtMaLoai.Text = "";

                ImgSach.ImageUrl = "";

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

                GvSach_SelectedIndexChanged(sender, e);
            }

            LblThongBao.Visible = true;
            LblThongBao.Text = "Đã hủy!";
        }

        protected void GvSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRow = GvSach.SelectedIndex;

            // Tạo kết nối đến CSDL
            SqlConnection conn = new SqlConnection(connStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Lấy dữ liệu từ bảng Sach
            string sql = "select * from Sach";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Gán dữ liệu lên GridView
            TxtMaSach.Text = dt.Rows[selectedRow][0].ToString();
            TxtTenSach.Text = dt.Rows[selectedRow][1].ToString();
            TxtTacGia.Text = dt.Rows[selectedRow][2].ToString();
            TxtGia.Text = dt.Rows[selectedRow][3].ToString();
            TxtSoLuong.Text = dt.Rows[selectedRow][4].ToString();
            TxtMoTa.Text = dt.Rows[selectedRow][5].ToString();
            ImgSach.ImageUrl = "~/Images/" + dt.Rows[selectedRow][6].ToString();
            TxtMaLoai.Text = dt.Rows[selectedRow][7].ToString();
            TxtTenFileAnh.Text = dt.Rows[selectedRow][6].ToString();

            TxtMaSach.Enabled = false;
            TxtTenSach.Enabled = false;
            TxtTacGia.Enabled = false;
            TxtGia.Enabled = false;
            TxtSoLuong.Enabled = false;
            TxtMoTa.Enabled = false;
            TxtMaLoai.Enabled = false;
            TxtTenFileAnh.Enabled = false;

            UplAnh.Enabled = false;
            BtnUploadAnh.Enabled = false;

            LblThongBao.Visible = false;

            BtnThem.Enabled = true;

            BtnXoa.Enabled = true;
            BtnSua.Enabled = true;

            BtnLuu.Enabled = false;
            BtnHuy.Enabled = false;
        }
    }
}