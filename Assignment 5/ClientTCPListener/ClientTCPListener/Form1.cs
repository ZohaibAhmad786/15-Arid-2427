using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientTCPListener
{
    public partial class Form1 : Form
    {
        TcpClient client = new TcpClient();
        IPAddress ipaddress = IPAddress.Parse("127.0.0.1");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text != "Connected")
                {
                    client.Connect(ipaddress, 8001);
                    label1.Text = "Connected";
                    Thread t = new Thread(() => Receive());
                    t.IsBackground = true;
                    t.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed.....");
            }
        }
        void Receive()
        {
            try
            {
                var stream = client.GetStream();
                var reader = new StreamReader(stream);
                while (true)
                {
                    var serverMessage = reader.ReadLine();
                    if (serverMessage == "End")
                        break;
                    lbxmsgs.Items.Add(serverMessage);//show data in listbox-

                }
                label1.Text = "Connection end";
                client.Close();
            }
            catch (Exception eobj)
            {
                MessageBox.Show(eobj.Message);
            }

        }
        private void btsend_Click(object sender, EventArgs e)
        {
            try
            {
                if (label1.Text == "Connected")
                {
                    var stream = client.GetStream();
                    var writer = new StreamWriter(stream);
                    
                    if (txtmsg.Text != "end")
                    {
                        writer.WriteLine(txtmsg.Text);

                    }else
                    {
                        writer.WriteLine(txtmsg.Text);
                        
                    }
                    //writer.WriteLine(txtmsg.Text);

                    writer.Flush();
                }
            }
            catch (Exception eobj)
            {
                MessageBox.Show(eobj.Message);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var stream = client.GetStream();
            var writer = new StreamWriter(stream);
            writer.WriteLine("end");
            
            Application.Exit();
        }
    }
}
