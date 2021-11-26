using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Send1_C
{
    class Program
    {
        static void Main()
        {
            //提示信息
            Console.WriteLine("按下任意按键开始发送...");
            Console.ReadKey();

            int m;

            //做好链接准备
            UdpClient client = new UdpClient();  //实例一个端口
            IPAddress remoteIP = IPAddress.Parse("192.168.43.251");  //假设发送给这个IP
            int remotePort = 11000;  //设置端口号
            IPEndPoint remotePoint = new IPEndPoint(remoteIP, remotePort);  //实例化一个远程端点 

            for (int i = 0; i < 50; i++)
            {
                //要发送的数据：第n行：hello cqjtu！重交物联2019级
                string sendString = null;
                sendString += "第";
                m = i + 1;
                sendString += m.ToString();
                sendString += "行：hello cqjtu！重交物联2019级";

                //定义发送的字节数组
                //将字符串转化为字节并存储到字节数组中
                byte[] sendData = null;
                sendData = Encoding.Default.GetBytes(sendString);

                client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点 
            }
            client.Close();//关闭连接

            //提示信息
            Console.WriteLine("");
            Console.WriteLine("数据发送成功，按任意键退出...");
            System.Console.ReadKey();
        }
    }
}
