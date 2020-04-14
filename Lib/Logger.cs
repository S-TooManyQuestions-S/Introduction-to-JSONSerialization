using System;
using System.IO;

namespace Lib
{
    public class Logger
    {
        /// <summary>
        /// Метод для логгирования данных.
        /// </summary>
        /// <param name="massage">лог-сообщение</param>
        public static void Log(string massage)
        {
            Console.WriteLine(massage);
            
            File.AppendAllText("log.txt", "[" + DateTime.Now + "]" + "  " + massage + Environment.NewLine);
        }

        /// <summary>
        /// Метод логирования без вывода в консоль
        /// </summary>
        /// <param name="massage">лог-сообщение</param>
        public static void LogWC(string massage)
        {
            File.AppendAllText("log.txt", "[" + DateTime.Now + "]" + "  " + massage + Environment.NewLine); 
        }
    }
}