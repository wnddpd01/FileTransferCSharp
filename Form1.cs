using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using MyPacket;

namespace Software3
{

    public partial class Form1 : Form
    {
        private NetworkStream m_NetStream;
        private TcpListener m_Listener;

        private byte[] sendBuffer = new byte[1024 * 5];
        private byte[] readBuffer = new byte[1024 * 5];
        private byte[] filedata;
        private Socket Client;
        private int stop = 0;

        private bool m_blsClientOn = false;

        private Thread m_Thread;
        private Thread send_Thread;

        public void SendPacket(Packet packet)
        {
            try
            {
                Packet.Serialize(packet).CopyTo(this.sendBuffer, 0);
                this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_NetStream.Flush();
            }
            catch
            {
                append_log("Client Disconnect");
                m_blsClientOn = false;
                m_NetStream.Close();
                m_Listener.Stop();
                this.m_blsClientOn = false;
                this.m_Thread.Abort();
                this.m_Thread = new Thread(RUN);
                readBuffer.Initialize();
                sendBuffer.Initialize();
                m_Thread.Start();
            }
        }

        public void RUN()
        {
            int c = 0;
            this.m_Listener = new TcpListener(IPAddress.Any, Int32.Parse(PortTb.Text));
            this.m_Listener.Start();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FSPTb.Text);
            

            if(this.m_blsClientOn == false)
            {
                append_log("Waiting Client\n");
            }
            try 
            {
                Client = m_Listener.AcceptSocket();
            }
            catch
            {
                return;
            }
            
            if(Client.Connected)
            {
                
                this.m_blsClientOn = true;
                append_log("Client Connected\n");
                this.m_NetStream = new NetworkStream(Client);

                foreach (System.IO.FileInfo f in di.GetFiles())
                {
                    
                    Packet packet = new Packet();
                    packet.filename = f.Name;
                    packet.filesize = f.Length;
                    Packet.Serialize(packet).CopyTo(this.sendBuffer, 0);
                    this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                    this.m_NetStream.Flush();
                    sendBuffer.Initialize();
                }
            }
            int nread = 0;
            
            while(this.m_blsClientOn)
            {
                try
                {
                    nread = 0;
                    nread = this.m_NetStream.Read(this.readBuffer, 0, 1024 * 5);
                    Packet packet2 = new Packet();
                    packet2 = (Packet)Packet.Deserialize(readBuffer);
                    if (packet2.type == 0)
                    {
                        foreach (System.IO.FileInfo f in di.GetFiles())
                        {
                            Packet packet = new Packet();
                            packet.filename = f.Name;
                            packet.filesize = f.Length;
                            Packet.Serialize(packet).CopyTo(this.sendBuffer, 0);
                            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                            this.m_NetStream.Flush();
                            sendBuffer.Initialize();
                        }
                    }
                    else if (packet2.type == 1)
                    {
                        Packet packet3 = new Packet();
                        packet3.filename = packet2.filename;
                        packet3.type = 1;
                        filedata = File.ReadAllBytes(FSPTb.Text + packet3.filename);
                        packet3.filesize = filedata.Length;
                        append_log("client request : " + FSPTb.Text + packet3.filename + " size: " + packet3.filesize.ToString());

                        Packet.Serialize(packet3).CopyTo(this.sendBuffer, 0);
                        this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                        this.m_NetStream.Flush();

                        sendBuffer.Initialize();
        
                        int count = (int)((packet3.filesize / (1024 * 4)) + 1);
                        for(int i = 0; i < count; i++)
                        {
                            if (i != (count - 1))
                            {
                                for (int k = i * (1024 * 4); k < (i * (1024 * 4)) + (1024 * 4); k++)
                                {
                                    packet3.filedata[k - (i * 1024 * 4)] = filedata[k];
                                }
                            }
                            
                            else if(i == (count-1))
                            {    
                                packet3.filedata.Initialize();
                                for (int k = i * (1024 * 4); k < ((i * (1024 * 4)) + ((int)packet3.filesize % (1024 * 4))); k++)
                                    packet3.filedata[k - (i * 1024 * 4)] = filedata[k];
                                filedata.Initialize();
                            }
                            
                            packet3.type = 2;
                            this.send_Thread = new Thread(delegate()
                                {
                                    SendPacket(packet3);
                                });
                            send_Thread.Start();
                            bool a;
                            while(true)
                            {
                                a = send_Thread.IsAlive;
                                if (a == true)
                                    Thread.Sleep(1);
                                else
                                    break;
                            }
                 
                            sendBuffer.Initialize();
                            packet3.filedata.Initialize();
                        }
                    }
                    else if(packet2.type == 2)
                    {
                        if (c == 0)
                            append_log("Client Send File : " + packet2.filename);
                        FileStream wr = File.OpenWrite(FSPTb.Text + packet2.filename);
                        int count = (int)(packet2.filesize / (1024 * 4)) + 1;
                        wr.Position = 1024 * 4 * c;
                        if (c != (count - 1))
                        {
                            for (int i = 0; i < packet2.filedata.Length; i++)
                                wr.WriteByte(packet2.filedata[i]);
                        }
                        if (c == (count - 1))
                        {
                            for (int i = 0; i < packet2.filesize % (1024 * 4); i++)
                                wr.WriteByte(packet2.filedata[i]);
                            c = -1;
                        }
                        wr.Flush();
                        wr.Close();
                        c++;
                        packet2.filedata.Initialize();
                        
                    }
                    else if(packet2.type == 999)
                    {
                        append_log("Client Disconnect");
                        m_blsClientOn = false;
                        m_NetStream.Close();
                        m_Listener.Stop();
                        RUN();
                    }
                }
                catch
                {
                    this.m_blsClientOn = false;
                    this.m_NetStream.Close();
                }
                
              
            }
            
        }
   
        public static string Client_IP
        {
            get
            {
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                string ClientIP = string.Empty;
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ClientIP = host.AddressList[i].ToString();
                    }
                }
                return ClientIP;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_Thread = new Thread(RUN);
            
            IpTb.Text = Client_IP;
            FSPTb.Text = "C:\\server\\";
        }

        private void Btn_Path_Click(object sender, EventArgs e)
        {   
            folderBrowserDialog1.SelectedPath = FSPTb.Text;
            folderBrowserDialog1.ShowDialog();
            FSPTb.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(btn_start.Text == "Start")
            {
                
                Btn_Path.Enabled = false;
                btn_start.Text = "Stop";
                append_log("Server Start");
                append_log(FSPTb.Text);
                this.m_Thread.Start();
                Btn_Path.Enabled = false;
                PortTb.Enabled = false;
            }
            else
            {
                if(m_blsClientOn == true)
                {
                    Packet packet4 = new Packet();
                    packet4.type = 999;
                    Packet.Serialize(packet4).CopyTo(this.sendBuffer, 0);
                    m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                    m_NetStream.Flush();
                    sendBuffer.Initialize();
                    m_blsClientOn = false;
                }
                Btn_Path.Enabled = true;
                PortTb.Enabled = true;
                btn_start.Text = "Start";
                log.Clear();
                m_Listener.Stop();
                //Client.Close();
                this.m_Thread.Abort();
                this.m_Thread = new Thread(RUN);
               
             }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_blsClientOn == true)
            {
                Packet packet4 = new Packet();
                packet4.type = 999;
                Packet.Serialize(packet4).CopyTo(this.sendBuffer, 0);
                m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                m_NetStream.Flush();
            }
            if(btn_start.Text == "Stop")
                this.m_Listener.Stop();
            if(m_blsClientOn == true)
                this.m_NetStream.Close();
            if(m_Thread.IsAlive == true)
                this.m_Thread.Abort();
        }

        public void append_log(string msg)
        {
            this.Invoke(new MethodInvoker(delegate()
                {
                    log.AppendText(msg + "\n");
                }));
        }


    }
}
