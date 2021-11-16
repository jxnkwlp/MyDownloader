using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using MyDownloader.Views;

namespace MyDownloader.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public ContentControl Content { get; set; }

        public MainWindowViewModel(ItemsView itemsView)
        {
            Content = itemsView;

            // ViewUri = new Uri(@"/MyDownloader;component/views/itemsview.xaml", UriKind.Relative);
        }

        public void Goto(ContentControl contentControl)
        {
            Content = contentControl;
        }


        //    //ContentDialog dialog = new ContentDialog
        //    //{
        //    //    Title = "Save your work?",
        //    //    PrimaryButtonText = "Save",
        //    //    SecondaryButtonText = "Don't Save",
        //    //    CloseButtonText = "Cancel",
        //    //    DefaultButton = ContentDialogButton.Primary,
        //    //    // Content = new ContentDialogContent()
        //    //};
    }
}
