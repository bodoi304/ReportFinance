using DataHelper;
using ReportFinance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportFinance.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            UsersDH ctlUser = new UsersDH();
            User objUser = ctlUser.validateLogin(txtUser.Text, Utils.Encrypt(txtPassword.Text));
            if (objUser == null)
            {
                Utils.notifierPage(Page, this.GetType(), Constant.NOTIFY_FAILURE, "Tên đăng nhập hoặc mật khẩu không chính xác.", Constant.TIME_ERROR);
                return;
            }
            List<MenuItemFunction> lstMenuItem = ctlUser.getMenuItem(objUser);
            if (objUser != null)
            {
                if (objUser.LockoutEnabled)
                {
                    Utils.notifierPage(Page, this.GetType(), Constant.NOTIFY_FAILURE, "Tài khoản của bạn đã bị khóa.", Constant.TIME_ERROR);
                    return;
                }
                HttpCookie cookie = Request.Cookies[Constant.USER_COOKIE];
                if (cookie == null)
                {
                    cookie = new HttpCookie(Constant.USER_COOKIE);
                }
                StringBuilder lst = new StringBuilder();
                foreach (MenuItemFunction item in lstMenuItem)
                {
                    lst.Append("," + item.Path);
                }
                if (lstMenuItem.Count == 0)
                {
                    cookie[Constant.FUNCTION_COOKIE] = Utils.Encrypt("<>");
                }
                else
                {
                    cookie[Constant.FUNCTION_COOKIE] = Utils.Encrypt(lst.ToString().Substring(1));
                }
                cookie[Constant.NAME_COOKIE] = Utils.Encrypt(objUser.Id_Login);

                if (chkGiuDN.Checked)
                    cookie.Expires = DateTime.Now.AddDays(30);
                else
                    cookie.Expires = DateTime.Now.AddMinutes(50);


                Response.Cookies.Add(cookie);
                Response.Redirect("~/DashBoard.aspx");

            }
        }
    }
}