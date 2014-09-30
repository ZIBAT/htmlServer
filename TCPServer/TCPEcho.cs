using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCPServer
{
    class TCPEcho
    {
        {
            TcpListener serverSocket = new TcpListener(65080);
            serverSocket.Start();

            //Socket connectionSocket = serverSocket.AcceptSocket();

            while (true)
            {
                Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated");
                EchoService service = new EchoService(connectionSocket);
                //concurrent
                Thread myThread = new Thread(new ThreadStart(service.DoIt));
                myThread.Start();
            }
        }
    }
}
