using System;
using Microsoft.Toolkit.Mvvm.Messaging;
using ModernWpf.Media.Animation;
using MyDownloader.Messages;
using MyDownloader.ViewModels;

namespace MyDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
            _viewModel = viewModel;

            WeakReferenceMessenger.Default.Register<MainWindowViewModel, GoBackMessage>(viewModel, (r, n) =>
            {
                Frame.GoBack(new SlideNavigationTransitionInfo());
            });

            WeakReferenceMessenger.Default.Register<MainWindowViewModel, GotoPageMessage>(viewModel, (r, message) =>
            {
                viewModel.Goto(message.ContentControl);
            });

            WeakReferenceMessenger.Default.Send<ItemsReloadMessage>();
        }

        private void Frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }
    }
}
