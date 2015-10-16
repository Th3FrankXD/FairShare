using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairShare
{
    class dbManager
    {
        public static Users users = new Users();
        public static void addUser(string nickName, string email, string password)
        {
            users.Add(new User()
            {
                NickName = nickName,
                Email = email,
                Password = password
            });
        }
        public static User loginUser(string eMail, string password)
        {
            foreach (User user in users)
            {
                if (eMail == user.Email && password == user.Password)
                {
                    return user;
                }
            }
            return null;
        }
        public static User getUser(string eMail)
        {
            foreach (User user in users)
            {
                if (eMail == user.Email)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
