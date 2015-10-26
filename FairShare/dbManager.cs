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
        public static Loans loans = new Loans();
        public static UserLoans userLoans = new UserLoans();
        public static User loggedInUser = new User();

        //////////// USERS ////////////////

        public static void addUser(string nickName, string email, string password)
        {
            users.Add(new User()
            {
                ID = users.Count(),
                NickName = nickName,
                Email = email,
                Password = password
            });
            userLoans.Add(new UserLoan());
        }
        public static User loginUser(string eMail, string password)
        {
            foreach (User user in users)
            {
                if (eMail == user.Email && password == user.Password)
                {
                    loggedInUser = user;
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

        /////////////// LOANS /////////////////

        public static void addLoan(User getUser, User oweUser, string amount, string comment = "")
        {
            loans.Add(new Loan()
            {
                ID = loans.Count(),
                OweUser = oweUser,
                GetUser = getUser,
                Amount = amount,
                Comment = comment
            });
            addUserLoan(getUser.ID, oweUser.ID, loans.Count() - 1);
        }

        ///////////// USERLOANS ///////////////

        public static void addUserLoan(int getUserID, int oweUserID, int loanID)
        {
            userLoans[getUserID].Loans.Add(loanID);
            userLoans[oweUserID].Loans.Add(loanID);
        }
    }
}
