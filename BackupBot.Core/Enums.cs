﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BackupBot.Core
{
    public class Enums
    {
        [Flags]
        public enum UserRights
        {
            Mvp = 0,
            Mod = 1,
            Admin = 2
        }
    }
}
