using Aria.GameObjects.Entities.Player;

namespace Aria.Context
{
    public static partial class ContextData
    {
        public static Window Window { get; } = new Window();
        public static Player? GlobalPlayer { get; private set; }
        public static Settings GlobalSettings { get; } = Settings.Instance;

        public static void SetPlayer(Player player)
        {
            GlobalPlayer = player;
        }
    }
}