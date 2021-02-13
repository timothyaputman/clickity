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
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        

        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            //uint X = (uint)Cursor.Position.X;
            //uint Y = (uint)Cursor.Position.Y;
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);

            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            //int X = Convert.ToInt32(button1.Text);
            //int Y = Convert.ToInt32(button1.Text);

            ////move to coordinates
            //var pt = new Point( X,Y);
            
            //Cursor.Position = pt;

            ////perform click            
            //mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            DateTime then = new DateTime();
            then = DateTime.Now.Add(TimeSpan.FromHours(1));
            // g = Form1.
            Thread.Sleep(4000);
            //then.Minute = now.Minute + 60;
            //int yes = now.Hour;
            int i = 0;
            Point pt = Cursor.Position; 
            while(DateTime.Now < then)
            {
                
                Thread.Sleep(1300);
                if(i == 0)
                {
                    pt = Cursor.Position; 
                i = i+1;

                };
                Point st = Cursor.Position;
                if(st!=pt){
                    //this.ShowDialog();
                    var formPopup = new Form();
                    var but = new Button();
                    but.Text = "yes";
                    formPopup.Controls.Add(but);
                    formPopup.Show(this);
                    ////if ()
                    ////{
                    ////    this.Close();
                    ////}
                    
                }
                DoMouseClick();

            }

        }
        
        private Boolean  button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return true;
            }
                return false;
            //else//left or middle click
            //{
            //    //do something here
            //}
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
