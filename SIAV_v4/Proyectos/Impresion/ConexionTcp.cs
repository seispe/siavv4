using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SIAV_v4.Proyectos.Impresion
{
    public class ConexionTcp
    {
        public TcpClient TcpClient { get; private set; }
        public NetworkStream Stream { get; private set; }
        public Thread ReadThread { get; private set; }
        public StreamWriter Writer { get; private set; }

        public delegate void DataCarrier(string data);
        public event DataCarrier OnDataRecieved;

        public delegate void DisconnectNotify();
        public event DisconnectNotify OnDisconnect;

        public delegate void ErrorCarrier(Exception e);
        public event ErrorCarrier OnError;

        public bool Connectar(string direccionIp, int puerto)
        {
            try
            {
                TcpClient = new TcpClient();
                TcpClient.Connect(IPAddress.Parse(direccionIp), puerto);
                Stream = TcpClient.GetStream();
                Writer = new StreamWriter(Stream);
                return true;
            }
            catch (Exception e)
            {
                if (OnError != null)
                    OnError(e);
                return false;
            }
        }

        private void EscribirMsj(string mensaje)
        {
            try
            {
                Writer.Write(mensaje + "\0");
                Writer.Flush();
            }
            catch (Exception e)
            {
                if (OnError != null)
                    OnError(e);
            }
        }
        public void EnviarPaquete(Paquete paquete)
        {
            EscribirMsj(paquete);
        }
    }
}
