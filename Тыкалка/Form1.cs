using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Тыкалка
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int time = 0, j =0;
        int count, bad_count, count_all;
        int average_time = 0;
        int green_or_red;
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            button4.Text = "";
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void ClearForm()
        {
            label1.Enabled = false; label1.Visible = false;
            button1.Enabled = false; button1.Visible = false;
           
        }
        public  void CheckTime()
        {
            if (time >= 10)
            {
                ClickButton();
                time = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
            button4.Location = new Point(System.Windows.Forms.Form.ActiveForm.Size.Width / 2, System.Windows.Forms.Form.ActiveForm.Size.Height / 2);
            timer4.Enabled = true;
            timer1.Enabled = true;
            //label3.Visible = true;
            button4.Visible = true;
            button4.Enabled = true;
            label5.Visible = false; label6.Visible = false; label7.Visible = false; label8.Visible = false;
            ColorButton();
            //label2.Visible = true;
            label4.Visible = true;
            count = 0; count_all = 0; bad_count = 0; average_time = 0;
        }
        int i=0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (i >= 10)
            {
                timer4.Enabled = false;
                timer1.Enabled = false;
                i = 0;
                button4.Enabled = false;
                button4.Visible = false;
                button1.Enabled = true;
                button1.Visible = true;
                label2.Visible = false;
                label4.Visible = false;
                label3.Visible = false;
                Convert.ToDouble(count); Convert.ToDouble(average_time); Convert.ToDouble(count_all);
                label5.Visible = true; label6.Visible = true; label7.Visible = true; label8.Visible = true;
                label5.Text = "Количество попаданий на зеленое: " + count.ToString();
                if (average_time == 0)
                {
                    label6.Text = "Среднее время попадания: 0";
                }
                else
                {
                    label6.Text = "Среднее время попадания: " + Convert.ToString(Math.Round(((Convert.ToDouble(average_time) / Convert.ToDouble(count))))) + " ms";
                }
                label7.Text = "Количество попаданий на красное: " + bad_count.ToString();
                double p=0;
                if (count_all != 0)
                {
                    p = Math.Round(Convert.ToDouble(count) / Convert.ToDouble(count_all), 3) * 100;
                }
                if (p == 0)
                {
                    label8.Text = "Точность попаданий: 0%";
                }
                else {
                    label8.Text = "Точность попаданий: " + Convert.ToString(Math.Round(p, 3)) + "%"; }
            }
            i++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             time++;
            //label4.Text = time.ToString();
            CheckTime();
           
        }
         public void ColorButton()
        {
            
            int color = rnd.Next(0, 2);
            if (color == 1)
            {
                button4.BackColor = Color.Green;
                green_or_red = 1;
            }
            else
            {
                button4.BackColor = Color.Red;
                green_or_red = 0;
            }
            
        }
        public void ClickButton()
        {
            ColorButton(); 
            timer1.Enabled = false;        
            int x =  rnd.Next(100, 600);
            int y =  rnd.Next(100, 350 );
            button4.Location = new Point(x,y);
            timer1.Enabled = true;
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            
            if (green_or_red==1)
            {
                label3.Text = time.ToString() + " ms";
                count++;
                average_time += time;
                //green_or_red = false;
                label2.Visible = true;
                label3.Visible = true;
            }
            
            else 
            {
                label2.Visible = false;
                label3.Visible = false;
                bad_count++;
                //green_or_red = true;
            }ClickButton();
            time = 0;
            count_all++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
