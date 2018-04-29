using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHelper
{
    public class MenuItemFunctionDH
    {
        public List<MenuItemFunction> getAllMenu()
        {
            List<MenuItemFunction> menuList;
            using (var context = new ManageUsersEntities())
            {

                menuList = (from s in context.MenuItemFunctions select s).ToList();


            }
            return menuList;
        }
    }
}
