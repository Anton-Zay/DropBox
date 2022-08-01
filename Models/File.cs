namespace DropBoxApp.Models
{
    public class File
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FileType { get; set; }
        public byte[] Data { get; set; }
    }
}
