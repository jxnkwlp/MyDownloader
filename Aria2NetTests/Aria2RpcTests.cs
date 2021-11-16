using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aria2Net.Tests
{
    [TestClass()]
    public class Aria2RpcTests
    {
        private readonly Aria2Rpc _rpc = new Aria2Rpc("http://localhost:6800", null);


        [TestMethod()]
        public async Task AddUrisAsyncTest()
        {
            var result = await _rpc.AddUrisAsync(new string[] { "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" });

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task AddTorrentAsyncTestAsync()
        {
            var content = Convert.ToBase64String(File.ReadAllBytes("ubuntu-20.04.3-live-server-amd64.iso.torrent"));

            var result = await _rpc.AddTorrentAsync(content);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task TellStatusAsyncTestAsync()
        {
            var gid = await _rpc.AddUrisAsync(new string[] { "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" });

            Assert.IsNotNull(gid);

            var result = await _rpc.TellStatusAsync(gid);

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetGlobalStatusAsyncTestAsync()
        {
            var result = await _rpc.GetGlobalStatusAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task GetGlobalOptionsAsyncTestAsync()
        {
            var result = await _rpc.GetGlobalOptionsAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task PauseAllAsyncTest()
        {
            await _rpc.PauseAllAsync();
        }

        [TestMethod()]
        public async Task UnpauseAsyncTestAsync()
        {
            await _rpc.UnpauseAllAsync();
        }

        [TestMethod()]
        public async Task PurgeDownloadResultAsyncTest()
        {
            await _rpc.PurgeDownloadResultAsync();
        }

    }
}
