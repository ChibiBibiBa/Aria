using Aria.Entities.Player;
using Aria.Enviroment.Window;
using Aria.Enviroment.Settings;

namespace Aria.Enviroment
{
    public static partial class Enviroment
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