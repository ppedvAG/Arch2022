namespace HalloSingelton
{
    public class Logger
    {
        private static Logger? _instance;

        private static object _lock = new object();

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Console.WriteLine("Neue Logger instanz");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:d} {DateTime.Now:t}: {msg}");
        }
    }
}
