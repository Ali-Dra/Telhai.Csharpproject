using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelHai.CS.CsharpCourse.Services.Logging
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Exception = 3,
    }

    /// <summary>
    /// Logger
    /// </summary>
    /// singelton designed pattern 
    /// 
    public class Logger : ILogger 
    {
        private static Logger instance;
        private string logfilepath = "";
        private Logger()
        {

        }
        private Logger(string logfilepath)
        {
            this.logfilepath = logfilepath;
        }
        public static Logger getinstance(string path = "")
        {

            //first call of instance 
            if (Logger.instance == null)
            {
                if (string.IsNullOrEmpty(path))
                {
                    Logger.instance = new Logger();
                }
                else
                {
                    Logger.instance = new Logger(path);
                }
            }
            return instance;
        }
        public static Logger Instance
        {
            get
            {
                //first call of instance 
                if (Logger.instance == null)
                {
                    Logger.instance = new Logger();
                }
                return instance;


            }
        }

        public static void Log(String msg)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            Console.WriteLine(msg + ":" + formattedtime);
        }
        public static void Log(String msg, LogLevel level)
        {
            string formattedtime = DateTime.Now.ToString("yyyy/mm/dd :mm:ss,fff");
            string logTxt = $"{msg} : {level} :{formattedtime}";
            Console.WriteLine(msg + ":" + level++ + " " + formattedtime);
        }


    }
}
