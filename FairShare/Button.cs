using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FairShare
{
    public class UIButton
    {
        public string ID { get; set; }
        public bool Selected { get; set; }
    }

    public class UIButtons : List<UIButton>
    {
    }
}