using System;
using System.Linq;
using System.Windows.Input;
using MessageUI.Events;
using MessageUI.Models;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Practices.Prism.Events;

namespace MessageUI.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private const string MESSAGE_TEXT = "We are pleased to announce the release of our latest special offer: Buy one, get one free!";

        public Messages Messages { get; set; }
        public ICommand AddMessageCommand { get; set; }

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            Messages = new Messages();

            this.WireUpCommands();
            this.WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.eventAggregator.GetEvent<CloseMessageEvent>().Subscribe(OnCloseMessageEvent);
        }

        public void OnCloseMessageEvent(Guid messageId)
        {
            var message = Messages.FirstOrDefault(m => m.Id == messageId);
            if (message == null) return;
            Messages.Remove(message);
        }

        private void WireUpCommands()
        {
            AddMessageCommand = new ActionCommand(() =>
            {
                var vm = Create();
                this.Messages.AddItem(vm);
            });
        }

        private MessageViewModel Create()
        {
            var guid = Guid.NewGuid();
            var numberOfMessageTypes = Enum.GetValues(typeof(MessageType)).Length;
            var random = new Random().Next(1, numberOfMessageTypes);
            var message = new Message(guid, Enum.GetName(typeof(MessageType), random), MESSAGE_TEXT, (MessageType)random);

            return new MessageViewModel(eventAggregator, message);
        }
    }
}
