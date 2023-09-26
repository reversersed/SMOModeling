using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMOModeling
{
    public delegate void clientManaged(Client client, int cashier);
    public class Cashier
    {
        public clientManaged onClientManaged;
        private int cashierId;
        public Cashier(int  cashierId) 
        {
            this.cashierId = cashierId;
        }
        public void CashierManaging(object? client)
        {
            Thread.Sleep(5000);
            onClientManaged?.Invoke((Client)client, cashierId);
        }
    }
}
