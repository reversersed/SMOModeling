using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SMOModeling
{
    public partial class MainForm : Form
    {
        Queue<Client>[] queue = new Queue<Client>[2] { new Queue<Client>(), new Queue<Client>() };
        System.Windows.Forms.Timer ArrivalTimer = new System.Windows.Forms.Timer();

        short clientNumbers = 10;
        Random r = new Random();
        public MainForm()
        {
            InitializeComponent();

            ArrivalTimer.Interval = 2000;
            ArrivalTimer.Tick += ClientArrived;
        }

        private void ClientArrived(object? sender, EventArgs e)
        {
            if (clientNumbers-- <= 0)
                ArrivalTimer.Stop();

            string[] names = new string[] { "Евгений", "Павел", "Владислав", "Владлен", "Сергей", "Дарья", "Ксения", "Роман", "Степан", "Аркадий", "Геннадий", "Максим", "Наташа", "Светлана", "Мария", "Антон", "Андрей", "Василиса", "Георгий" };

            queue.MinBy(q => q.Count).Enqueue(new Client(names[r.Next(names.Length)]));
            this.Invalidate();
        }

        private void SMOStarted(object sender, EventArgs e)
        {
            ArrivalTimer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            WaitingLabel.Text = "Ждут обслуживания:\n\n";
            foreach (Client c in queue[0]?.ToArray())
                WaitingLabel.Text += c.name + "\n";
            foreach (Client c in queue[1].ToArray())
                WaitingLabel.Text += c.name + "\n";
        }
    }
}