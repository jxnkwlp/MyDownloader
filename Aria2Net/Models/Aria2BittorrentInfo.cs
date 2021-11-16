using System;

namespace Aria2Net.Models
{
    public class Aria2BittorrentInfo
    {
        public Uri[][] AnnounceList { get; set; }
        public string Comment { get; set; }
        public long CreationDate { get; set; }
        public Aria2BittorrentName Info { get; set; }
        public string Mode { get; set; }
    }

    public class Aria2BittorrentName
    {
        public string Name { get; set; }
    }
}
