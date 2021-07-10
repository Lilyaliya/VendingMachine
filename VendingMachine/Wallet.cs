using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Wallet : Form
    {
        public Wallet()
        {
            InitializeComponent();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 4;
            button1.FlatAppearance.BorderColor = Color.FromArgb(109, 207, 137);
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 4;
            button2.FlatAppearance.BorderColor = Color.FromArgb(109, 207, 137);
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 4;
            button3.FlatAppearance.BorderColor = Color.FromArgb(109, 207, 137);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Popup;
            button1.FlatAppearance.BorderSize = 0;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Popup;
            button2.FlatAppearance.BorderSize = 0;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.FlatStyle = FlatStyle.Popup;
            button3.FlatAppearance.BorderSize = 0;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.FlatStyle = FlatStyle.Popup;
            button4.FlatAppearance.BorderSize = 0;
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 4;
            button4.FlatAppearance.BorderColor = Color.FromArgb(109, 207, 137);
        }

        public void checkCard(object sender, EventArgs e)
        {
            switch (VendingMachine.card)
            {
                case 0:
                    Program.machine.timer2.Enabled = true;
                    break;
                case 1:
                    Program.machine.button20.Location = new Point(12, 550);
                    Program.machine.button20.Visible = true;
                    break;
                case 2:
                    showCash();
                    break;
                case 3:
                    showMoney();
                    break;
                case 4:
                    showTablet();
                    break;
            }
        }

        private void showTablet()
        {
            Program.machine.button43.Visible = true;
        }

        public void showMoney()
        {
            for (int i = 23; i < 43; i++)
            {
                if (Program.machine.Controls["button" + i.ToString()] != null)
                    Program.machine.Controls["button" + i.ToString()].Visible = true;
            }
        }

        public void showCash()
        {
            Program.machine.button15.Visible = true;
            Program.machine.button16.Visible = true;
            Program.machine.button17.Visible = true;
            Program.machine.button18.Visible = true;
            Program.machine.button19.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VendingMachine.card = 1;
            checkCard(sender, e);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VendingMachine.card = 2;
            checkCard(sender, e);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VendingMachine.card = 3;
            checkCard(sender, e);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VendingMachine.card = 4;
            checkCard(sender, e);
            this.Close();
        }
    }
}
