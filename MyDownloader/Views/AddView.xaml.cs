using MyDownloader.ViewModels;

namespace MyDownloader.Views
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView
    {
        public AddView(AddViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

    }
}
