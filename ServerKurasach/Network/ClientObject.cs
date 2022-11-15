

using ServerKurasach.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerKurasach.Network
{
    public class ClientObject
    {
        public TcpClient client;
        string[] message;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[512];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                        Console.WriteLine(bytes);
                        Console.WriteLine(builder.ToString());
                    }
                    while (stream.DataAvailable);
                    Request request = new Request();
                    data = request.GetRequest(message = builder.ToString().Split('`'));
                    if (data != null)
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
