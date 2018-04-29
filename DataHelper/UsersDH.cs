﻿
using ReportFinance.Common;
using System;
using System.Collections.Generic;
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

        public User getUsersByID(Int64 Iduser)
        {
            User user;
            using (var context = new ManageUsersEntities())
            {

                user = (from s in context.Users where s.Id == Iduser select s).FirstOrDefault();

            }
            return user;
        }

        public User validateLogin(String IdLogIn, String passWord)
        {
            User user;
            using (var context = new ManageUsersEntities())
            {

                user = (from s in context.Users where s.Id_Login == IdLogIn && s.Password == passWord select s).FirstOrDefault();

            }
            return user;
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