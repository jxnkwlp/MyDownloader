using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aria2Net;
using Aria2Net.Models;
using MyDownloader.Models;

namespace MyDownloader.Services
{
    public class DownloadService
    {
        private readonly Aria2Rpc _aria2Rpc;
        private readonly IStore _store;

        public DownloadService(IStore store)
        {
            _aria2Rpc = new Aria2Rpc("http://localhost:6800");
            _store = store;
        }

        public async Task<List<DownloadItemInfo>> GetListAsync()
        {
            var list = await _store.GetItemsAsync();

            return list.Select(x => new DownloadItemInfo
            {
                CreationTime = x.CreationTime,
                Id = x.Id,
                Name = x.Name,
                Progress = x.Progress,
                Size = x.Size,
                Status = x.Status,
            }).ToList();
        }

        public async Task SaveSessionAsync()
        {
            await _aria2Rpc.SaveSessionAsync();
        }

        private async Task AddFileToStoreAsync(string id)
        {
            var download = await _aria2Rpc.TellStatusAsync(id);

            await _store.CreateAsync(new StoreItem
            {
                CreationTime = DateTime.Now,
                Id = download.Gid,
                Status = download.Status,
                Size = download.CompletedLength,
                Name = string.Join(",", download.Files.Select(x => Path.GetFileName(x.Path))),
            });
        }

        public async Task AddUrls(string[] urls, string directory, bool overwrite = false)
        {
            var result = await _aria2Rpc.AddUrisAsync(urls, new Aria2Options()
            {
                Dir = directory,
                AllowOverwrite = overwrite,
            });

            await AddFileToStoreAsync(result);
        }

        public async Task<string> AddMetalinkAsync(string file, string directory, bool overwrite = false)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(file);

            var content = Convert.ToBase64String(File.ReadAllBytes(file));

            return await _aria2Rpc.AddMetalinkAsync(content, new Aria2Options()
            {
                Dir = directory,
                AllowOverwrite = overwrite,
            });
        }

        public async Task UpdateStatusAsync(List<DownloadItemInfo> items)
        {
            async Task UpdateAsync(IEnumerable<Aria2FileDownload> sources)
            {
                foreach (var download in sources)
                {
                    var item = items.FirstOrDefault(x => x.Id == download.Gid);
                    if (item != null)
                    {
                        item.Status = download.Status;
                        item.Progress = (int)(download.CompletedLength * 100 / download.TotalLength);
                        item.DownSpeed = download.DownloadSpeed;
                        item.UpSpeed = download.UploadSpeed;

                        await _store.UpdateAsync(item.Id, new StoreItem
                        {
                            CreationTime = item.CreationTime,
                            Name = item.Name,
                            Progress = item.Progress,
                            Size = item.Size,
                            Status = item.Status,
                        });
                    }
                }
            }

            var downloads = await _aria2Rpc.TellActivesAsync();
            await UpdateAsync(downloads);

            var stopped = await _aria2Rpc.TellStoppedsAsync(0, int.MaxValue);
            await UpdateAsync(stopped);

            var waiting = await _aria2Rpc.TellWaitingsAsync(0, int.MaxValue);
            await UpdateAsync(waiting);
        }

        public async Task<string> AddTorrentAsync(string file, string directory, bool overwrite = false)
        {
            if (!File.Exists(file))
                throw new FileNotFoundException(file);

            var content = Convert.ToBase64String(File.ReadAllBytes(file));

            return await _aria2Rpc.AddTorrentAsync(content, new Aria2Options()
            {
                Dir = directory,
                AllowOverwrite = overwrite,
            });
        }

    }
}
