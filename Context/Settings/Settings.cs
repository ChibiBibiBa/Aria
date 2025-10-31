namespace Aria.Context.Settings
{
    public class Settings
    {
        private static Settings instance = new Settings();

        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }

        }

        private Settings() { }
    }
}