using System.Collections.ObjectModel;
using System.Collections.Specialized;
using MessageUI.ViewModels;

namespace MessageUI.Models
{
    public class Messages : ObservableCollection<MessageViewModel>
    {
        public void AddItem(MessageViewModel messageViewModel)
        {
            this.Items.Insert(0, messageViewModel);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, messageViewModel, 0));
        }
    }
}
