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

namespace ReportFinance.ManageUsers.ManageRoles
{
    public partial class ManageRolesMain : System.Web.UI.Page
    {
        RolesDH ctlRole = new RolesDH();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            TreeListFunction1.OnBack += () =>
            {
                mtView.SetActiveView(vwRole);
            };
            if (!IsPostBack)
            {

                mtView.SetActiveView(vwRole);
                grd_DSRole = Utils.setDisplayGridView(grd_DSRole);
                BindataThemNhanh();
            }
        }
        public void BindataThemNhanh()
        {

            grd_DSRole.DataSource = ctlRole.getAllRoles();
            grd_DSRole.DataBind();
        }

        protected void grd_DSRole_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Int32 idRoles = Convert.ToInt32(e.Keys[grd_DSRole.KeyFieldName]);
                ctlRole.deleteRoles(idRoles);
                BindataThemNhanh();
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_SUCCESS, "Bạn đã xóa thành công cho Role có ID [" + idRoles.ToString() + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }

        }

        protected void grd_DSRole_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                Int32 idRoles = Convert.ToInt32(e.Keys[grd_DSRole.KeyFieldName]);
                ASPxMemo txtNote = grd_DSRole.FindEditFormTemplateControl("txtNote") as ASPxMemo;
                ASPxTextBox txtName = grd_DSRole.FindEditFormTemplateControl("txtName") as ASPxTextBox;
                ctlRole.updateRoles(idRoles, txtName.Text, txtNote.Text);
                BindataThemNhanh();
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_SUCCESS, "Bạn đã cập nhập thành công cho Role có ID [" + idRoles.ToString() + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }



        }

        protected void grd_DSRole_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                e.Cancel = true;
                ASPxMemo txtNote = grd_DSRole.FindEditFormTemplateControl("txtNote") as ASPxMemo;
                ASPxTextBox txtName = grd_DSRole.FindEditFormTemplateControl("txtName") as ASPxTextBox;
                ctlRole.insertRoles(txtName.Text, txtNote.Text);
                BindataThemNhanh();
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_SUCCESS, "Bạn đã thêm thành công Role có [" + txtName.Text + "]");
            }
            catch (Exception ex)
            {
                Utils.notifierGrid(grd_DSRole, Constant.NOTIFY_FAILURE, ex.Message + " " + ex.StackTrace);
            }
        }

        protected void grd_DSRole_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            LinkButton Link = (LinkButton)e.CommandSource;
            if (Link.CommandName == "cmdRole")
            {
                String[] key = e.KeyValue.ToString().Split('|');
                Int32 IdRole = Convert.ToInt32(key[0]);
                mtView.SetActiveView(vwQuyen);
                Role role = ctlRole.getRolesByID(IdRole);

                TreeListFunction1.Bindata(role.MenuItemFunctions, IdRole);
            }
        }

        protected void grd_DSRole_PageIndexChanged(object sender, EventArgs e)
        {
            BindataThemNhanh();
        }



        protected void grd_DSRole_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
        {
            BindataThemNhanh();
        }

        protected void grd_DSRole_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            Utils.notifierListClearGrid(grd_DSRole, Constant.NOTIFY_CLEAR);
            List<Error_Obj >  lstError = new List<Error_Obj > ();
            ASPxTextBox txtName = grd_DSRole.FindEditFormTemplateControl("txtName") as ASPxTextBox;
            if (String.IsNullOrEmpty (txtName.Text ))
            {
                lstError.Add(new Error_Obj {error = "Tên role không được để trống." });
            }
            if (lstError .Count >0)
            {
                e.Errors[grd_DSRole.Columns[0]] = "error";
                Utils.notifierListErrorGrid(grd_DSRole, Constant.NOTIFY_FAILURE, lstError);
            }
           
        }

        protected void grd_DSRole_BeforeColumnSortingGrouping(object sender, ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            BindataThemNhanh();
        }
    }
}