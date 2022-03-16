using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
    class LogFile
    {
        private rfidReader id;

        //FileStream output = new FileStream()

        public LogFile(int LogID)
        {
           id.RFIDdetected(LogID);
        }

        public void LogDoorLocked(int id)
        {
            int lines = id;

          //  await File.WriteAllLinesAsync("WriteLines.txt", id);
        }

        public void LogDoorUnlocked(int id)
        {

        }
    }
}
