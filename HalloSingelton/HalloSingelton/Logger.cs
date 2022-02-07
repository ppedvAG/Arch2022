namespace HalloSingelton
{
    public class Logger
    {
        private static Logger? _instance;

        private static readonly object _lock = new();


        public static Logger Instance
        {
            get
            {
                lock (_lock)
                    return _instance ??= new Logger();
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
