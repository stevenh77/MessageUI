using System;
using System.Windows.Input;
using MessageUI.Events;
using MessageUI.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace MessageUI.ViewModels
{
    public class MessageViewModel
    {
        public MessageViewModel(IEventAggregator eventAggregator, Message model)
        {
            this.eventAggregator = eventAggregator;
            this.model = model;
            this.WireUpCommands();
        }

        private void WireUpCommands()
        {
            CloseCommand = new DelegateCommand<object>(CloseCommandExecute);
        }

        public void CloseCommandExecute(object messageId)
        {
            this.eventAggregator.GetEvent<CloseMessageEvent>().Publish((Guid) messageId);
        }

        private readonly Message model;
        private readonly IEventAggregator eventAggregator;

        public Guid Id { get { return model.Id; } }
        public string Title { get { return model.Title; } }
        public string Text { get { return model.Text; } }
        public MessageType MessageType { get { return model.MessageType; } }
        public ICommand CloseCommand { get; set; }
    }
}
