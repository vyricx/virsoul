using System;
using DiscordRPC;
using DiscordRPC.Logging;

namespace VirSoul
{
    public class DiscordRpcService : IDisposable
    {
        // Replace with your Discord Application ID from https://discord.com/developers/applications
        private const string ApplicationId = "1472017605555650645";

        private DiscordRpcClient? _client;

        public void Initialize()
        {
            _client = new DiscordRpcClient(ApplicationId)
            {
                Logger = new ConsoleLogger(LogLevel.Warning)
            };

            _client.OnReady += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine($"Discord RPC ready for user {e.User.Username}");
            };

            _client.Initialize();
            SetPresence();
        }

        public void SetPresence(string details = "omg look at this super cute cat", string? state = null)
        {
            _client?.SetPresence(new RichPresence
            {
                Details = details,
                State = state ?? "its so freaking cute",
                Assets = new Assets
                {
                    LargeImageKey = "img_2106",
                    LargeImageText = "cat",
                    SmallImageKey = "img_2106",
                    SmallImageText = "cat"
                }
            });
        }

        public void Dispose()
        {
            if (_client != null)
            {
                _client.ClearPresence();
                _client.Dispose();
                _client = null;
            }
        }
    }
}
