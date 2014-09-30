using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

            while (true)
            {
                TcpClient s = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server Online... +*+*+*+");

                Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated");

                Stream ns = new NetworkStream(connectionSocket);

                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true; // enable automatic flushing

                string message = sr.ReadLine();
                string answer = "";
                while (message != null && message != "")
                {

                    Console.WriteLine("Client: " + message);
                    answer = message.ToUpper();
                    sw.WriteLine(answer);
                    message = sr.ReadLine();

                    Thread myThread = new Thread(new ThreadStart(serverStart));
                    myThread.Start();


                }

                connectionSocket.Close();



            }



        }
    }

}