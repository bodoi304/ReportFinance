using DevExpress.Web;
using ReportFinance.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Common
{
   public class CustomValidate
    {
       public static String checkControlEmpty(Panel panel, String[] controls)
       {
           List<Error_Obj> lstError = new List<Error_Obj>();

           foreach (String item in controls)
           {
               ASPxTextBox txtObj = panel.FindControl(item) as ASPxTextBox;
               if (String.IsNullOrEmpty(txtObj.Text))
               {
                   lstError.Add(new Error_Obj { error = "[" + txtObj.NullText  + "] không được để trống." });
               }
           }

           if (lstError.Count > 0)
           {
               
               return Utils.ListObject_2_Json<Error_Obj>(lstError);
           }
           return null;
       }
     
    }
}
