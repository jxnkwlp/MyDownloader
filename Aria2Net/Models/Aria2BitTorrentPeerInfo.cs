namespace Aria2Net.Models
{
    public class Aria2BitTorrentPeerInfo
    {
        public bool AmChoking { get; set; }
        public string Bitfield { get; set; }
        public long DownloadSpeed { get; set; }
        public string Ip { get; set; }
        public bool PeerChoking { get; set; }
        public string PeerId { get; set; }
        public long Port { get; set; }
        public bool Seeder { get; set; }
        public long UploadSpeed { get; set; }
    }
}
