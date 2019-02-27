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

namespace ServerTCPListerner
{
    public partial class Form1 : Form
    {
        public static int counter = 2;
        TcpListener listner = new TcpListener(8001);  // using System.Net.Socktes   // using System.Net; is required for EndPoint
        public static StreamWriter sw;
        List<Socket> clients = new List<Socket>();
        public static string objtimein,objtimeout;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

        }
        void Broadcast(Socket receivedfrom, string msg)
        {
            foreach (Socket s in clients)
            {

                if (s != receivedfrom)
                {
                    var stream = new NetworkStream(s);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    writer.WriteLine(msg);
                }
            }
        }
        void ListenClients(Socket clientsocket)
        {

            List<Student> stu = new List<Student>();
            stu.Add(new Student { AridNo = "15-arid-2427", Name = "Zohaib Ahmad", Age = 24 });
            stu.Add(new Student { AridNo = "15-arid-3656", Name = "Ahmad Ali", Age = 23 });
            stu.Add(new Student { AridNo = "15-arid-9554", Name = "Ahmar Waqar", Age = 25 });
            stu.Add(new Student { AridNo = "15-arid-6565", Name = "Asad Khan", Age = 20 });
            stu.Add(new Student { AridNo = "15-arid-1122", Name = "Fahad Nazir", Age = 21 });
            stu.Add(new Student { AridNo = "15-arid-1325", Name = "Ameer Hamza", Age = 22 });
            stu.Add(new Student { AridNo = "15-arid-6587", Name = "Atif Manzoor", Age = 25 });
            stu.Add(new Student { AridNo = "15-arid-2358", Name = "Zubair Ahmad", Age = 26 });
            stu.Add(new Student { AridNo = "15-arid-9584", Name = "Muhammad Umair", Age = 27 });
            stu.Add(new Student { AridNo = "15-arid-2598", Name = "Amir Sohail", Age = 22 });
            stu.Add(new Student { AridNo = "15-arid-5455", Name = "Mustafa Bin Tahir", Age = 23 });
            stu.Add(new Student { AridNo = "15-arid-6885", Name = "Hamza Arshad", Age = 19 });


            try
            {
                var stream = new NetworkStream(clientsocket);
                var reader = new StreamReader(stream);  // System.IO
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                string msg;
                EndPoint ep = clientsocket.RemoteEndPoint;
                while (true)
                {
                    msg = reader.ReadLine();
                    if (msg.ToLower() == "end")
                    {
                        counter++;
                        objtimeout = DateTime.Now.ToLongTimeString();
                        break;
                    }

                    var res = stu.FirstOrDefault(v => v.AridNo == msg);
                    if (res == null)
                    {
                        writer.WriteLine("Data not exist");
                    }
                    else
                    {

                        writer.WriteLine(res);
                    }


                    Thread t = new Thread(() => Broadcast(clientsocket, msg));
                    t.IsBackground = true;
                    t.Start();
                }
                
                //FileStream fs = new FileStream(@"F:\\Study Material\\BSCS-7C\\System Programming\\Assignments SP 1 Connection Pool\\LogConnection1.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
                //sw = new StreamWriter(fs);
                //sw.WriteLine(  "Time Out "+objtimeout+" IP Adrress "+clientsocket.RemoteEndPoint);
                //sw.Close();
                clients.Remove(clientsocket);
                clientsocket.Close();

            }
            catch (Exception eobj)
            {
                if (clientsocket != null)
                {
                    clients.Remove(clientsocket);
                    clientsocket.Close();
                }
            }

        }
        void Acceptsockets()
        {

            while (true)
            {
                if (counter > 0)
                {
                    var socket = listner.AcceptSocket();
                    clients.Add(socket);
                    objtimein = DateTime.Now.ToLongTimeString();
                    //FileStream fs = new FileStream(@"F:\\Study Material\\BSCS-7C\\System Programming\\Assignments SP 1 Connection Pool\\LogConnection1.txt", FileMode.Append, FileAccess.Write, FileShare.Write);
                    //sw = new StreamWriter(fs);
                    //sw.WriteLine("Time In "+objtimein + " IP Adrress " + socket.RemoteEndPoint);
                    //sw.Close();
                    counter--;
                    Thread listen = new Thread(() => ListenClients(socket));
                    listen.IsBackground = true;
                    listen.Start();
                }
            }

        }
        private void btnstart_Click(object sender, EventArgs e)
        {
            if (label1.Text != "Server is on")
            {
                label1.Text = "Server is on";
                listner.Start();
                Thread th = new Thread(() =>
                {

                    Acceptsockets();


                }); // using System.Threading
                th.IsBackground = true;
                th.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Socket s in clients)
            {


                var stream = new NetworkStream(s);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.WriteLine(richTextBox1.Text);

            }
        }
    }
}
