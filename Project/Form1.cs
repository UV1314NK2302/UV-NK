using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            timer1.Enabled = true;
            //timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = serialPort1.ReadExisting().ToString() + textBox1.Text;
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            //textBox1.Clear();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            string a = textBox1.Text;
            textBox1.Text = a.Substring(0, 2);

            int high;
            high = Convert.ToInt32(textBox1.Text);
           
            {
                if (high > 26)
                {
                    label3.Text = "temperature high";

                    string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=aswickjothi27@gmail.com:aswickcse&senderID=TEST SMS&receipientno=9626772779&msgtxt=This is a test from mVaayoo API&state=4";
                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = serialPort1.PortName;
            //textBox1.Text = a.ToString();
            textBox1.Text = serialPort1.ReadExisting().ToString() + a;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
