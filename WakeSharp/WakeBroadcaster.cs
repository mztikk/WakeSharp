using System;
using System.Net;
using System.Net.Sockets;

namespace WakeSharp
{
    public static class WakeBroadcaster
    {
        private static readonly byte[] s_magicPrefix = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

        public static int Port { get; set; } = 7;

        public static byte[] GetPacket(byte[] mac)
        {
            if (mac.Length != 6)
            {
                throw new ArgumentException();
            }

            byte[] packet = new byte[s_magicPrefix.Length + (16 * mac.Length)];

            Buffer.BlockCopy(s_magicPrefix, 0, packet, 0, s_magicPrefix.Length);

            for (int i = 1; i <= 16; i++)
            {
                Buffer.BlockCopy(mac, 0, packet, i * mac.Length, mac.Length);
            }

            return packet;
        }

        public static void Wakeup(byte[] mac)
        {
            using (UdpClient client = new UdpClient())
            {
                client.Connect(IPAddress.Broadcast, Port);

                byte[] packet = GetPacket(mac);

                client.Send(packet, packet.Length);
            }
        }

        public static void Wakeup(string mac) => Wakeup(GetMacBytes(mac));

        public static byte[] GetMacBytes(string mac)
        {
            mac = mac.Replace("-", string.Empty).Replace(":", string.Empty);

            if (mac.Length != 12)
            {
                throw new ArgumentException();
            }

            int n = mac.Length;
            byte[] bytes = new byte[n / 2];
            for (int i = 0; i < n; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(mac.Substring(i, 2), 16);
            }

            return bytes;
        }
    }
}
