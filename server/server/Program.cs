using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Send1
{
    class MyServer
    {
        static void Main()
        {
            int result;
            string str = "第50行：hello cqjtu！重交物联2019级";
            UdpClient client = new UdpClient(11000);
            string receiveString = null;
            byte[] receiveData = null;
            //实例化一个远程端点，IP和端口可以随意指定，等调用client.Receive(ref remotePoint)时会将该端点改成真正发送端端点 
            IPEndPoint remotePoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("正在准备接收数据...");
            while (true)
            {
                receiveData = client.Receive(ref remotePoint);//接收数据 
                receiveString = Encoding.Default.GetString(receiveData);
                Console.WriteLine(receiveString);
                result = String.Compare(receiveString, str);
                if (result == 0)
                {
                    break;
                }
            }
            client.Close();//关闭连接
            Console.WriteLine("");
            Console.WriteLine("数据接收完毕，按任意键退出...");
            System.Console.ReadKey();
        }
    }
}
