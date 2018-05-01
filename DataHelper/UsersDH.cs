
using ReportFinance.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace DataHelper
{
    public class UsersDH
    {
        public List<User> getAllUsers()
        {
            List<User> userList;
            using (var context = new ManageUsersEntities())
            {

                userList = (from s in context.Users select s).ToList();


            }
            return userList;
        }

        public List<Users_SelectUsersNoRole_Result> SelectUsersNoRole(Int32 idRoles)
        {
            List<Users_SelectUsersNoRole_Result> userList;
            using (var context = new ManageUsersEntities())
            {
                userList = context.Users_SelectUsersNoRole(idRoles).ToList<Users_SelectUsersNoRole_Result>();
            }
            return userList;
        }

        public List<User> getUsersByIdLogInLike(String idLogin)
        {
            List<User> userList;
            using (var context = new ManageUsersEntities())
            {

                userList = (from s in context.Users where s.Id_Login.Contains(idLogin) select s).ToList();


            }
            return userList;
        }

        public User getUsersByID(Int64 Iduser)
        {
            User user;
            using (var context = new ManageUsersEntities())
            {

                user = (from s in context.Users where s.Id == Iduser select s).FirstOrDefault();
                var a = user.Roles;
            }
            return user;
        }

        public User validateLogin(String IdLogIn, String passWord)
        {
            User user;
            using (var context = new ManageUsersEntities())
            {

                user = (from s in context.Users where s.Id_Login == IdLogIn && s.Password == passWord select s).FirstOrDefault();
                if (user == null)
                {
                    return null;
                }
                var a = user.Roles;
                 foreach (Role item in user.Roles )
                 {
                     var b = item.MenuItemFunctions;
                 }
            }
            return user;
        }

        public List<MenuItemFunction> getMenuItem(User user)
        {
            List<MenuItemFunction> lstAll = new List<MenuItemFunction>();
            using (var context = new ManageUsersEntities())
            {
               
                foreach (Role item in user.Roles )
                {
                    lstAll.AddRange(item.MenuItemFunctions);
                }
               
            }
            return lstAll.Distinct<MenuItemFunction>().ToList<MenuItemFunction>();
        }


        public User getUsersByIDLogin(String IdLogIn)
        {
            User user;
            using (var context = new ManageUsersEntities())
            {
                IdLogIn = IdLogIn.Trim();
                user = (from s in context.Users where s.Id_Login == IdLogIn select s).FirstOrDefault();

            }
            return user;
        }

        public void deleteUsers(Int64 Iduser)
        {

            using (var context = new ManageUsersEntities())
            {

                User user = (from s in context.Users where s.Id == Iduser select s).Single();
                context.Users.Remove(user);

                context.SaveChanges();

            }

        }

        public void updateUsers(Int64 Iduser, User user)
        {

            using (var context = new ManageUsersEntities())
            {

                User userDb = (from s in context.Users where s.Id == Iduser select s).Single();
                userDb.Id_Login = user.Id_Login;
                userDb.Email = user.Email;
                userDb.PhoneNumber = user.PhoneNumber;
                userDb.UserName = user.UserName;
                userDb.Department = user.Department;
                userDb.Position = user.Position;
                if (!String.IsNullOrEmpty(user.Password))
                {
                    userDb.Password = Utils.Encrypt(user.Password);
                }

                context.SaveChanges();

            }

        }

        public void updateUserLock(Int32 Iduser)
        {

            using (var context = new ManageUsersEntities())
            {

                User user = (from s in context.Users where s.Id == Iduser select s).Single();
                user.LockoutEnabled = !user.LockoutEnabled;

                context.SaveChanges();

            }

        }

        public void updateUserPassword(String idLogIn,String password)
        {

            using (var context = new ManageUsersEntities())
            {

                User user = (from s in context.Users where s.Id_Login == idLogIn select s).Single();
                user.Password = password;

                context.SaveChanges();

            }

        }

        public void insertUsers(User user)
        {

            using (var context = new ManageUsersEntities())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

        }


    }
}
