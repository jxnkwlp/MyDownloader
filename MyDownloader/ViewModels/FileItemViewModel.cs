using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MyDownloader.ViewModels
{
    public class FileItemViewModel : ObservableObject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public long Size { get; set; }

        public double UpSpeed { get; set; }

        public double DownSpeed { get; set; }

        public string Speed => $"{DownSpeed} / {UpSpeed}";

        public int Process { get; set; }

        public DateTime CreationTime { get; set; }

    }
}
