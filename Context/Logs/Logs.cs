namespace Aria.Context.Logs
{
    public class Logs
    {
        private static Logs? _instance;
        public static Logs Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logs();
                }
                return _instance;
            }
        }
    }
}