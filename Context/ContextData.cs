using Aria.GameObjects.Entities.Player;
using Aria.Context.Window;
using Aria.Context.Settings;

namespace Aria.Context
{
    public static partial class ContextData
    {
        public static Window.Window Window { get; } = new Window.Window();
        public static Player? GlobalPlayer { get; private set; }
        public static Settings.Settings GlobalSettings { get; } = Settings.Settings.Instance;

        public static void SetPlayer(Player player)
        {
            GlobalPlayer = player;
        }
    }
}