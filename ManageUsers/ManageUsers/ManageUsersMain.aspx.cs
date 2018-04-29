using DataHelper;
using DevExpress.Web;
using ReportFinance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportFinance.ManageUsers.ManageUsers
{
    public partial class ManageUsersMain : System.Web.UI.Page
    {
        UsersDH ctlUser = new UsersDH();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grd_DSUsers = Utils.setDisplayGridView(grd_DSUsers);
                Bindata();
            }
        }
        public void Bindata()
        {

            grd_DSUsers.DataSource = ctlUser.getAllUsers();
            grd_DSUsers.DataBind();
        }

        protected void grd_DSUsers_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Int32 idUser = Convert.ToInt32(e.Keys[grd_DSUsers.KeyFieldName]);
                ctlUser.deleteUsers(idUser);
                Bindata();
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_SUCCESS, "Bạn đã xóa thành công cho người sử dụng có ID [" + idUser.ToString() + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }

        }

        protected void grd_DSUsers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Int32 idUser = Convert.ToInt32(e.Keys[grd_DSUsers.KeyFieldName]);
                Panel pnLayData = grd_DSUsers.FindEditFormTemplateControl("pnLayData") as Panel;
                User user = new User();
                Utils.setView2Object<User>(user, pnLayData);
                ctlUser.updateUsers(idUser,user);
                Bindata();
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_SUCCESS, "Bạn đã cập nhập thành công tài khoản [" + user.Id_Login + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }



        }

        protected void grd_DSUsers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {

                e.Cancel = true;
                Panel pnLayData = grd_DSUsers.FindEditFormTemplateControl("pnLayData") as Panel;
                User user = new User();
                Utils.setView2Object<User>(user, pnLayData);
                user.LockoutEnabled = false;
                user.Password = Utils.Encrypt(user.Password);
                getFirstLastName(user);
                ctlUser.insertUsers(user);
                Bindata();
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_SUCCESS, "Bạn đã thêm thành công tài khoản [" + user.Id_Login + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSUsers, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }
        }


        public void getFirstLastName(User user)
        {
            string fullName = user.UserName;
            string[] names = fullName.Split(' ');
            if (names.Length >= 2)
            {
                user.FirstName = names.First();
                user.LastName = names.Last();
            }
        }

        protected void grd_DSUsers_PageIndexChanged(object sender, EventArgs e)
        {
            Bindata();
        }



        protected void grd_DSUsers_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
        {
            Bindata();
        }

        protected void grd_DSUsers_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            Utils.notifierListClearGrid(grd_DSUsers, Constant.NOTIFY_CLEAR);
            List<Error_Obj> lstError = new List<Error_Obj>();
            ASPxTextBox txtId_Login = grd_DSUsers.FindEditFormTemplateControl("Id_Login") as ASPxTextBox;
            ASPxTextBox txtPassword = grd_DSUsers.FindEditFormTemplateControl("Password") as ASPxTextBox;
            ASPxTextBox txtPasswordConfirm = grd_DSUsers.FindEditFormTemplateControl("PasswordConfirm") as ASPxTextBox;
            if (String.IsNullOrEmpty(txtId_Login.Text))
            {
                lstError.Add(new Error_Obj { error = "[Tên đăng nhập] không được để trống." });
            }

            User user = ctlUser.getUsersByIDLogin(txtId_Login.Text);
            if (user != null && grd_DSUsers.IsNewRowEditing)
            {
                lstError.Add(new Error_Obj { error = "Tên đăng nhập đã tồn tại." });
            }
            if (String.IsNullOrEmpty(txtPassword.Text) && grd_DSUsers .IsNewRowEditing )
            {
                lstError.Add(new Error_Obj { error = "[Mật khẩu] không được để trống." });
            }
            if (!txtPassword.Text.Equals(txtPasswordConfirm.Text ))
            {
                lstError.Add(new Error_Obj { error = "[Xác nhận mật khẩu] không chính xác." });
            }
            if (lstError.Count > 0)
            {
                e.Errors[grd_DSUsers.Columns[0]] = "error";
                Utils.notifierListErrorGrid(grd_DSUsers, Constant.NOTIFY_FAILURE, lstError);
            }

        }

        protected void grd_DSUsers_BeforeColumnSortingGrouping(object sender, ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            Bindata(); 
        }

        protected void grd_DSUsers_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            ImageButton Link = (ImageButton)e.CommandSource;
            if (Link.CommandName == "cmdKhoa")
            {
                String[] key = e.KeyValue.ToString().Split('|');
                Int32 IdUser = Convert.ToInt32(key[0]);

                ctlUser.updateUserLock(IdUser);

                Bindata();
            }
        }
    }
}