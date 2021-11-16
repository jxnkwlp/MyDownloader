using MyDownloader.ViewModels;

namespace MyDownloader.Views
{
    /// <summary>
    /// Interaction logic for ItemsView.xaml
    /// </summary>
    public partial class ItemsView
    {
        public ItemsView(ItemsViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
           
    }
}
