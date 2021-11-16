using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using MyDownloader.Messages;
using MyDownloader.Models;
using MyDownloader.Services;
using MyDownloader.Views;

namespace MyDownloader.ViewModels
{
    public class ItemsViewModel : ObservableObject, IRecipient<ItemsReloadMessage>
    {
        public ICommand AddCommand => new RelayCommand(() => GotoAdd());

        private readonly IServiceProvider _serviceProvider;
        private readonly DownloadService _downloadService;
        private readonly ObservableCollection<FileItemViewModel> _files = new ObservableCollection<FileItemViewModel>();
        private static List<DownloadItemInfo> _downloadItems = new List<DownloadItemInfo>();

        public ReadOnlyObservableCollection<FileItemViewModel> Items => new ReadOnlyObservableCollection<FileItemViewModel>(_files);

        public ItemsViewModel(IServiceProvider serviceProvider, DownloadService downloadService)
        {
            _serviceProvider = serviceProvider;
            _downloadService = downloadService;

            //_sourceList
            //    .Connect()  // make the source an observable change set
            //    .Transform(item => new ItemViewModel()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Size = item.Size,
            //        Status = item.Status,
            //        CreationTime = item.CreationTime,
            //    })
            //    .ObserveOn(RxApp.MainThreadScheduler)
            //    .Bind(out _items)
            //    .Subscribe();

            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        await _downloadService.UpdateStatusAsync(_downloadItems);
                        await LoadItemsAsync();
                    }
                    catch (Exception ex)
                    {
                        // 
                    }

                    System.Threading.Thread.Sleep(2000);
                }
            });

            WeakReferenceMessenger.Default.Register<ItemsReloadMessage>(this);
        }

        public async Task LoadItemsAsync()
        {
            _downloadItems = await _downloadService.GetListAsync();

            _files.Clear();

            foreach (var item in _downloadItems)
            {
                _files.Add(new FileItemViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreationTime = item.CreationTime,
                    Size = item.Size,
                    Status = item.Status,
                    Process = item.Progress,
                    DownSpeed = item.DownSpeed,
                    UpSpeed = item.UpSpeed,
                });
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    _sourceList.Add(new StoreItem
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "file-" + i,
            //        CreationTime = DateTime.Now,
            //        Size = i * 1000,
            //        Status = "Done"
            //    });
            //}

        }

        private void GotoAdd()
        {
            var view = _serviceProvider.GetRequiredService<AddView>();
            WeakReferenceMessenger.Default.Send(new GotoPageMessage(view));
        }

        public async void Receive(ItemsReloadMessage message)
        {
            await LoadItemsAsync();
        }
    }
}
