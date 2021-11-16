using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MyDownloader.Models;

namespace MyDownloader.Services
{
    public class JsonStore : IStore
    {
        private static List<StoreItem> _storeItems = new List<StoreItem>();

        private const string _fileName = "store.json";
        private readonly string _filePath;


        public JsonStore()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "mydownloader");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _filePath = Path.Combine(directory, _fileName);

            _storeItems = Read();
        }

        private List<StoreItem> Read()
        {
            if (!File.Exists(_filePath))
                return new List<StoreItem>();

            return JsonSerializer.Deserialize<List<StoreItem>>(File.ReadAllText(_filePath));
        }

        private void Write(List<StoreItem> list)
        {
            var json = JsonSerializer.Serialize(list);
            File.WriteAllText(_filePath, json);
        }

        public Task CreateAsync(StoreItem item)
        {
            _storeItems.Add(item);
            Write(_storeItems);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(string id)
        {
            _storeItems.RemoveAll(x => x.Id == id);
            Write(_storeItems);
            return Task.CompletedTask;
        }

        public Task<List<StoreItem>> GetItemsAsync()
        {
            return Task.FromResult(_storeItems.OrderByDescending(x => x.CreationTime).ToList());
        }

        public Task UpdateAsync(string id, StoreItem item)
        {
            var find = _storeItems.Find(x => x.Id == id);
            find.Status = item.Status;
            find.Name = item.Name;
            find.Size = item.Size;
            Write(_storeItems);
            return Task.CompletedTask;
        }
    }
}
