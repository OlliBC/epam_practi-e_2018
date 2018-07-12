using System;
using System.IO;
using System.Text;

namespace BLL.Logging
{
    public class Logging
    {
        public void WriteLoggingInFile(string text)
        {
            using (StreamWriter file = new StreamWriter("Logging.txt", true, Encoding.Default))
            {
                file.WriteLine($"{text} : {DateTime.Now}");

                file.Close();
            }
        }
    }
}
