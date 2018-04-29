using DevExpress.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportFinance.Common
{
    public class Utils
    {
        public static ASPxGridView setDisplayGridView(ASPxGridView grd)
        {

            grd.SettingsText.CommandCancel = "Thoát";
            grd.SettingsText.CommandDelete = "Xóa";
            grd.SettingsText.CommandEdit = "Sửa";
            grd.SettingsText.CommandNew = "Thêm";
            grd.SettingsCommandButton.NewButton.Image.Url = "/images/icon/add-icon.png";
            grd.SettingsCommandButton.NewButton.Image.Height = 18;
            grd.SettingsCommandButton.NewButton.Styles.Style.CssClass = "CommanNewGrid";
            grd.SettingsText.CommandUpdate = "Cập Nhập";
            grd.SettingsText.CommandBatchEditUpdate = "Lưu Cập Nhập";
            grd.SettingsText.CommandRecover = "Phục Hồi";
            grd.SettingsText.CommandBatchEditCancel = "Không Lưu Cập Nhập";
            grd.Styles.Cell.CssClass = "CellGrid";
            grd.Styles.Header.CssClass = "HeaderGrid";
            grd.Styles.Header.ForeColor = Color.White;
            grd.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.HideDataCellsWindowLimit;
            grd.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 800;
            grd.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = true;
            grd.SettingsAdaptivity.AdaptiveDetailColumnCount = 1;
            grd.EditFormLayoutProperties.SettingsAdaptivity.AdaptivityMode = FormLayoutAdaptivityMode.SingleColumnWindowLimit;
            grd.EditFormLayoutProperties.SettingsAdaptivity.SwitchToSingleColumnAtWindowInnerWidth = 800;
            grd.SettingsLoadingPanel.Text = "Đang Tải";
            grd.SettingsBehavior.AllowSort = true;
            grd.SettingsPager.PageSize = 20;
            grd.SettingsPager.Summary.Text = "Trang số {0} của {1} trang ({2} bản ghi)";
            grd.Settings.ShowFilterRow = true;
            grd.Styles.Header.Wrap =  DevExpress.Utils.DefaultBoolean.True ;

            return grd;
        }

        public static void notifierGrid(ASPxGridView grd_DSRole, String status, String content)
        {

            grd_DSRole.JSProperties["cpUpdateStatus"] = status;
            grd_DSRole.JSProperties["cpMess"] = content;

        }

        public static void notifierCallBack(ASPxCallback cb, String status, String content)
        {

            cb.JSProperties["cpUpdateStatus"] = status;
            cb.JSProperties["cpMess"] = content;

        }

        public static void notifierListErrorGrid(ASPxGridView grd_DSRole, String status, List<Error_Obj> content)
        {
            String a = Utils.ListObject_2_Json<Error_Obj>(content);
            grd_DSRole.JSProperties["cpUpdateStatus"] = status;
            grd_DSRole.JSProperties["cpMess"] = a;

        }

        public static void notifierListClearGrid(ASPxGridView grd_DSRole, String status)
        {

            grd_DSRole.JSProperties["cpClear"] = status;


        }

        public static void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }

        public static String ListObject_2_Json<T>(List<T> lstInput) where T : class
        {

            return JsonConvert.SerializeObject(lstInput);

        }


        public static void notifierPage(Page page, Type type, String status, String content, Int32 Time)
        {
            if (status == Constant.NOTIFY_SUCCESS)
            {
                String script = "";
                script += "  window.onload = function () { ";
                script += " new PNotify({";
                script += "      text: '" + content + "' ,";
                script += "       delay: " + Time + " ,";
                script += "       hide: true,";
                script += "       type: 'info',";
                script += "       width: '50%'";

                script += "    });";
                script += "  }";

                page.ClientScript.RegisterStartupScript(type, "myScript", script, true);
            }
            else
            {
                String script = "";
                script += "  window.onload = function () { ";
                script += " new PNotify({";
                script += "      text: '" + content.Replace("\r", "").Replace("\n", "") + "' ,";
                script += "       delay: " + Time + " ,";
                script += "       hide: true,";
                script += "       type: 'error',";
                script += "       width: '50%'";

                script += "    });";
                script += "  }";
                page.ClientScript.RegisterStartupScript(type, "myScript", script, true);
            }


        }

        public static string Encrypt(string clearText)
        {
            string EncryptionKey = Constant.PASSWORD_ENCRYTION ;
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = Constant.PASSWORD_ENCRYTION;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static T setView2Object<T>(T obj,Panel panelObj)
        {
            Type type = obj.GetType();
            foreach (Control control in panelObj.Controls)
            {
                foreach (var item in type.GetProperties())
                {
                    if (control.ID == item.Name)
                    {
                        Type type1 = control.GetType();
                        if (type1 == typeof(ASPxTextBox))
                        {
                            item.SetValue(obj, (control as ASPxTextBox).Text);
                        }

                    }
                }

            }
            return obj;
        }

    }
}