using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "The current time: ";
            str += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            textBox1.AppendText(str + Environment.NewLine);
            UdpClient udpSender = new UdpClient(0);
            int port = 8000;
            string host = "192.168.43.251";//我室友的IP地址
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndPoint实例
            udpSender.Connect(host, port);
            string message = textBox2.Text;
            byte[] sendBytes = Encoding.UTF8.GetBytes(message);
            udpSender.Send(sendBytes, sendBytes.Length);
            string sendStr = textBox2.Text;
            str = "The message content: " + sendStr;
            textBox1.AppendText(str + Environment.NewLine);
            str = "Send the message to the server...";
            textBox1.AppendText(str + Environment.NewLine);
            byte[] recvStr = udpSender.Receive(ref ipe);
            string message1 = Encoding.UTF8.GetString(recvStr, 0, recvStr.Length);
            str = "The server feedback: " + message1;//显示服务器返回信息
            textBox1.AppendText(str + Environment.NewLine);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
