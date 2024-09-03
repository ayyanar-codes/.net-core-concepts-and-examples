namespace dependency_injection_example.Services.Log
{
    public class DefaultLog : ILog
    {
        public void Info(string sMessage)
        {
            Console.WriteLine(sMessage);
        }
    }
}
