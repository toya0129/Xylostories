#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;

namespace XyloStoriesSocket
{
    class Socket_Server
    {
        private static string localhost_ip = "127.0.0.1";
        private static int local_port = 9999;

        private static IPAddress ip_adress = null;
        private static TcpListener tcp_listener = null;

        private static StreamReader server_reader = null;
        private static StreamWriter server_writer = null;

        private static readonly List<TcpClient> clients = new List<TcpClient>();

        private static string read_data = null;

        // local socket
        public static void ServerStart_local()
        {
            Debug.Log("Server Start");
            ip_adress = IPAddress.Parse(localhost_ip);
            tcp_listener = new TcpListener(ip_adress, local_port);

            tcp_listener.Start();
            tcp_listener.BeginAcceptSocket(AcceptClient, tcp_listener);
        }

        private static void AcceptClient(IAsyncResult ar)
        {
            Debug.LogWarning("Connected Client");
            var listener = (TcpListener)ar.AsyncState;
            var client = listener.EndAcceptTcpClient(ar);

            clients.Add(client);

            listener.BeginAcceptSocket(AcceptClient, listener);

            NetworkStream stream = client.GetStream();
            server_reader = new StreamReader(stream, Encoding.UTF8);

            while (client.Connected)
            {
                while (!server_reader.EndOfStream)
                {
                    ProcessMessage(server_reader);
                }

                if (client.Client.Poll(1000, SelectMode.SelectRead) && (client.Client.Available == 0))
                {
                    Debug.LogWarning("Disconnected Client");
                    client.Close();
                    clients.Remove(client);
                    break;
                }
            }
        }

        public static void ServerClose()
        {
            if (clients.Count != 0)
            {
                foreach (var client in clients)
                {
                    client.Close();
                }
            }
            tcp_listener.Stop();
            Debug.Log("Server Close");
        }

        protected virtual void OnApplicationQuit()
        {
            if (tcp_listener == null) return;

            if (clients.Count != 0)
            {
                foreach (var client in clients)
                {
                    client.Close();
                }
                tcp_listener.Stop();
            }
        }


        private static void ProcessMessage(StreamReader reader)
        {
            read_data = reader.ReadLine();
            Debug.Log("Read Data = " + read_data);
        }

        #region Getter and Setter
        public static string Read_Data
        {
            get { return read_data; }
        }
        #endregion
    }
}
#endif