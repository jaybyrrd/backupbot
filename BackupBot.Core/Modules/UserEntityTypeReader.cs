using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackupBot.Models;
using Discord;
using Discord.Commands;

namespace BackupBot.Core.Modules
{
    public class UserEntityTypeReader : UserTypeReader<IGuildUser>
    {
        public override async Task<TypeReaderResult> ReadAsync(ICommandContext context, string input, IServiceProvider services)
        {
            var baseResult = await base.ReadAsync(context, input, services);

            if (baseResult.IsSuccess)
                return TypeReaderResult.FromSuccess(User.FromIUser(baseResult.BestMatch as IUser));

            if (!ulong.TryParse(input, out var uid) && !MentionUtils.TryParseUser(input, out uid))
                return TypeReaderResult.FromError(CommandError.ParseFailed, "Could not find user / parse user ID");

            if (!IsUserIdValid(uid))
                return TypeReaderResult.FromError(CommandError.ParseFailed, "UserID is invalid.");
                    
            return TypeReaderResult.FromSuccess(new User(uid));
        }

        private static bool IsUserIdValid(ulong id)
        {
            var snowflakeTimestamp = (long)(id >> 22);
            const long discordEpochUnixTime = 1420070400000;

            var discordEpoch = DateTimeOffset.FromUnixTimeMilliseconds(discordEpochUnixTime);
            var snowFlakeDateTime = DateTimeOffset.FromUnixTimeMilliseconds(snowflakeTimestamp + discordEpochUnixTime);

            return snowFlakeDateTime >= discordEpoch && snowFlakeDateTime <= DateTimeOffset.UtcNow;
        }
    }
}
