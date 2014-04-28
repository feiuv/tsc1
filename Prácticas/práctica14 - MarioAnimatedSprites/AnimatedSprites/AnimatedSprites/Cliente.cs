using System;
using System.Text;
using System.Net;
//using System.Net.Sockets;
namespace AnimatedSprites
{
    class ClienteUtils
    {
        public static bool Send(String servidorstr, int puerto, string datos)
        {
            bool result = false;
            try
            {
                IPAddress servidor = IPAddress.Parse(servidorstr);

                //string request = "<DIR>";
                Byte[] bytesSent = Encoding.ASCII.GetBytes(datos);
                Byte[] bytesReceived = new Byte[256];

                // Crear socket ip, puerto
                IPEndPoint ipe = new IPEndPoint(servidor, puerto);
                System.Net.Sockets.Socket s = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                s.Connect(ipe);


                s.Send(bytesSent, bytesSent.Length, 0);

                try
                {
                    byte[] data = new byte[1024];
                    int receivedDataLength = s.Receive(data);
                    string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                    Console.WriteLine(stringData);

                    s.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                    s.Close();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            catch (Exception se)
            {
                Console.WriteLine("Error en conexión" + se.StackTrace);
            }
            return result;
        }


        /*static void Main(string[] args)
        {           
            int port = 8000;            
            try
	    {
		if (args.Length > 0){
	                string result = Cliente(IPAddress.Parse(args[0]), port);
	                Console.WriteLine(result);
		}else 
			Console.WriteLine("Argumentos inválidos!!");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }*/
    }
}