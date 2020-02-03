using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SachOnline
{
    public partial class DefaultAdmin : System.Web.UI.Page
    {
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
                    string ten = (string)Session["TenDangNhap"];
                    LblWelcome.Text = "CHÀO MỪNG " + ten.ToUpper() + " ĐẾN VỚI PHẦN QUẢN TRỊ ỨNG DỤNG SÁCH ONLINE <br/> CHỌN CÁC MỤC Ở MENU QUẢN TRỊ ĐỂ THỰC HIỆN CÁC THAO TÁC QUẢN TRỊ";    
                }
            }
        }
    }
}