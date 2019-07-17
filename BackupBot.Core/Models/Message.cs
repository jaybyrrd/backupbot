using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Discord;
using Discord.WebSocket;

namespace BackupBot.Core.Models
{
    [Serializable]
    public class Message : IMsg
    {
        public string ChannelName { get; }
        
        public Author MsgAuthor { get; }

        public string Content { get; }

        public DateTime CreatedAt { get; }

        public bool IsPinned { get; }

        public IList<object> MessageTags { get; }

        public string MessageUrl { get; }

        public Message(SocketMessage message)
        {
            ChannelName = message.Channel.Name;
            MsgAuthor = new Author(message.Author.Id, message.Author.Username);
            Content = message.Content;
            CreatedAt = message.CreatedAt.DateTime;
            IsPinned = message.IsPinned;

            MessageTags = new List<object>();

            foreach (var messageTag in message.Tags)
            {
                MessageTags.Add(messageTag);
            }

            MessageUrl = message.GetJumpUrl();
        }
    }
}
