using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ladeskab_Class_Library
{
    public class LogFile
    {
        private rfidReader id;
        string docPath=Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //virker måske

        public string log { get; set; }


     
        public void LogDoorLocked(int id)
        {
            log = DateTime.Now + ": Box locked with RFID: " + id;
            WriteToFile(log);

        }

        public void LogDoorUnlocked(int id)
        {
            log = DateTime.Now + ": Box unlocked with RFID: " + id;
            WriteToFile(log);

        }
        public void WriteToFile(string line)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "LogFile.txt")))
            {
                outputFile.WriteLine(line);
            }

        }
    }
}
