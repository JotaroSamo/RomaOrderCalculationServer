using ServerKurasach.Network;
using System.Net;
using System.Net.Sockets;

public class Program
    
{
    const int port = 8888;
    static TcpListener? listener;

    private static void Main(string[] args)
    {

        try
        {
            listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Ожидание подключений...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                ClientObject clientObject = new ClientObject(client);
                Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                clientThread.Start();
                Console.WriteLine("Новое подключение");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (listener != null)
                listener.Stop();
        }

    }
}
