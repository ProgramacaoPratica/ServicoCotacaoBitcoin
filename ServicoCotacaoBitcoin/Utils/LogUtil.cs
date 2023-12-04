using System;
using System.IO;

namespace ServicoCotacaoBitcoin.Utils
{
    public static class LogUtil
    {
        public static void WriteToFile(string message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Logs";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = path + $@"\ServiceLog_{DateTime.Now.Date.ToString("dd_MM_yyyy")}";

            using (StreamWriter sw = File.AppendText(filePath))
                sw.WriteLine(message);
        }
    }
}
