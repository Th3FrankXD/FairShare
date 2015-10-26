using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairShare
{
    public class User
    {
        public int ID { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Users:List<User>
    {
    }
}
