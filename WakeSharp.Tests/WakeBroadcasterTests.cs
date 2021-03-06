using Microsoft.VisualStudio.TestTools.UnitTesting;
using RFReborn.Comparison;

namespace WakeSharp.Tests
{
    [TestClass]
    public class WakeBroadcasterTests
    {
        private const string MacString = "00-FF-52-10-6B-A5";
        private static readonly byte[] s_macBytes = new byte[] { 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5 };
        private static readonly byte[] s_wolPacket = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5, 0x00, 0xFF, 0x52, 0x10, 0x6B, 0xA5 };

        [TestMethod]
        public void GetPacketTest()
        {
            byte[] packet = WakeBroadcaster.GetPacket(s_macBytes);
            Assert.IsTrue(FastCompare.Equals(s_wolPacket, packet));
        }

        [TestMethod]
        public void GetMacBytesTest()
        {
            byte[] bytes = WakeBroadcaster.GetMacBytes(MacString);
            Assert.IsTrue(FastCompare.Equals(s_macBytes, bytes));
        }
    }
}
