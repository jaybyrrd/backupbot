﻿using System;
using System.Collections.Generic;

namespace BackupBot.Models
{
    public interface IMsg
    {
        string ChannelName { get; }

        Author MsgAuthor { get; }

        string Content { get; }

        DateTime CreatedAt { get; }

        bool IsPinned { get; }

        IList<object> MessageTags { get; }

        string MessageUrl { get; }
    }
}