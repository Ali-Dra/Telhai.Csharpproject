namespace TelHai.CS.CsharpCourse.Services.Logging
{
    public interface ILogger
    {
     
        static abstract void Log(string msg);
        static abstract void Log(string msg, LogLevel level);
    }
}