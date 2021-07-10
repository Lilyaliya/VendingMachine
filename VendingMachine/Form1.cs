using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VendingMachine
{
    public partial class VendingMachine : Form
    {
        public static int time = 6;
        public static int t2 = 50;
        public static int card = 0;
        private static Point coords = new Point();
        private static Point startPoint = new Point(650, 457);
        private object currObj = null;
        private bool trigger = true;
        private int def = 270;
        private PictureBox img = null;
        private Bitmap bitmap = null;
        private int diver = 0;
        private static int tag = 0;
        public static List<PictureBox> nullcell = new List<PictureBox>();
        public VendingMachine()
        {
            InitializeComponent();
            button1.Hide();
            button13.Hide();
            button14.Hide();
            initBtn();
            hideCash();
            this.MouseMove += new MouseEventHandler(mouseEvent);
            this.MouseClick += new MouseEventHandler(mouseClick);
        }

        private void initBtn()
        {
            System.Drawing.Drawing2D.GraphicsPath myPath =
                new System.Drawing.Drawing2D.GraphicsPath();
            myPath.AddEllipse(0, 0, button44.Width, button44.Height);
            Region myRegion = new Region(myPath);
            button44.Region = myRegion;
        }

        public struct Assoc
        {
            public byte     num;
            public float    cost;
            public int count;
        }

        public List<Assoc> elems = new List<Assoc>()
        {
            new Assoc{ num = 20, cost = 60, count = 5},
            new Assoc{ num = 22, cost = 45, count = 5},
            new Assoc{ num = 24, cost = 80, count = 5},
            new Assoc{ num = 26, cost = 60, count = 5},
            new Assoc{ num = 28, cost = 70, count = 5},
            new Assoc{ num = 30, cost = 35, count = 5},
            new Assoc{ num = 31, cost = 45, count = 5},
            new Assoc{ num = 32, cost = 55, count = 5},
            new Assoc{ num = 33, cost = 35, count = 5},
            new Assoc{ num = 34, cost = 25, count = 5},
            new Assoc{ num = 35, cost = 60, count = 5},
            new Assoc{ num = 36, cost = 55, count = 2},
            new Assoc{ num = 37, cost = 60, count = 5},
            new Assoc{ num = 38, cost = 60, count = 5},
            new Assoc{ num = 39, cost = 35, count = 5},
            new Assoc{ num = 40, cost = 60, count = 5},
            new Assoc{ num = 41, cost = 65, count = 5},
            new Assoc{ num = 42, cost = 80, count = 5},
            new Assoc{ num = 43, cost = 90, count = 5},
            new Assoc{ num = 44, cost = 85, count = 5},
            new Assoc{ num = 45, cost = 120, count = 5},
            new Assoc{ num = 46, cost = 100, count = 5},
            new Assoc{ num = 47, cost = 65, count = 5},
            new Assoc{ num = 48, cost = 70, count = 5},
            new Assoc{ num = 49, cost = 50, count = 5},
        };

        Dictionary<string, byte> images = new Dictionary<string, byte>
        {
            ["pictureBox1"] = 20,
            ["pictureBox2"] = 22,
            ["pictureBox3"] = 24,
            ["pictureBox4"] = 26,
            ["pictureBox5"] = 28,
            ["pictureBox6"] = 30,
            ["pictureBox7"] = 31,
            ["pictureBox8"] = 32,
            ["pictureBox9"] = 33,
            ["pictureBox10"] = 34,
            ["pictureBox12"] = 35,
            ["pictureBox13"] = 36,
            ["pictureBox14"] = 37,
            ["pictureBox15"] = 38,
            ["pictureBox16"] = 39,
            ["pictureBox17"] = 40,
            ["pictureBox18"] = 41,
            ["pictureBox19"] = 42,
            ["pictureBox20"] = 43,
            ["pictureBox21"] = 44,
            ["pictureBox22"] = 45,
            ["pictureBox23"] = 46,
            ["pictureBox24"] = 47,
            ["pictureBox25"] = 48,
            ["pictureBox26"] = 49,
        };

        public enum Images: byte 
        {
            pictureBox1 = 20,
            pictureBox2 = 22,
            pictureBox3 = 24,
            pictureBox4 = 26,
            pictureBox5 = 28,
            pictureBox6 = 30,
            pictureBox7 = 31,
            pictureBox8 = 32,
            pictureBox9 = 33,
            pictureBox10 = 34,
        }

        public bool check_correct(object sender, EventArgs e)
        {
            if (label2.Text.Length == 3)
            {
                button_1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button11.Enabled = false;
                int num = Convert.ToInt32(String.Concat(label2.Text[1], label2.Text[2]));
                var elem = elems.Find(x => x.num == num);
                if (elem.cost > 0 && elem.count > 0)
                {
                    label4.Text = elem.cost.ToString();
                    label4.Visible = true;
                    timer1.Enabled = true;
                    button13.Show();
                    timer2.Enabled = true;
                    return true;
                }
                else
                {
                    timer3.Enabled = true;
                }
            }
            return false;
        }

        

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void button_1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "1";
            check_correct(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "2";
            check_correct(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "3";
            check_correct(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "6";
            check_correct(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "5";
            check_correct(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "4";
            check_correct(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "7";
            check_correct(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "8";
            check_correct(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "9";
            check_correct(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label2.Visible = true;
            label2.Text = label2.Text + "0";
            check_correct(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (timer9.Enabled)
                timer9.Enabled = false;
            if (label4.Text != "NULL" && label1.Text != "00.00")
            {
                if (checkBalance() != 0)
                {
                    pictureBox11.Show();
                    label1.Visible = false;
                    timer1.Enabled = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label6.Text = "TAKE\nTHE\nCHANGE";
                    timer14.Enabled = true;
                    return;
                } 
            }
            label2.Text = "#";
            button43.Visible = false;
            button22.Visible = false;
            card = 0;
            if (button12.Enabled == false)
                button12.Enabled = true;
            label6.Text = label2.Text;
            label6.Visible = false;
            button1.Hide();
            button1.Enabled = false;
            button_1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button11.Enabled = true;
            button44.Visible = false;
            hideCash();
            hideMoney();
            button20.Hide();
            button21.Enabled = false;
            timer1.Enabled = false;
            label1.Text = "00.00";
            label1.Visible = false;
            label3.Visible = false;
            timer7.Enabled = false;
            label4.Text = "--.--";
            label4.Show();
            label2.Hide();
            button13.Hide();
            trigger = true;
        }

        private int checkBalance()
        {
            if (label2.Text[0] == '#')
            {
                string l0 = "" + label1.Text[0];
                if (label1.Text[1] != '.')
                    l0 += label1.Text[1];
                if (label1.Text[2] != '.' && label1.Text[1] != '.')
                    l0 += label1.Text[2];
                return (Convert.ToInt32(l0));
            } 
            string l1 = label2.Text[8] + "";
            if (label2.Text.Length > 9)
                l1 += label2.Text[9];
            if (label2.Text.Length > 10)
                l1 += label2.Text[9];
            return (Convert.ToInt32(l1));
        }

        private void hideCash()
        {
            button15.Hide();
            button16.Hide();
            button17.Hide();
            button18.Hide();
            button19.Hide();
        }

        private void hideMoney()
        {
            for (int i = 23; i < 43; i++)
            {
                if (this.Controls["button" + i.ToString()] != null)
                    this.Controls["button" + i.ToString()].Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Visible)
                label1.Hide();
            else
                label1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            Form wallet = new Wallet();
            wallet.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (button13.FlatAppearance.BorderSize > 0)
                button13.FlatAppearance.BorderSize = 0;
            else
                button13.FlatAppearance.BorderSize = 2;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                label4.Text = "NULL";
                if (label4.Visible)
                    label4.Hide();
                else
                    label4.Show();
            }
            else
            {
                time = 6;
                timer3.Enabled = false;
                button12_Click(sender, e);
            } 
        }

        private void button17_MouseMove(object sender, MouseEventArgs e)
        {
            button17.FlatAppearance.BorderSize = 2;
        }

        private void button17_MouseLeave(object sender, EventArgs e)
        {
            button17.FlatAppearance.BorderSize = 0;
        }

        private void button16_MouseLeave(object sender, EventArgs e)
        {
            button16.FlatAppearance.BorderSize = 0;
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button15_MouseMove(object sender, MouseEventArgs e)
        {
            button15.FlatAppearance.BorderSize = 2;
        }

        private void button16_MouseMove(object sender, MouseEventArgs e)
        {
            button16.FlatAppearance.BorderSize = 2;
        }

        private void button15_MouseLeave(object sender, EventArgs e)
        {
            button15.FlatAppearance.BorderSize = 0;
        }

        private void button18_MouseLeave(object sender, EventArgs e)
        {
            button18.FlatAppearance.BorderSize = 0;
        }

        private void button18_MouseMove(object sender, MouseEventArgs e)
        {
            button18.FlatAppearance.BorderSize = 2;
        }

        private void button19_MouseLeave(object sender, EventArgs e)
        {
            button19.FlatAppearance.BorderSize = 0;
        }

        private void button19_MouseMove(object sender, MouseEventArgs e)
        {
            button19.FlatAppearance.BorderSize = 2;
        }

        

        private void button20_MouseLeave(object sender, EventArgs e)
        {
            button20.FlatAppearance.BorderSize = 0;
        }

        private void VendingMachine_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (trigger)
            {
                button21.Enabled = true;
                timer4.Enabled = true;
                currObj = sender;
            }
            else
            {
                currObj = null;
            }
            trigger = !trigger;
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
           
        }

        
        private void mouseEvent(object sender, MouseEventArgs e)
        {
            if (currObj != null)
            { 
                currObj.GetType().GetProperty("BackColor").SetValue(currObj, Color.Transparent);
            }   
            if (currObj != null)
                currObj.GetType().GetProperty("Location").SetValue(currObj, new Point(Cursor.Position.X - 370, Cursor.Position.Y - 100));
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time % 2 == 0)
                    button21.FlatAppearance.BorderSize = 1;
                else
                    button21.FlatAppearance.BorderSize = 0;
                time--;
            }
            else
            {
                time = 6;
                timer4.Enabled = false;
            }
        }

        private void button21_MouseMove(object sender, MouseEventArgs e)
        {
            if (button21.Enabled)
                button21.FlatAppearance.BorderSize = 1;
        }

        private void button21_MouseLeave(object sender, EventArgs e)
        {
            if (button21.Enabled)
                button21.FlatAppearance.BorderSize = 0;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            currObj = null;
            trigger = !trigger;
            timer5.Enabled = true;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (t2 > 0)
            {
                def += 5;
                Point x = new Point(719, def);
                button20.Location = x;
                t2--;
            }
            else
            {
                def = 270;
                t2 = 50;
                button20.Location = new Point(12, 550);
                timer5.Enabled = false;
                timer13.Enabled = true;
                return;
            }
        }

        private void showDisplay()
        {
            if (Properties.Settings.Default.cardCash - Convert.ToInt32(label4.Text) >= 0)
            {
                Properties.Settings.Default.cardCash -= Convert.ToInt32(label4.Text);
                label1.Text = label4.Text + ".00";
                timer1.Enabled = false;
                label1.Visible = true;
                label4.Visible = false;
                button12.Enabled = false;
                string num = String.Concat(label2.Text[1], label2.Text[2]);
                string name = images.First(x => x.Value == Convert.ToByte(num)).Key; //finds name of control by its value in dictionary
                var elem = elems.Find(x => x.num == Convert.ToInt32(num));
                int i = elems.FindIndex(x => x.num == Convert.ToInt32(num));
                elem.count--;
                elems[i] = elem; //refuses a count of product
                img = (PictureBox)this.Controls[name]; // Get a pictureBox by its number
                if (elems[i].count == 0)
                    showNull(img);
                img.Visible = true;
                coords = img.Location;
                label2.Text = "BALANCE " + Properties.Settings.Default.cardCash.ToString();
                Properties.Settings.Default.Save();
                if (350 - img.Location.X < 0)
                    diver = -2;
                else
                    diver = 2;
                timer7.Enabled = true;
                timer8.Enabled = true;
            }
            else
            {
                label1.Text = "00.00";
                label1.Visible = false;
                label2.Visible = false;
                label4.Visible = false;
                timer1.Enabled = false;
                label6.Text = "INSUFFICIENT\nFUNDS";
                timer6.Enabled = true;
            }

        }

        private void showNull(PictureBox img)
        {
            nullcell.Add(new PictureBox()
            {
                Enabled = true,
                Visible = true,
                BackColor = Color.Black,
                Location = img.Location,
                Width = img.Size.Width,
                Height = img.Size.Height,
            });
            this.Controls.Add(nullcell.Last<PictureBox>()); // adds a control on form
        }
        private void button20_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time % 2 == 0)
                    label6.Visible = true;
                else
                    label6.Visible = false;
                time--;
            }
            else
            {
                time = 6;
                timer6.Enabled = false;
                label1.Visible = true;
                label2.Visible = true;
                label4.Visible = true;
                timer1.Enabled = true;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            if (label3.Visible)
                label3.Visible = false;
            else
                label3.Visible = true;
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            if (img != null && (img.Location.Y < 100 || img.Location.Y % 400 > 100) &&
                (img.Location.Y + img.Size.Height) < 540)
            {
                img.Location = new Point(img.Location.X, img.Location.Y + 8);
            }
            else
            {
                img.Visible = false;
                img.Location = coords;
                coords = new Point();
                button1.Enabled = true;
                button1.Show();
                if (card == 1)
                    label1.Text = "00.00";
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label6.Text = "TAKE\nTHE\nPRODUCT";
                timer7.Enabled = false;
                timer8.Enabled = false;
                timer9.Enabled = true;
            }
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            if (label6.Visible)
                label6.Hide();
            else
                label6.Show();
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time % 2 == 0)
                    button14.FlatAppearance.BorderSize = 1;
                else
                    button14.FlatAppearance.BorderSize = 0;
                time--;
            }
            else
            {
                time = 6;
                timer10.Enabled = false;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (trigger)
            {
                button14.Enabled = true;
                button14.Visible = true;
                timer10.Enabled = true;
                currObj = sender;
            }
            else
            {
                currObj = null;
            }
            trigger = !trigger;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (currObj == null)
                return;
            trigger = true;
            currObj.GetType().GetProperty("Location").SetValue(currObj, startPoint);
            tag = Convert.ToInt32(currObj.GetType().GetProperty("Tag").GetValue(currObj));
            timer11.Enabled = true;
        }

        private void timer11_Tick(object sender, EventArgs e)
        {
            if (t2 > 0)
            {
                startPoint.Y -= 5;
                currObj.GetType().GetProperty("Height").SetValue(currObj, 
                    Convert.ToInt32(currObj.GetType().GetProperty("Height").GetValue(currObj)) - 5);
                t2--;
            }
            else
            {
                startPoint = new Point(650, 457);
                t2 = 50;
                this.Controls.Remove(this.Controls[currObj.GetType().Name]);
                timer11.Enabled = false;
                timer13.Enabled = true;
                return;
            }
        }

        private void showDisplay2()
        {
            int change;
            string l1 = "" + label1.Text[0];
            if (label1.Text[1] != '.')
                l1 += label1.Text[1];
            if (label1.Text[2] != '.' && label1.Text[1] != '.')
                l1 += label1.Text[2];
            if (tag - Convert.ToInt32(label4.Text) + Convert.ToInt32(l1) >= 0)
            {
                change = tag - Convert.ToInt32(label4.Text) + Convert.ToInt32(l1);
                label1.Text = label4.Text + ".00";
                timer1.Enabled = false;
                label1.Visible = true;
                label4.Visible = false;
                button12.Enabled = false;
                string num = String.Concat(label2.Text[1], label2.Text[2]);
                string name = images.First(x => x.Value == Convert.ToByte(num)).Key;
                var elem = elems.Find(x => x.num == Convert.ToInt32(num));
                int i = elems.FindIndex(x => x.num == Convert.ToInt32(num));
                elem.count--;
                elems[i] = elem;
                img = (PictureBox)this.Controls[name]; // Get a pictureBox by its number
                if (elems[i].count == 0)
                    showNull(img);
                img.Visible = true;
                coords = img.Location;
                label2.Text = "BALANCE " + change.ToString();
                if (350 - img.Location.X < 0)
                    diver = -2;
                else
                    diver = 2;
                timer7.Enabled = true;
                timer8.Enabled = true;
            }
            else
            {
                change = Convert.ToInt32(l1);
                tag += change;
                label1.Text = tag.ToString() + ".00";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (trigger)
            {
                button22.Enabled = true;
                button22.Visible = true;
                timer12.Enabled = true;
                currObj = sender;
            }
            else
            {
                currObj = null;
            }
            trigger = !trigger;
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time % 2 == 0)
                    button22.FlatAppearance.BorderSize = 1;
                else
                    button22.FlatAppearance.BorderSize = 0;
                time--;
            }
            else
            {
                time = 6;
                timer12.Enabled = false;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        { 
            if (currObj == null)
                return;
            trigger = !trigger;
            tag = Convert.ToInt32(currObj.GetType().GetProperty("Tag").GetValue(currObj));
            deleteCoin();
            timer13.Enabled = true;
        }

        private void deleteCoin()
        {
            if (currObj == null)
                return;
            string n = currObj.GetType().GetProperty("Name").GetValue(currObj).ToString();
            this.Controls.Remove(this.Controls[n]);
        }

        private void timer13_Tick(object sender, EventArgs e)
        {
            if (label5.Text.Length < 24)
                label5.Text += ',';
            else
            {
                label5.Text = "";
                timer13.Enabled = false;
                if (card == 1)
                    showDisplay();
                else if (card == 4)
                    makeDiv();
                else
                    showDisplay2();
            }    
        }

        private void makeDiv()
        {
            int newCost = Convert.ToInt32(Convert.ToInt32(label4.Text) * 0.8);
            label4.Text = newCost.ToString();
        }

        private void button14_MouseMove(object sender, MouseEventArgs e)
        {
            if (button14.Enabled)
                button14.FlatAppearance.BorderSize = 1;
        }

        private void button14_MouseLeave(object sender, EventArgs e)
        {
            if (button14.Enabled)
                button14.FlatAppearance.BorderSize = 0;
        }

        private void button22_MouseMove(object sender, MouseEventArgs e)
        {
            if (button22.Enabled)
                button22.FlatAppearance.BorderSize = 1;
        }

        private void button22_MouseLeave(object sender, EventArgs e)
        {
            if (button22.Enabled)
                button22.FlatAppearance.BorderSize = 0;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            timer14.Enabled = false;
            label1.Text = "00.00";
            label6.Text = "#";
            button12_Click(sender, e);
            pictureBox11.Visible = false;
        }

        private void timer14_Tick(object sender, EventArgs e)
        {
            if (label6.Visible)
                label6.Visible = false;
            else
                label6.Visible = true;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            if (trigger)
            {
                button44.Enabled = true;
                button44.Visible = true;
                timer15.Enabled = true;
                currObj = sender;
            }
            else
            {
                currObj = null;
            }
            trigger = !trigger;
        }

        private void timer15_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                if (time % 2 == 0)
                    button44.FlatAppearance.BorderSize = 4;
                else
                    button44.FlatAppearance.BorderSize = 0;
                time--;
            }
            else
            {
                time = 6;
                timer15.Enabled = false;
            }
        }

        private void button44_MouseMove(object sender, MouseEventArgs e)
        {
            if (button44.Enabled)
                button44.FlatAppearance.BorderSize = 4;
        }

        private void button44_MouseLeave(object sender, EventArgs e)
        {
            if (button44.Enabled)
                button44.FlatAppearance.BorderSize = 0;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            trigger = true;
            if (currObj != null)
            {
                tag = 0;
                currObj.GetType().GetProperty("Visible").SetValue(currObj, false);
            }
            if (currObj != null)
                this.Controls.Remove(this.Controls[currObj.GetType().Name]);
            timer13.Enabled = true;
        }
    }
}
