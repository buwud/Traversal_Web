namespace Traversal
{
    public class LogClass
    {
        public static void ConfigureLogging(ILoggingBuilder logging)
        {
            logging.ClearProviders();
            logging.AddFile("logs/app-{Date}.txt");
        }
    }
}
