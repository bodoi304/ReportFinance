using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataHelper
{
    public class RolesDH
    {
        public List<Role> getAllRoles()
        {
            List<Role> roleList;
            using (var context = new ManageUsersEntities())
            {

                roleList = (from s in context.Roles select s).ToList();


            }
            return roleList;
        }

        public Role getRolesByID(Int32 Idrole)
        {
            Role role;
            using (var context = new ManageUsersEntities())
            {

                role = (from s in context.Roles where s.Id == Idrole select s).FirstOrDefault();
                var a = role.MenuItemFunctions;

            }
            return role;
        }
        public void deleteRoles(Int32 IDrole)
        {

            using (var context = new ManageUsersEntities())
            {

                Role roleItem = (from s in context.Roles where s.Id == IDrole select s).Single();
                context.Roles.Remove(roleItem);

                context.SaveChanges();

            }

        }

        public void updateRoles(Int32 IDrole, String Name, String moTa)
        {

            using (var context = new ManageUsersEntities())
            {

                Role roleItem = (from s in context.Roles where s.Id == IDrole select s).Single();
                roleItem.Name = Name;
                roleItem.Description = moTa;

                context.SaveChanges();

            }

        }

        public void insertRoles(String Name, String moTa)
        {

            using (var context = new ManageUsersEntities())
            {
                Role itemRole = new Role();
                itemRole.Name = Name;
                itemRole.Description = moTa;
                itemRole.DateCreate  = DateTime.Now;
                context.Roles.Add(itemRole);
                context.SaveChanges();

            }

        }

        public void insertMenuItemRoles(List<MenuItemFunction> lstMenu, Int32 IDrole)
        {

            using (var context = new ManageUsersEntities())
            {
                context.MenuItemRoles_DeleteByRoleID(IDrole);
                foreach (MenuItemFunction item in lstMenu)
                {
                    context.MenuItemRoles_InsertItem (item.Item_ID  ,IDrole);
                }
               
            }

        }
        
    }
}
