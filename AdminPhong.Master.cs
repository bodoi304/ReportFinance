
using Common;
using DataHelper;
using ReportFinance.Common;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Housing.Admin.QuanLyPhong
{
    public partial class AdminPhong : System.Web.UI.MasterPage
    {
        public String nameUser;
        protected void Page_Load(object sender, EventArgs e)
        {


            HttpCookie cookie = Request.Cookies[Constant.USER_COOKIE];
            if (cookie == null)
            {
                Response.Redirect("~/Login/Login.aspx");
            }
            else
            {
                nameUser = Utils.Decrypt(cookie[Constant.NAME_COOKIE]);
                if (nameUser.Equals("admin"))
                {
                    return;
                }
                String urlPath = Request.Url.AbsolutePath;
                if (urlPath.Contains("DashBoard"))
                {
                    if (Request.QueryString["ban"] != null)
                    {
                        Utils.notifierPage(Page, this.GetType(), Constant.NOTIFY_FAILURE, "Bạn không có quyền sử dụng chức năng này.", Constant.TIME_ERROR);
                    }

                    return;
                }
                String lstFunction = Utils.Decrypt(cookie[Constant.FUNCTION_COOKIE]);
                String[] str = lstFunction.Split(',');
                Boolean coQuyen = false;
                foreach (String item in str)
                {
                    if (urlPath.Contains(item.Trim()))
                    {
                        coQuyen = true;
                        break;
                    }
                }
                if (!coQuyen)
                {
                    Response.Redirect("~/DashBoard.aspx?ban=?");

                }


            }
        }


        protected void lkLogOut_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[Constant.USER_COOKIE];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
                Response.Redirect("~/Login/Login.aspx");
            }
        }

        protected void PopupDoiMatKhau_WindowCallback(object source, DevExpress.Web.PopupWindowCallbackArgs e)
        {
            try
            {
                //Xu ly callback popup doi mat khau
                String strerror = "";
                String result = CustomValidate.checkControlEmpty(pnPopupChangePassword, new String[] { "txtMatKhauCu", "txtMatKhauMoi", "txtXacNhanMatKhauMoi" });
                if (result != null)
                {
                    PopupDoiMatKhau.JSProperties["cpUpdateStatus"] = Constant.NOTIFY_FAILURE;
                    PopupDoiMatKhau.JSProperties["cpMess"] = result;
                    return;
                }
                HttpCookie cookie = Request.Cookies[Constant.USER_COOKIE];
                if (cookie == null)
                {
                    Response.Redirect("~/Login/Login.aspx");
                }
                UsersDH ctlUser = new UsersDH();
                String UserLog = Utils.Decrypt(cookie[Constant.NAME_COOKIE]);
                User objUser = ctlUser.validateLogin(UserLog, Utils.Encrypt(txtMatKhauCu.Text));
                if (objUser == null)
                {
                    PopupDoiMatKhau.JSProperties["cpUpdateStatus"] = Constant.NOTIFY_FAILURE;
                    PopupDoiMatKhau.JSProperties["cpMess"] = "Mật khẩu cũ bạn nhập không chính xác.";
                    return;
                }
                if (!txtMatKhauMoi.Text.Equals(txtXacNhanMatKhauMoi.Text))
                {
                    PopupDoiMatKhau.JSProperties["cpUpdateStatus"] = Constant.NOTIFY_FAILURE;
                    PopupDoiMatKhau.JSProperties["cpMess"] = "Xác nhận mật khẩu không chính xác.";
                    return;

                }
                ctlUser.updateUserPassword(UserLog, Utils.Encrypt(txtMatKhauMoi.Text));
                PopupDoiMatKhau.JSProperties["cpUpdateStatus"] = Constant.NOTIFY_SUCCESS;
                PopupDoiMatKhau.JSProperties["cpMess"] = String.Format("Cập nhập mật khẩu cho tài khoản [{0}] thành công.", UserLog);
                return;
            }
            catch (Exception ex)
            {
                PopupDoiMatKhau.JSProperties["cpUpdateStatus"] = Constant.NOTIFY_FAILURE;
                PopupDoiMatKhau.JSProperties["cpMess"] = ex.Message + " " + ex.StackTrace ;
            }
         
        }
    }
}