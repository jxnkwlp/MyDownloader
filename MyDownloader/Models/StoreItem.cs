using System;

namespace MyDownloader.Models
{
    public class StoreItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public long Size { get; set; }
        public int Progress { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
