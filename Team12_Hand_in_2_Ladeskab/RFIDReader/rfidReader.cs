using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
     class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDHandleEvent;

        private Random _random;
        public void RFIDDetected(int id)
        {
            id = _random.Next(1, 10);

        }


    }
}
