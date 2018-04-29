using DataHelper;
using DataHelper.Object;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportFinance.ManageUsers.ManageRules
{
    public partial class ManageRulesMain : System.Web.UI.Page
    {
        RolesDH ctlRole = new RolesDH();
        UsersDH ctlUser = new UsersDH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindataListRoles();
                BindataListUser();

            }
        }

        public void BindataListRoles()
        {

            List<Role> lstRole = ctlRole.getAllRoles();
            cbRoles.TextField = "Name";
            cbRoles.ValueField = "Id";
            cbRoles.DataSource = lstRole;
            cbRoles.DataBind();
            cbRoles.SelectedIndex = 0;
        }

        public void BindataListUser()
        {
         
            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
         
            ICollection<User> lstUserOfRoles = BindataListUserOfRole(Convert.ToInt32(cbRoles.SelectedItem.Value));
            List<Users_SelectUsersNoRole_Result> lstUsers = ctlUser.SelectUsersNoRole(idRole);
            foreach (User item in lstUserOfRoles)
            {
                lstUsers.Remove(lstUsers.Where(x => x.Id == item.Id).FirstOrDefault());
            }
            
            lbUser.TextField = "Id_Login";
            lbUser.ValueField = "Id";
            lbUser.DataSource = lstUsers;
            lbUser.DataBind();
            txtUser.Text = "";
            txtUserOfRole.Text = "";
        }

        public ICollection<User> BindataListUserOfRole(Int32 IdRole)
        {
            Role role = ctlRole.getListUserofRole(IdRole);
            lbUserOfRole.TextField = "Id_Login";
            lbUserOfRole.ValueField = "Id";
            lbUserOfRole.DataSource = role.Users;
            lbUserOfRole.DataBind();
            return role.Users;
        }


        protected void cbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindataListUser();
        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {

            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
            List<ApplicationUserRolesObj> lstAppUserRole = new List<ApplicationUserRolesObj>();
            foreach (ListEditItem item in lbUser.Items)
            {
                ApplicationUserRolesObj objAppUserRole = new ApplicationUserRolesObj();
                objAppUserRole.RoleId = idRole;
                objAppUserRole.UserId = Convert.ToInt64(item.Value);
                lstAppUserRole.Add(objAppUserRole);
            }
            ctlRole.insertUsersToRole(lstAppUserRole);
            BindataListUser();
        }

        protected void btnAddOne_Click(object sender, EventArgs e)
        {
            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
            List<ApplicationUserRolesObj> lstAppUserRole = new List<ApplicationUserRolesObj>();
            foreach (ListEditItem item in lbUser.SelectedItems)
            {
                ApplicationUserRolesObj objAppUserRole = new ApplicationUserRolesObj();
                objAppUserRole.RoleId = idRole;
                objAppUserRole.UserId = Convert.ToInt64(item.Value);
                lstAppUserRole.Add(objAppUserRole);
            }
            ctlRole.insertUsersToRole(lstAppUserRole);
            BindataListUser();
        }

        protected void btnRevOne_Click(object sender, EventArgs e)
        {
            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
            List<ApplicationUserRolesObj> lstAppUserRole = new List<ApplicationUserRolesObj>();
            foreach (ListEditItem item in lbUserOfRole.SelectedItems)
            {
                ApplicationUserRolesObj objAppUserRole = new ApplicationUserRolesObj();
                objAppUserRole.RoleId = idRole;
                objAppUserRole.UserId = Convert.ToInt64(item.Value);
                lstAppUserRole.Add(objAppUserRole);
            }
            ctlRole.deleteUsersToRole(lstAppUserRole);
            BindataListUser();
        }

        protected void btnRevAll_Click(object sender, EventArgs e)
        {
            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
            List<ApplicationUserRolesObj> lstAppUserRole = new List<ApplicationUserRolesObj>();
            var c = lbUserOfRole.DataSource;
            foreach (ListEditItem item in lbUserOfRole.Items)
            {
                ApplicationUserRolesObj objAppUserRole = new ApplicationUserRolesObj();
                objAppUserRole.RoleId = idRole;
                objAppUserRole.UserId = Convert.ToInt64(item.Value);
                lstAppUserRole.Add(objAppUserRole);
            }
            ctlRole.deleteUsersToRole(lstAppUserRole);
            BindataListUser();
        }

        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            ICollection<User> lstUserOfRoles = BindataListUserOfRole(Convert.ToInt32(cbRoles.SelectedItem.Value));
            List<User> lstUsers = ctlUser.getUsersByIdLogInLike(txtUser.Text);
            foreach (User item in lstUserOfRoles)
            {
                lstUsers.Remove(lstUsers.Where(x => x.Id == item.Id).FirstOrDefault());
            }
            lbUser.TextField = "Id_Login";
            lbUser.ValueField = "Id";
            lbUser.DataSource = lstUsers;
            lbUser.DataBind();
        }

        protected void txtUserOfRole_TextChanged(object sender, EventArgs e)
        {
            Int32 idRole = Convert.ToInt32(cbRoles.SelectedItem.Value);
            Role role = ctlRole.getListUserofRole(idRole);
            var lstUser = from a in role.Users where a.Id_Login.Contains(txtUserOfRole.Text) select a;
            lbUserOfRole.TextField = "Id_Login";
            lbUserOfRole.ValueField = "Id";
            lbUserOfRole.DataSource = lstUser;
            lbUserOfRole.DataBind();
        }


    }
}