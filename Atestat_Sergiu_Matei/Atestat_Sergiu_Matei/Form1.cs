using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Media;
using System.IO;

namespace Atestat_Sergiu_Matei
{
    public partial class Form1 : Form
    {
        Button[,] b;
        Random R = new Random();
        StreamReader f = new StreamReader("date.txt");
        string x, y;
        static ArrayList q = new ArrayList();
        int scor = 0,ok2048=0;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
            x=f.ReadLine();
            y=f.ReadLine();
            label5.Text = x;
            label6.Text = y;
        }
        public void mutare()
        {
            int i, j,p;
            q.Clear();
            for ( i = 0; i < 4; i++)
            {
                
                for ( j = 0; j < 4; j++)
                {
                    if (b[i, j].Text == "")
                    {
                        q.Add(i * 4 + j + 1);
                    }
                }
            }
            if (q.Count > 0)
            {
                
                int c = int.Parse(q[R.Next(0, q.Count - 1)].ToString());
                int i0 = (c - 1) / 4;
                int j0 = (c - 1) - i0 * 4;
                int z = R.Next(1, 10);
                if (z <= 6)
                {
                    b[i0, j0].Text = "2";
                }
                else
                {
                    b[i0, j0].Text = "4";
                }
            }
        }
        public void Up()
        {
            bool l = false;
            for (int i = 0; i < 4; i++)
            {
                int aux = 0;
                for (int j = 0; j < 4; j++)
                {

                    for (int k = j + 1; k < 4; k++)
                    {
                        if (b[i, k].Text != "")
                        {
                            break;
                        }
                    }
                    if (b[i, j].Text == "")
                    {
                        aux++;
                    }
                    else
                    {
                        for (int m = j - 1; m >= 0; m--)
                        {
                            if (b[i, m].Text == "")
                            {
                                l = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool kp = true;

                            for (int k = j + 1; k < 4; k++)
                            {
                                if (b[i, k].Text != "")
                                {

                                    if (b[i, j].Text == b[i, k].Text)
                                    {
                                        l = true;
                                        kp = false;
                                        b[i, j].Text = (int.Parse(b[i, j].Text) * 2).ToString();
                                        try
                                        {
                                            scor += (int.Parse(b[i, j].Text)) ;
                                        }
                                        catch { };
                                        if (aux != 0)
                                        {
                                            b[i, j - aux].Text = b[i, j].Text;
                                            b[i, j].Text = "";

                                        }
                                        b[i, k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (kp == true && aux != 0)
                            {
                                b[i, j - aux].Text = b[i, j].Text;
                                b[i, j].Text = "";

                            }
                        }
                        else
                        {
                            if (aux != 0)
                            {
                                b[i, j - aux].Text = b[i, j].Text;
                                b[i, j].Text = "";

                            }
                        }


                    }
                }
            }
            if (l == true)
            {
                mutare();
            }
        }
        public void Left()
        {
            bool a = false;
            for (int i = 0; i < 4; i++)
            {
                int aux = 0;
                for (int j = 0; j < 4; j++)
                {
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (b[k, i].Text != "")
                        {
                            break;
                        }
                    }
                    if (b[j, i].Text == "")
                    {
                        aux++;
                    }
                    else
                    {
                        for (int m = j; m >= 0; m--)
                        {
                            if (b[m, i].Text == "")
                            {
                                a = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool kp = true;

                            for (int k = j + 1; k < 4; k++)
                            {
                                if (b[k, i].Text != "")
                                {
                                    if (b[j, i].Text == b[k, i].Text)
                                    {
                                        a = true;
                                        kp = false;
                                        b[j, i].Text = (int.Parse(b[j, i].Text) * 2).ToString();
                                        try
                                        {
                                            scor += (int.Parse(b[i, j].Text)) ;
                                        }
                                        catch { };
                                        if (aux != 0)
                                        {
                                            b[j - aux, i].Text = b[j, i].Text;
                                            b[j, i].Text = "";

                                        }
                                        b[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (kp == true && aux != 0)
                            {
                                b[j - aux, i].Text = b[j, i].Text;
                                b[j, i].Text = "";

                            }
                        }
                        else
                        {
                            if (aux != 0)
                            {
                                b[j - aux, i].Text = b[j, i].Text;
                                b[j, i].Text = "";

                            }
                        }


                    }
                }
            }
            if (a == true)
            {
                mutare();
            }
        }
        public void Right()
        {
            bool l = false;
            for (int i = 0; i < 4; i++)
            {
                int aux = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (b[k, i].Text != "")
                        {
                            break;
                        }
                    }
                    if (b[j, i].Text == "")
                    {
                        aux++;
                    }
                    else
                    {
                        for (int m = j + 1; m <= 3; m++)
                        {
                            if (b[m, i].Text == "")
                            {
                                l = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool kp = true;

                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (b[k, i].Text != "")
                                {
                                    if (b[j, i].Text == b[k, i].Text)
                                    {
                                        l = true;
                                        kp = false; 
                                        b[j, i].Text = (int.Parse(b[j, i].Text) * 2).ToString();
                                        try
                                        {
                                            scor += (int.Parse(b[i, j].Text)) ;
                                        }
                                        catch { };
                                        if (aux != 0)
                                        {
                                            b[j + aux, i].Text = b[j, i].Text;
                                            b[j, i].Text = "";

                                        }
                                        b[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (kp == true && aux != 0)
                            {
                                b[j + aux, i].Text = b[j, i].Text;
                                b[j, i].Text = "";

                            }
                        }
                        else
                        {
                            if (aux != 0)
                            {
                                b[j + aux, i].Text = b[j, i].Text;
                                b[j, i].Text = "";

                            }
                        }


                    }
                }
            }
            if (l == true)
            {
                mutare();
            }
        }
        public void Down()
        {
            bool l = false;
            for (int i = 0; i < 4; i++)
            {
                int ok = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (b[i, k].Text != "")
                        { 
                            break;
                        }
                    }
                    if (b[i, j].Text == "")
                    {
                        ok++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (b[i, m].Text == "")
                            {
                                l = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool kp = true;

                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (b[i, k].Text != "")
                                {


                                    if (b[i, j].Text == b[i, k].Text)
                                    {
                                        l = true;
                                        kp = false;
                                        b[i, j].Text = (int.Parse(b[i, j].Text) * 2).ToString();
                                        try
                                        {
                                            scor += (int.Parse(b[i, j].Text)) ;
                                        }
                                        catch { }
                                        if (ok != 0)
                                        {
                                            b[i, j + ok].Text = b[i, j].Text;
                                            b[i, j].Text = "";

                                        }
                                        b[i, k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (kp == true && ok != 0)
                            {
                                b[i, j + ok].Text = b[i, j].Text;
                                b[i, j].Text = "";

                            }
                        }
                        else
                        {
                            if (ok != 0)
                            {
                                b[i, j + ok].Text = b[i, j].Text;
                                b[i, j].Text = "";

                            }
                        }
                    }
                }

            }
            if (l == true)
            {
                mutare();
            }
        }
        public bool verif()
        {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (b[i, j].Text == "")
                        {
                            return false;
                        }
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (b[i, j].Text != "")
                            {
                                if (b[i, j].Text == b[i, k].Text)
                                {
                                    return false;
                                }
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (b[j, i].Text == "")
                        {
                            return false;
                        }
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (b[k, i].Text != "")
                            {
                                if (b[j, i].Text == b[k, i].Text)
                                {
                                    return false;
                                }
                                break;
                            }
                        }
                    }
                }
                return true;
        }
        private void Form_KeyPress(object sender, KeyEventArgs e)
        {
            int k, l;
            Random R = new Random();
            l = R.Next(0, 4);
            k = R.Next(0, 4);
            if (verif() == false)
            {
                if (e.KeyCode == Keys.D)
                {
                    Right();
                }
                if (e.KeyCode == Keys.A)
                {
                    Left();
                }
                if (e.KeyCode == Keys.S)
                {
                    Down();
                }
                if (e.KeyCode == Keys.W)
                {
                    Up();
                }
                label3.Text = Convert.ToString(scor);
            }
            else
            {
                MessageBox.Show("Joc Terminat! Nici o mutare posibila.");
                f.Close();
                if (scor > int.Parse(x))
                {
                    StreamWriter g = new StreamWriter("date.txt");
                    g.WriteLine(Convert.ToString(scor));
                    g.WriteLine(label4.Text);
                    g.Close();
                    Application.Exit();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            KeyDown += new KeyEventHandler(Form_KeyPress);
            if (textBox1.Text == "")
                MessageBox.Show("Introduceți numele!");
            else
            {
                label1.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label7.Visible = false;
                label2.Visible = true;
                label6.Visible = true;
                label5.Visible = true;
                label4.Text = textBox1.Text;
                label3.Text = Convert.ToString(scor);
                textBox1.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
                button2.Visible = true;
                int i, j, dx, dy, k, l;
                Random R = new Random();
                k = R.Next(0, 4);
                l = R.Next(0, 4);
                FontFamily fontFamily = new FontFamily("Broadway");
                Font font = new Font(
                   fontFamily,
                   30,
                   FontStyle.Bold,
                   GraphicsUnit.Pixel);
                b = new Button[4, 4];
                dx = 50;
                dy = 50;
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        b[i, j] = new Button();
                        b[i, j].Size = new System.Drawing.Size(100, 100);
                        b[i, j].Location = new System.Drawing.Point(dx + 100 * i, dy + 100 * j);
                        this.Controls.Add(b[i, j]);
                        b[i, j].Font = font;
                        b[i, j].Enabled = false;
                        b[i, j].BackColor = Color.Coral;
                    }
                }
                b[l, k].Text = "2";  
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i, j, l, k;
            Random R = new Random();
            l = R.Next(0, 4);
            k = R.Next(0, 4);
            for (i = 0; i <= 3; i++)
                for (j = 0; j <= 3; j++)
                    b[i, j].Text = "";
            l = R.Next(0, 4);
            k = R.Next(0, 4);
            b[k, l].Text = "2";
            scor = 0;
            label3.Text = Convert.ToString(scor);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cum se joacă:Cu ajutorul Butoanelor WASD mutați pătrățelele.Când două pătrățele cu același număr se întâlnesc , aceste numere se înmulțesc. Scopul este de a ajunge la 2048");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int i, j, l, k;
            Random R = new Random();
            l = R.Next(0, 4);
            k = R.Next(0, 4);
            for (i = 0; i <= 3; i++)
                for (j = 0; j <= 3; j++)
                    b[i, j].Text = "";
            l = R.Next(0, 4);
            k = R.Next(0, 4);
            b[k, l].Text = "2";
            scor = 0;
            label3.Text = Convert.ToString(scor);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            f.Close();
            if (scor > int.Parse(x))
            {
                StreamWriter g = new StreamWriter("date.txt");
                g.WriteLine(Convert.ToString(scor));
                g.WriteLine(label4.Text);
                g.Close();
            }
            Application.Exit();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    }

