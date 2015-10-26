using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairShare
{
    public class Loan
    {
        public int ID { get; set; }
        public User GetUser { get; set; }
        public User OweUser { get; set; }
        public string Amount { get; set; }
        public string Comment { get; set; }
    }

    public class Loans : List<Loan>
    {
    }
}
