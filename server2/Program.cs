using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];

            //得到本机IP，设置TCP端口号         
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //绑定网络地址
            server.Bind(ip);

            Console.WriteLine("这是客户端, 主机名为: {0}", Dns.GetHostName());

            //等待客户机连接
            Console.WriteLine("等待客户端发送数据...");

            //得到客户机IP
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = server.ReceiveFrom(data, ref Remote);
            Console.WriteLine("消息来自于: {0}: ", Remote.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

            //客户机连接成功后，发送信息
            string welcome = "连接成功 ";

            //字符串与字节数组相互转换
            data = Encoding.UTF8.GetBytes(welcome);

            //发送信息 
            server.SendTo(data, Remote);



            while (true)
            {
                data = new byte[1024];
                //发送接收信息
                //从客户机接受消息
                recv = server.ReceiveFrom(data, ref Remote);
                //将字节流信息转换为字符串
                string Data = Encoding.Default.GetString(data, 0, recv);
                //将字符串输出到屏幕上
                Console.WriteLine(Data);
                // Console.WriteLine(Encoding.Default.GetString(data, 0, recv));
                
                //定义字符串input
                string input;
                //读取屏幕上的字符串
                input ="连接成功";
                if (input == "exit")
                    break;
                //将input发送至客户机
                server.SendTo(Encoding.UTF8.GetBytes(input),Remote);
            }
            server.Close();
        }

    }

}
