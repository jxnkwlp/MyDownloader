namespace Aria2Net.Models
{
    public class Aria2GlobalStatus
    {
        public long DownloadSpeed { get; set; }
        public long NumActive { get; set; }
        public long NumStopped { get; set; }
        public long NumStoppedTotal { get; set; }
        public long NumWaiting { get; set; }
        public long UploadSpeed { get; set; }
    }
}
