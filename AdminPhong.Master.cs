using System;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing.Admin.QuanLyPhong
{
    public partial class AdminPhong : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //HttpCookie cookie = Request.Cookies["user"];
            //if (cookie == null)
            //{
            //    Response.Redirect("~/Admin/Login.aspx");
            //}
            //if (!IsPostBack)
            //{
            //    lkLogOut.Text = "Đăng xuất" + " " + cookie["name"].ToString();
            //    utilsWeb.bindataNha(drNhaNao, Convert.ToInt32(cookie["nharole"].ToString()));
            //    drNhaNao.SelectedValue = cookie["vitri"].ToString();
            //    Int32 cnrole = Convert.ToInt32(cookie["cnrole"].ToString());
            //    if (utilsWeb.checkQuyenHienChucNang(cnrole,Constant.BIT_AND_CHUC_NANG.QUAN_LY_DAT_PHONG))           
            //        pnQuanLyDatPhong.Visible = true;
            //    else
            //        pnQuanLyDatPhong.Visible = false;
            //    if (utilsWeb.checkQuyenHienChucNang(cnrole, Constant.BIT_AND_CHUC_NANG.HOI_PHONG))
            //        pnHoiPhong.Visible = true;
            //    else
            //        pnHoiPhong.Visible = false;
            //    if (utilsWeb.checkQuyenHienChucNang(cnrole, Constant.BIT_AND_CHUC_NANG.QUAN_LY_ANH_VIDEO))
            //        pnQuanLyAnhViDeo .Visible = true;
            //    else
            //        pnQuanLyAnhViDeo.Visible = false;
            //}
        }



 

        protected void lkLogOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["user"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Admin/Login.aspx");
            }
        }
    }
}