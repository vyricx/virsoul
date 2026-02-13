using System;
using DiscordRPC;
using DiscordRPC.Logging;

namespace VirSoul
{
    public class DiscordRpcService : IDisposable
    {
        // Replace with your Discord Application ID from https://discord.com/developers/applications
        private const string ApplicationId = "YOUR_APPLICATION_ID";

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

        public void SetPresence(string details = "Running VirSoul", string state = "")
        {
            _client?.SetPresence(new RichPresence
            {
                Details = details,
                State = state,
                Timestamps = Timestamps.Now,
                Assets = new Assets
                {
                    LargeImageKey = "logo",
                    LargeImageText = "VirSoul"
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
