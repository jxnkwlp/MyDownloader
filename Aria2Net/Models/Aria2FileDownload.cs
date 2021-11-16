namespace Aria2Net.Models
{
    public class Aria2FileDownload
    {
        public string Bitfield { get; set; }
        public Aria2BittorrentInfo Bittorrent { get; set; }
        public long CompletedLength { get; set; }
        public long Connections { get; set; }
        public string Dir { get; set; }
        public long DownloadSpeed { get; set; }
        public Aria2File[] Files { get; set; }
        public string Gid { get; set; }
        public string InfoHash { get; set; }
        public long NumPieces { get; set; }
        public long NumSeeders { get; set; }
        public long PieceLength { get; set; }
        public bool Seeder { get; set; }
        public string Status { get; set; }
        public long TotalLength { get; set; }
        public long UploadLength { get; set; }
        public long UploadSpeed { get; set; }
    }
}
