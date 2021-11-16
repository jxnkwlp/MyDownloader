using System;

namespace MyDownloader.Models
{
    public class DownloadItemInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public long Size { get; set; }
        public int Progress { get; set; }
        public double UpSpeed { get; set; }
        public double DownSpeed { get; set; }
        public DateTime CreationTime { get; set; }
        public string ErrorMessage { get; set; }
        public DownloadItemFileInfo[] Files { get; set; }
    }

    public class DownloadItemStatus { }
    public class DownloadItemFileInfo
    {
        public int Index { get; set; }
        public string FilePath { get; set; }
        public long TotalLength { get; set; }
        public long CurrentLength { get; set; }
        public DownloadItemFileUrlInfo[] Uris { get; set; }
    }

    public class DownloadItemFileUrlInfo
    {
        public Uri Uri { get; set; }
        public string Status { get; set; }
    }
}
