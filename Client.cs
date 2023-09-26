using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOModeling
{
    public class Client
    {
        public string name { get; private set; }
        public Client(string name)
        {
            this.name = name;
        }
    }
}
