using System;

namespace Aria2Net.Models
{
    public partial class Aria2FileServer
    {
        public Uri CurrentUri { get; set; }
        public Uri Uri { get; set; }
        public long DownloadSpeed { get; set; }
    }
}
