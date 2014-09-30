using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace httpserver
{
    public class HttpServer
    {
        public static readonly int DefaultPort = 8888;


        public HttpServer(int port)
        {
            port = port;
        }

        public void serverStart()
        {
            TcpListener serverSocket = new TcpListener(DefaultPort);
            serverSocket.Start();
            

        }



        }
    }

