using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Aria2Net.Models;

namespace Aria2Net
{
    public class Aria2Rpc
    {
        private readonly string _basicUrl;
        private readonly string _token;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        public Aria2Rpc(string basicUrl, string token = null)
        {
            _basicUrl = basicUrl;
            _token = token;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(basicUrl)
            };

            _jsonSerializerOptions.Converters.Add(new StringToBooleanConverter());

        }

        /// <summary>
        ///   Send request 
        /// </summary> 
        public async Task<RpcResponse<TResult>> RequestAsync<TResult>(string id, string method, object[] @params)
        {
            string content = JsonSerializer.Serialize(new RpcRequest
            {
                Id = id ?? Guid.NewGuid().ToString("N"),
                Jsonrpc = "2.0",
                Method = method,
                Params = @params.Where(x => x != null).ToList(),
            }, _jsonSerializerOptions);

            var response = await _httpClient.PostAsync("/jsonrpc", new StringContent(content));

            response.EnsureSuccessStatusCode();

            var jsonContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RpcResponse<TResult>>(jsonContent, _jsonSerializerOptions);
        }

        /// <summary>
        ///  This method adds a new download. uris is an array of HTTP/FTP/SFTP/BitTorrent URIs (strings) pointing to the same resource.
        /// </summary> 
        public async Task<string> AddUrisAsync(string[] urls, Aria2Options options = null)
        {
            var result = await RequestAsync<string>(null, "aria2.addUri", new object[] { urls, options });
            return result.Result;
        }

        /// <summary>
        ///  This method adds a BitTorrent download by uploading a ".torrent" file.
        /// </summary> 
        public async Task<string> AddTorrentAsync(string torrentContent, Aria2Options options = null)
        {
            var result = await RequestAsync<string>(null, "aria2.addTorrent", new object[] { torrentContent, options });
            return result.Result;
        }

        /// <summary>
        ///  This method adds a Metalink download by uploading a ".metalink" file. metalink is a base64-encoded string which contains the contents of the ".metalink" file.
        /// </summary> 
        public async Task<string> AddMetalinkAsync(string metalinkContent, Aria2Options options = null)
        {
            var result = await RequestAsync<string>(null, "aria2.addMetalink", new object[] { metalinkContent, options });
            return result.Result;
        }

        /// <summary>
        ///  This method removes the download denoted by gid (string). If the specified download is in progress, it is first stopped. The status of the removed download becomes removed. This method returns GID of removed download.
        /// </summary> 
        public async Task<string> RemoveAsync(string gid)
        {
            var result = await RequestAsync<string>(null, "aria2.remove", new object[] { gid });
            return result.Result;
        }

        /// <summary>
        ///  This method removes the download denoted by gid. This method behaves just like aria2.remove() except that this method removes the download without performing any actions which take time, such as contacting BitTorrent trackers to unregister the download first.
        /// </summary> 
        public async Task<string> ForceRemoveAsync(string gid)
        {
            var result = await RequestAsync<string>(null, "aria2.forceRemove", new object[] { gid });
            return result.Result;
        }

        /// <summary>
        ///  This method pauses the download denoted by gid (string). The status of paused download becomes paused. If the download was active, the download is placed in the front of waiting queue. While the status is paused, the download is not started. To change status to waiting, use the aria2.unpause() method. This method returns GID of paused download.
        /// </summary> 
        public async Task PauseAsync(string gid)
        {
            await RequestAsync<string>(null, "aria2.pause", new object[] { gid });
        }

        /// <summary>
        ///  This method pauses the download denoted by gid. This method behaves just like aria2.pause() except that this method pauses downloads without performing any actions which take time, such as contacting BitTorrent trackers to unregister the download first.
        /// </summary> 
        public async Task ForcePauseAsync(string gid)
        {
            await RequestAsync<string>(null, "aria2.forcePause", new object[] { gid });
        }

        /// <summary>
        ///  This method changes the status of the download denoted by gid (string) from paused to waiting, making the download eligible to be restarted. This method returns the GID of the unpaused download.
        /// </summary> 
        public async Task UnpauseAsync(string gid)
        {
            await RequestAsync<string>(null, "aria2.unpause", new object[] { gid });
        }

        /// <summary>
        ///  This method is equal to calling aria2.unpause() for every paused download. This methods returns OK.
        /// </summary> 
        public async Task UnpauseAllAsync()
        {
            await RequestAsync<string>(null, "aria2.unpauseAll", new object[] { });
        }

        /// <summary>
        ///  This method is equal to calling aria2.pause() for every active/waiting download. This methods returns OK.
        /// </summary> 
        public async Task PauseAllAsync()
        {
            await RequestAsync<string>(null, "aria2.pauseAll", new object[] { });
        }

        /// <summary>
        ///  This method is equal to calling aria2.forcePause() for every active/waiting download. This methods returns OK.
        /// </summary> 
        public async Task ForcePauseAllAsync()
        {
            await RequestAsync<string>(null, "aria2.forcePauseAll", new object[] { });
        }

        /// <summary>
        ///  This method returns the progress of the download denoted by gid (string). keys is an array of strings. If specified, the response contains only keys in the keys array. If keys is empty or omitted, the response contains all keys. This is useful when you just want specific keys and avoid unnecessary transfers.
        /// </summary> 
        public async Task<Aria2FileDownload> TellStatusAsync(string gid)
        {
            var response = await RequestAsync<Aria2FileDownload>(null, "aria2.tellStatus", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns the URIs used in the download denoted by gid (string).
        /// </summary> 
        public async Task<Aria2FileUri[]> GetUrilsAsync(string gid)
        {
            var response = await RequestAsync<Aria2FileUri[]>(null, "aria2.getUris", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns the file list of the download denoted by gid (string).
        /// </summary> 
        public async Task<Aria2File[]> GetFilesAsync(string gid)
        {
            var response = await RequestAsync<Aria2File[]>(null, "aria2.getFiles", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns a list peers of the download denoted by gid (string). This method is for BitTorrent only.
        /// </summary> 
        public async Task<Aria2BitTorrentPeerInfo[]> GetPeersAsync(string gid)
        {
            var response = await RequestAsync<Aria2BitTorrentPeerInfo[]>(null, "aria2.getPeers", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns currently connected HTTP(S)/FTP/SFTP servers of the download denoted by gid (string).
        /// </summary> 
        public async Task<Aria2FileServerInfo> GetServersAsync(string gid)
        {
            var response = await RequestAsync<Aria2FileServerInfo>(null, "aria2.getServers", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns a list of active downloads. The response is an array of the same structs as returned by the aria2.tellStatus() method.
        /// </summary> 
        public async Task<Aria2FileDownload[]> TellActivesAsync()
        {
            var response = await RequestAsync<Aria2FileDownload[]>(null, "aria2.tellActive", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method returns a list of waiting downloads, including paused ones. offset is an integer and specifies the offset from the download waiting at the front. num is an integer and specifies the max. number of downloads to be returned.
        /// </summary> 
        public async Task<Aria2FileDownload[]> TellWaitingsAsync(int skipCount, int resultCount)
        {
            var response = await RequestAsync<Aria2FileDownload[]>(null, "aria2.tellWaiting", new object[] { skipCount, resultCount });
            return response.Result;
        }

        /// <summary>
        ///  This method returns a list of stopped downloads. offset is an integer and specifies the offset from the least recently stopped download. num is an integer and specifies the max. number of downloads to be returned.
        /// </summary> 
        public async Task<Aria2FileDownload[]> TellStoppedsAsync(int skipCount, int resultCount)
        {
            var response = await RequestAsync<Aria2FileDownload[]>(null, "aria2.tellStopped", new object[] { skipCount, resultCount });
            return response.Result;
        }

        /// <summary>
        ///  This method changes the position of the download denoted by gid in the queue.
        /// </summary> 
        public async Task<int> ChangePositionAsync(string gid, int position, bool setPosition = true)
        {
            var response = await RequestAsync<int>(null, "aria2.changePosition", new object[] { gid, position, setPosition ? "POS_SET" : "POS_CUR" });
            return response.Result;
        }

        /// <summary>
        ///  This method returns options of the download denoted by gid. The response is a struct where keys are the names of options.
        /// </summary>
        public async Task<Aria2Options> GetOptionsAsync(string gid)
        {
            var response = await RequestAsync<Aria2Options>(null, "aria2.getOption", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method changes options of the download denoted by gid (string) dynamically. options is a struct.
        /// </summary> 
        public async Task<string> ChangeOptionsAsync(string gid, Aria2Options options)
        {
            var response = await RequestAsync<string>(null, "aria2.changeOption", new object[] { gid, options });
            return response.Result;
        }

        /// <summary>
        ///  This method returns the global options. The response is a struct. Its keys are the names of options.
        /// </summary> 
        public async Task<Aria2Options> GetGlobalOptionsAsync()
        {
            var response = await RequestAsync<Aria2Options>(null, "aria2.getGlobalOption", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method changes global options dynamically. 
        /// </summary> 
        public async Task<string> ChangeGlobalOptionsAsync(Aria2Options options)
        {
            var response = await RequestAsync<string>(null, "aria2.changeGlobalOption", new object[] { options });
            return response.Result;
        }

        /// <summary>
        ///  This method returns global statistics such as the overall download and upload speeds
        /// </summary> 
        public async Task<Aria2GlobalStatus> GetGlobalStatusAsync()
        {
            var response = await RequestAsync<Aria2GlobalStatus>(null, "aria2.getGlobalStat", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method purges completed/error/removed downloads to free memory. This method returns OK.
        /// </summary> 
        public async Task<string> PurgeDownloadResultAsync()
        {
            var response = await RequestAsync<string>(null, "aria2.purgeDownloadResult", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method removes a completed/error/removed download denoted by gid from memory. This method returns OK for success.
        /// </summary> 
        public async Task<string> RemoveDownloadResultAsync(string gid)
        {
            var response = await RequestAsync<string>(null, "aria2.removeDownloadResult", new object[] { gid });
            return response.Result;
        }

        /// <summary>
        ///  This method returns the version of aria2 and the list of enabled features.
        /// </summary> 
        public async Task<Aria2VersionInfo> GetVersionAsync()
        {
            var response = await RequestAsync<Aria2VersionInfo>(null, "aria2.getVersion", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method returns session information.
        /// </summary> 
        public async Task<Aria2SessionInfo> GetSessionInfoAsync()
        {
            var response = await RequestAsync<Aria2SessionInfo>(null, "aria2.getSessionInfo", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method saves the current session to a file specified by the --save-session option.
        /// </summary>
        public async Task<string> SaveSessionAsync()
        {
            var response = await RequestAsync<string>(null, "aria2.saveSession", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method shuts down aria2. This method returns OK.
        /// </summary> 
        public async Task<Aria2SessionInfo> ShutdownAsync()
        {
            var response = await RequestAsync<Aria2SessionInfo>(null, "aria2.shutdown", new object[] { });
            return response.Result;
        }

        /// <summary>
        ///  This method shuts down aria2().
        /// </summary> 
        public async Task<Aria2SessionInfo> ForceShutdownAsync()
        {
            var response = await RequestAsync<Aria2SessionInfo>(null, "aria2.forceShutdown", new object[] { });
            return response.Result;
        }

    }
}
