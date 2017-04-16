//simple program to implement multithreading

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Threading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread redBtn;
        Thread blueBtn;
        private static AutoResetEvent event_1 = new AutoResetEvent(true);

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //starting first thread on btn click
        private void button1_Click_1(object sender, EventArgs e)
        {
            redBtn = new Thread(threadRedBtn);

            try
            {
                if (!redBtn.IsAlive)    redBtn.Start();

                if (blueBtn.IsAlive)    blueBtn.Abort();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
     
        //printing the red rectangle on red btn click
        void threadRedBtn()
        {
            Random randPosition = new Random();
            for (int i = 0; i < 150; i++)
            {
                Thread.Sleep(90);
                Graphics graphics = this.CreateGraphics();
                Rectangle rect = new Rectangle(randPosition.Next(1300), randPosition.Next(700), 15, 15);
                graphics.DrawRectangle(Pens.Red, rect);
            }
        }

        //start the second thread on click
        private void button2_Click(object sender, EventArgs e)
        {
            blueBtn = new Thread(threadBlueBtn);
            try {
                if (!blueBtn.IsAlive) blueBtn.Start();
                if (redBtn.IsAlive) redBtn.Abort();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        //printing the blue rectangle on blue btn click
        void threadBlueBtn()
        {
            Random randPosition = new Random();
            for (int j = 0; j < 150; j++)
            {
                Thread.Sleep(90);
                Pen pen = new Pen(Color.Blue);
                Graphics graphics = this.CreateGraphics();
                //Rectangle rect = new Rectangle(randPosition.Next(1300), randPosition.Next(700), 15, 15);
                graphics.DrawEllipse(pen, randPosition.Next(1300), randPosition.Next(700), 15, 15);
                //graphics.DrawRectangle(Pens.DarkBlue, rect);
            }
        }
    }
}
