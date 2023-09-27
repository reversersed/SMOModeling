using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SMOModeling
{
    public partial class MainForm : Form
    {
        const int ArrivingInterval = 1000; // Interval of clients arriving

        Queue<Client> queue = new Queue<Client>();
        System.Windows.Forms.Timer ArrivalTimer = new System.Windows.Forms.Timer();

        short clientNumbers = 10;
        Random r = new Random();

        Cashier Cashier = new Cashier();
        Thread ThreadCashier;
        public MainForm()
        {
            InitializeComponent();

            ArrivalTimer.Interval = ArrivingInterval;
            ArrivalTimer.Tick += ClientArrived;

            Cashier.onClientManaged += OnClientManaged;

            DoneLabel.Text = "Готовы к выдаче:\n\n";

            ThreadCashier = new Thread(new ParameterizedThreadStart(Cashier.CashierManaging));
        }

        private void ClientArrived(object? sender, EventArgs e)
        {
            if (clientNumbers-- <= 0)
                ArrivalTimer.Stop();

            string[] names = new string[] { "Евгений", "Павел", "Владислав", "Владлен", "Сергей", "Дарья", "Ксения", "Роман", "Степан", "Аркадий", "Геннадий", "Максим", "Наташа", "Светлана", "Мария", "Антон", "Андрей", "Василиса", "Георгий" };
            queue.Enqueue(new Client(names[r.Next(names.Length)]));

            if (queue.Count > 0 && ThreadCashier.ThreadState == ThreadState.Unstarted)
                ThreadCashier.Start(queue.Dequeue());
            this.Invalidate();
        }

        private void SMOStarted(object sender, EventArgs e)
        {
            ArrivalTimer.Start();
        }

        private void OnClientManaged(Client client)
        {
            ThreadCashier = new Thread(new ParameterizedThreadStart(Cashier.CashierManaging));
            if (queue.Count > 0)
                ThreadCashier.Start(queue.Dequeue());

            DoneLabel.Invoke(new Action(() => DoneLabel.Text += client.name + "\n"));
            this.Invalidate();
        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            WaitingLabel.Text = "Ждут обслуживания:\n\n";
            foreach (Client c in queue.ToArray())
                WaitingLabel.Text += c.name + "\n";
        }
    }
}