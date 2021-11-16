using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;

namespace MyDownloader.Messages
{
    public class GotoPageMessage : RequestMessage<ContentControl>
    {
        public ContentControl ContentControl { get; }

        public GotoPageMessage(ContentControl contentControl)
        {
            ContentControl = contentControl;
        }
    }
}
