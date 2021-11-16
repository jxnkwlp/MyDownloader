using System.Collections.Generic;
using System.Threading.Tasks;
using MyDownloader.Models;

namespace MyDownloader.Services
{
    public interface IStore
    {
        Task<List<StoreItem>> GetItemsAsync();
        Task CreateAsync(StoreItem item);
        Task UpdateAsync(string id, StoreItem item);
        Task DeleteAsync(string id);
    }
}
