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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MyPacket;

namespace Client
{
    public partial class Form1 : Form
    {
        private NetworkStream m_NetStream;
        private TcpClient client;
        private Thread m_thread;
        private Thread send_Thread;

        private byte[] sendBuffer = new byte[1024 * 5];
        private byte[] readBuffer = new byte[1024 * 5];
        private int size;
        private bool connection = false;
        int count;

        public void pb_perform()
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                this.progressBar1.PerformStep();
            }));
        }

        public void SendPacket()
        {
            try
            {
                Thread.BeginCriticalRegion();
                byte[] filedata = File.ReadAllBytes(textBox_File.Text);
                int count = (filedata.Length / (1024 * 4)) + 1;
                Packet packet3 = new Packet();
                FileInfo fi = new FileInfo(textBox_File.Text);
                packet3.type = 2;
                packet3.filename = fi.Name;
                packet3.filesize = fi.Length;
                for (int i = 0; i < count; i++)
                {
                    if (i != (count - 1))
                    {
                        for (int k = i * (1024 * 4); k < (i * (1024 * 4)) + (1024 * 4); k++)
                        {
                            packet3.filedata[k - (i * 1024 * 4)] = filedata[k];
                        }
                    }

                    if (i == (count - 1))
                    {
                        packet3.filedata.Initialize();
                        for (int k = i * (1024 * 4); k < ((i * (1024 * 4)) + ((int)packet3.filesize % (1024 * 4))); k++)
                            packet3.filedata[k - (i * 1024 * 4)] = filedata[k];
                        filedata.Initialize();
                        listView1.Focus();
                    }
                    packet3.type = 2;
                    Packet.Serialize(packet3).CopyTo(this.sendBuffer, 0);
                    this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                    this.m_NetStream.Flush();
                    pb_perform();
                    sendBuffer.Initialize();
                    packet3.filedata.Initialize();
                }
                packet3.type = 0;
                Packet.Serialize(packet3).CopyTo(this.sendBuffer, 0);
                m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                m_NetStream.Flush();
                listView1.Enabled = true;
                listView1.Items.Clear();
                btn_Send.Enabled = true;
                Thread.EndCriticalRegion();
                send_Thread = new Thread(SendPacket);
            }
            catch
            {
                readBuffer.Initialize();
                sendBuffer.Initialize();
                listView1.Enabled = true;
                listView1.Items.Clear();
                btn_Send.Enabled = true;
                btn_connect.ForeColor = Color.Black;
                btn_connect.Text = "Connect";
                connection = false;
                listView1.Items.Clear();
                client.Close();
                m_NetStream.Close();
                m_thread.Abort();
                m_thread = new Thread(run);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.send_Thread = new Thread(SendPacket);
            textBox_Path.AppendText("C:\\client\\");
            this.listView1.View = View.Details;
            this.listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Size", 50, HorizontalAlignment.Left);
            this.listView1.Focus();
        }

        public void run()
        {

            this.connection = true;
            this.m_NetStream = this.client.GetStream();
            int c = 0;
            while (connection == true)
            {
                try
                {
                    
                    if (send_Thread.IsAlive == true)
                    {
                        Thread.Yield();
                    }
                    this.m_NetStream.Read(this.readBuffer, 0, 1024 * 5);
                    Packet packet = (Packet)Packet.Deserialize(readBuffer);
                    readBuffer.Initialize();
                    if (packet.type == 0)
                    {
                        listView1.Items.Add(new ListViewItem(
                           new string[]{
                        packet.filename, (packet.filesize).ToString()
                    }
                        ));
                    }
                    else if (packet.type == 1)
                    {
                        listView1.Enabled = false;
                        c = 0;
                        count = ((int)packet.filesize / (1024 * 4)) + 1;
                        size = (int)packet.filesize;
                        FileStream wr = File.OpenWrite(textBox_Path.Text + packet.filename);
                        progressBar1.Value = 0;
                        progressBar1.Step = 1;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = count;
                        wr.SetLength(packet.filesize);
                        wr.Close();
                        progressBar1.Focus();

                    }

                    else if (packet.type == 2)
                    {
                        listView1.Enabled = false;
                        FileStream wr = File.OpenWrite(textBox_Path.Text + packet.filename);
                        wr.Position = 1024 * 4 * c;
                        if (c != (count - 1))
                        {
                            for (int i = 0; i < packet.filedata.Length; i++)
                                wr.WriteByte(packet.filedata[i]);
                        }
                        if (c == (count - 1))
                        {
                            for (int i = 0; i < wr.Length % (1024 * 4); i++)
                                wr.WriteByte(packet.filedata[i]);
                        }
                        wr.Flush();
                        wr.Close();
                        c++;
                        packet.filedata.Initialize();
                        progressBar1.PerformStep();
                        if (c == count)
                        {
                            listView1.Enabled = true;
                        }
                    }

                    else if (packet.type == 999)
                    {
                        listView1.Items.Clear();
                        btn_connect.ForeColor = Color.Black;
                        btn_connect.Text = "Connect";
                        m_NetStream.Close();
                        connection = false;
                        m_thread.Abort();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection fail");
                    connection = false;
                    btn_connect.ForeColor = Color.Black;
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        this.btn_connect.Text = "Connect";
                    }));
                }
            }
           
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (btn_connect.Text == "Connect")
            {
                btn_connect.ForeColor = Color.Red;
                btn_connect.Text = "Disconnect";
                this.client = new TcpClient();
                try
                {
                    m_thread = new Thread(run);
                    this.client.Connect(this.textBox_IP.Text, Int32.Parse(this.textBox_Port.Text));
                    m_thread.Start();
                }
                catch
                {
                    btn_connect.ForeColor = Color.Black;
                    btn_connect.Text = "Connect";
                    MessageBox.Show("접속 에러");
                    return;
                }
                
            
            }
            else
            {
                Packet packet4 = new Packet();
                packet4.type = 999;
                Packet.Serialize(packet4).CopyTo(this.sendBuffer, 0);
                m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                m_NetStream.Flush();
                sendBuffer.Initialize();
                listView1.Items.Clear();
                client.Close();
                m_NetStream.Close();
                m_thread.Abort();
                m_thread = new Thread(run);
                btn_connect.ForeColor = Color.Black;
                btn_connect.Text = "Connect";
                connection = false;

            }
        }

        private void listview_dc(object sender, EventArgs e)
        {
            Packet packet2 = new Packet();
            packet2.type = 1;
            packet2.filename = listView1.FocusedItem.Text;
            Packet.Serialize(packet2).CopyTo(this.sendBuffer, 0);
            this.m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_NetStream.Flush();
            for (int i = 0; i < 1024 * 5; i++)
                this.sendBuffer[i] = 0;
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            if(btn_connect.Text == "Disconnect")
            {
                Packet packet4 = new Packet();
                packet4.type = 999;
                Packet.Serialize(packet4).CopyTo(this.sendBuffer, 0);
                m_NetStream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                m_NetStream.Flush();
                client.Close();
                m_NetStream.Close();
                m_thread.Abort();
            }

        }

        private void btn_FilePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = textBox_Path.Text;
            folderBrowserDialog1.ShowDialog();
            textBox_Path.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = textBox_Path.Text;
            openFileDialog1.ShowDialog();
            textBox_File.Text = openFileDialog1.FileName;
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo filedata = new FileInfo(textBox_File.Text);
                int count = ((int)filedata.Length / (1024 * 4)) + 1;
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = count;
                progressBar1.Focus();
                listView1.Enabled = false;
                btn_Send.Enabled = false;
                send_Thread = new Thread(SendPacket);
                send_Thread.Start();
            }
            catch(Exception ex)
            {
                listView1.Enabled = true;
                btn_Send.Enabled = true;
                MessageBox.Show(ex.ToString());
            }

      
        }
    }
}
