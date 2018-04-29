using DataHelper;
using ReportFinance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web;
namespace ReportFinance.ManageUsers.Common
{
    public delegate void onBack();

    public partial class TreeListFunction : System.Web.UI.UserControl
    {
        public List<MenuItemFunction> listTree
        {
            get
            {
                return ViewState["listTree"] as List<MenuItemFunction>;
            }

            set
            {
                ViewState["listTree"] = value;
            }
        }
        public Int32? IdRole
        {
            get
            {
                return ViewState["IdRole"] as Int32?;
            }

            set
            {
                ViewState["IdRole"] = value;
            }
        }
        public event onBack OnBack;
        MenuItemFunctionDH ctlMenu = new MenuItemFunctionDH();
        RolesDH ctlRole = new RolesDH();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (listTree == null)
            {
          
                listTree = ctlMenu.getAllMenu();
            }
            trl.DataSource = listTree;
            trl.DataBind();
        }

        public void Bindata(ICollection<MenuItemFunction> lstMenuItem, Int32 idRole)
        {
            try
            {
                this.IdRole = idRole;
                trl.SettingsSelection.Recursive = true;
                trl.SettingsSelection.AllowSelectAll = true;
                trl.SettingsSelection.Enabled = true;

 
                trl.DataSource = listTree;
                trl.DataBind();
                trl.ExpandAll();
                foreach (TreeListNode item in trl.GetAllNodes())
                {
                    foreach (MenuItemFunction itemMenu in lstMenuItem)
                    {
                        if (itemMenu.Item_ID == item.Key)
                        {
                            item.Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.notifierPage(Page, this.GetType(), Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace, Constant.TIME_ERROR);
            }


        }


        protected void btnBack_Click1(object sender, EventArgs e)
        {
            OnBack();
        }



        protected void ASPxCallback1_Callback(object source, DevExpress.Web.CallbackEventArgs e)
        {
            try
            {
                ASPxCallback cb = source as ASPxCallback;
                List<MenuItemFunction> lstMenu = new List<MenuItemFunction>();
                foreach (TreeListNode item in trl.GetSelectedNodes())
                {
                    MenuItemFunction item1 = new MenuItemFunction();
                    item1.Item_ID = item.Key;
                    lstMenu.Add(item1);
                }
                ctlRole.insertMenuItemRoles(lstMenu, Convert.ToInt32(this.IdRole));
                Utils.notifierCallBack(cb, Constant.NOTIFY_SUCCESS, "Lưu chức năng cho role thành công.");


            }
            catch (Exception ex)
            {
                Utils.notifierPage(Page, this.GetType(), Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace, Constant.TIME_ERROR);
            }
        }
    }
}