using System;
using System.Collections.Generic;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
     class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDHandleEvent; //Connectionspoint

        private Random _random;
        public void RFIDValue(int id)
        {
            id = _random.Next(1, 10);

            OnRFIDHandle(new RFIDEventArgs(){_ID = id});
            

        }

        private void OnRFIDHandle(RFIDEventArgs e)
        {
            RFIDHandleEvent?.Invoke(this, e);
        }


    }
}
