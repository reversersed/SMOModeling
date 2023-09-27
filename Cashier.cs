using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOModeling
{
    public delegate void clientManaged(Client client);
    public class Cashier
    {
        public clientManaged onClientManaged = null;
        private Random r = new Random();

        public void CashierManaging(object client)
        {
            Thread.Sleep(r.Next(2000, 5000));
            onClientManaged?.Invoke((Client)client);
        }
    }
}
