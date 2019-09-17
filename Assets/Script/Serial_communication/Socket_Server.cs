#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;

namespace XyloStoriesSocket
{
    class Socket_Server
    {
        private static string localhost_ip = "127.0.0.1";
        private static int local_port = 9999;

        private static IPAddress ip_Adress = null;
        private static TcpListener tcp_Listener = null;

        private static StreamReader server_Reader = null;
        private static StreamWriter server_Writer = null;

        private static readonly List<TcpClient> clients = new List<TcpClient>();

        private static string read_data = null;

        private static bool connect_flag = false;

        // local socket
        public static void ServerStart_local()
        {
            Debug.Log("Server Start");
            ip_Adress = IPAddress.Parse(localhost_ip);
            tcp_Listener = new TcpListener(ip_Adress, local_port);

            tcp_Listener.Start();
            tcp_Listener.BeginAcceptSocket(AcceptClient, tcp_Listener);
        }

        private static void AcceptClient(IAsyncResult ar)
        {
            Debug.LogWarning("Connected Client");
            var listener = (TcpListener)ar.AsyncState;
            var client = listener.EndAcceptTcpClient(ar);

            clients.Add(client);

            listener.BeginAcceptSocket(AcceptClient, listener);

            NetworkStream stream = client.GetStream();
            server_Reader = new StreamReader(stream, Encoding.UTF8);

            connect_flag = true;

            while (client.Connected)
            {
                while (!server_Reader.EndOfStream)
                {
                    ProcessMessage(server_Reader);
                }

                if (client.Client.Poll(1000, SelectMode.SelectRead) && (client.Client.Available == 0))
                {
                    Debug.LogWarning("Disconnected Client");
                    client.Close();
                    clients.Remove(client);
                    break;
                }
            }
            connect_flag = false;
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
            tcp_Listener.Stop();
            Debug.Log("Server Close");
        }

        protected virtual void OnApplicationQuit()
        {
            if (tcp_Listener == null)
            {
                return;
            }

            if (clients.Count != 0)
            {
                foreach (var client in clients)
                {
                    client.Close();
                }
                tcp_Listener.Stop();
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
        public static bool Connect_Flag
        {
            get { return connect_flag; }
        }
        #endregion
    }
}

#endif