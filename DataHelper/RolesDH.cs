﻿using DataHelper.Object;
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

        public Role getRolesByName(String roleName)
        {
          Role role;
            using (var context = new ManageUsersEntities())
            {

                role = (from s in context.Roles where s.Name == roleName select s).FirstOrDefault();


            }
            return role;
        }

        public Role getRolesByID(Int32 Idrole)
        {
            Role role;
            using (var context = new ManageUsersEntities())
            {

                role = (from s in context.Roles where s.Id == Idrole select s).FirstOrDefault();
                var a = role.MenuItemFunctions;
                var b = role.Users;
            }
            return role;
        }

        public Role getListUserofRole(Int32 Idrole)
        {
            Role role;
            using (var context = new ManageUsersEntities())
            {

                role = (from s in context.Roles where s.Id == Idrole select s).FirstOrDefault();
                var a = role.Users;

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

        public void insertUsersToRole(List<ApplicationUserRolesObj> lstObj )
        {

            using (var context = new ManageUsersEntities())
            {
                foreach (ApplicationUserRolesObj item in lstObj)
                {
                    context.ApplicationUserRoles_InsertItem(item.UserId, item.RoleId);
                }

            }

        }
        public void deleteUsersToRole(List<ApplicationUserRolesObj> lstObj)
        {

            using (var context = new ManageUsersEntities())
            {
                foreach (ApplicationUserRolesObj item in lstObj)
                {
                    context.ApplicationUserRoles_DeleteItem(item.UserId, item.RoleId);
                }

            }

        }
        
    }
}
