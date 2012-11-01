
using System;

namespace MessageUI.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public MessageType MessageType { get; set; }

        public Message(Guid id, string title, string text, MessageType messageType)
        {
            this.Id = id;
            this.Title = title;
            this.Text = text;
            this.MessageType = messageType;
        }
    }
}
