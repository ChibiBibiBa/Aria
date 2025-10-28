namespace Aria.Enviroment.Settings
{
    public class Settings
    {
        private static Settings? _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                }
                return _instance;
            }
        }
    }

}