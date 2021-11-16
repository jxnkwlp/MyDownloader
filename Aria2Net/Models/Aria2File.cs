namespace Aria2Net.Models
{
    public class Aria2File
    {
        public long CompletedLength { get; set; }
        public long Index { get; set; }
        public long Length { get; set; }
        public string Path { get; set; }
        public bool Selected { get; set; }
        public Aria2FileUri[] Uris { get; set; }
    }
}
