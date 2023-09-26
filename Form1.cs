using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SMOModeling
{
    public partial class MainForm : Form
    {
        const int ArrivingInterval = 2000; // Interval of clients arriving

        Queue<Client>[] queue = new Queue<Client>[2] { new Queue<Client>(), new Queue<Client>() };
        System.Windows.Forms.Timer ArrivalTimer = new System.Windows.Forms.Timer();

        short clientNumbers = 10;
        Random r = new Random();

        Cashier[] Cashiers = new Cashier[2] { new Cashier(0), new Cashier(1) };
        Thread[] ThreadCashier;
        public MainForm()
        {
            InitializeComponent();

            ArrivalTimer.Interval = ArrivingInterval;
            ArrivalTimer.Tick += ClientArrived;

            Cashiers[0].onClientManaged += OnClientManaged;
            Cashiers[1].onClientManaged += OnClientManaged;

            DoneLabel.Text = "Готовы к выдаче:\n\n";

            ThreadCashier = new Thread[2] { new Thread(new ParameterizedThreadStart(Cashiers[0].CashierManaging)), new Thread(new ParameterizedThreadStart(Cashiers[1].CashierManaging)) };
        }

        private void ClientArrived(object? sender, EventArgs e)
        {
            if (clientNumbers-- <= 0)
                ArrivalTimer.Stop();

            string[] names = new string[] { "Евгений", "Павел", "Владислав", "Владлен", "Сергей", "Дарья", "Ксения", "Роман", "Степан", "Аркадий", "Геннадий", "Максим", "Наташа", "Светлана", "Мария", "Антон", "Андрей", "Василиса", "Георгий" };

            queue?.MinBy(q => q.Count)?.Enqueue(new Client(names[r.Next(names.Length)]));

            for(int i = 0; i < 2; i++)
                if (queue[i].Count > 0 && ThreadCashier[i].ThreadState == ThreadState.Unstarted)
                    ThreadCashier[i].Start(queue[i].Dequeue());
            this.Invalidate();
        }

        private void SMOStarted(object sender, EventArgs e)
        {
            ArrivalTimer.Start();
        }

        private void OnClientManaged(Client client, int cashierid)
        {
            ThreadCashier[cashierid] = new Thread(new ParameterizedThreadStart(Cashiers[cashierid].CashierManaging));
            if (queue[cashierid].Count > 0)
                ThreadCashier[cashierid].Start(queue[cashierid].Dequeue());

            DoneLabel.Invoke(new Action(() => DoneLabel.Text += client.name+"\n"));
            this.Invalidate();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            WaitingLabel.Text = "Ждут обслуживания:\n\n";
            foreach (Client c in queue[0].ToArray())
                WaitingLabel.Text += c.name + "\n";
            foreach (Client c in queue[1].ToArray())
                WaitingLabel.Text += c.name + "\n";
        }
    }
}