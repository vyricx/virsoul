using System.Windows;

namespace VirSoul
{
    public partial class MainWindow : Window
    {
        private readonly DiscordRpcService _discordRpc = new();

        public MainWindow()
        {
            InitializeComponent();
            _discordRpc.Initialize();
            Closed += OnWindowClosed;
        }

        private void OnWindowClosed(object? sender, System.EventArgs e)
        {
            _discordRpc.Dispose();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
