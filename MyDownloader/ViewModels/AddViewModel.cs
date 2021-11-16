using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using ModernWpf.Controls;
using MyDownloader.Messages;
using MyDownloader.Services;

namespace MyDownloader.ViewModels
{
    public class AddViewModel : ObservableValidator
    {
        [Required]
        public string Link { get; set; }

        [Required]
        public string Directory { get; set; }

        public ICommand SubmitCommand => new AsyncRelayCommand(async () => await Submit());
        public ICommand CancelCommand => new RelayCommand(() => GotoBack());
        public ICommand FolderBrowserCommand => new RelayCommand(() => FolderBrowser());
        public ICommand FileBrowserCommand => new RelayCommand(() => FileBrowser());


        private readonly DownloadService _downloadService;

        public AddViewModel(DownloadService downloadService)
        {
            _downloadService = downloadService;
        }

        private void GotoBack()
        {
            WeakReferenceMessenger.Default.Send<GoBackMessage>();
        }

        private async Task Submit()
        {
            if (string.IsNullOrEmpty(Link))
                return;

            if (string.IsNullOrEmpty(Directory))
                return;

            if (!Path.IsPathRooted(Directory))
            {
                _ = await new ContentDialog()
                {
                    Title = "Notice",
                    Content = $"The Directory '{Directory}' is invalid",
                    PrimaryButtonText = "Ok",
                    DefaultButton = ContentDialogButton.Primary,
                }.ShowAsync();
                return;
            }

            var input = Link.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var torrents = input.Where(x => Path.IsPathRooted(x) && x.EndsWith(".torrent"));
            var metalinks = input.Where(x => Path.IsPathRooted(x) && x.EndsWith(".metalink"));
            var urls = input.Where(x => !Path.IsPathRooted(x));

            try
            {
                if (urls.Any())
                {
                    await _downloadService.AddUrls(urls.ToArray(), Directory);
                }

                if (torrents.Any())
                    foreach (var item in torrents)
                    {
                        await _downloadService.AddTorrentAsync(item, Directory);
                    }

                if (torrents.Any())
                    foreach (var item in torrents)
                    {
                        await _downloadService.AddTorrentAsync(item, Directory);
                    }

                WeakReferenceMessenger.Default.Send<ItemsReloadMessage>();

                GotoBack();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FolderBrowser()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
                AutoUpgradeEnabled = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Directory = dialog.SelectedPath;
            }
        }

        private void FileBrowser()
        {
            var dialog = new System.Windows.Forms.OpenFileDialog()
            {
                AutoUpgradeEnabled = true,
                Filter = "*.torrent|*.metalink",
                Multiselect = true,
                CheckFileExists = true,
                CheckPathExists = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Link = string.Join(Environment.NewLine, dialog.FileNames);
            }
        }
    }
}
