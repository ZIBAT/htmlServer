using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPServer
{
    class EchoService
    {
        private Socket connectionSocket;
        public EchoService(Socket connection)
        {
            this.connectionSocket = connection;
        }

        internal void DoIt()
        {
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

            }
            connectionSocket.Close();
        }
    }
    }
}
