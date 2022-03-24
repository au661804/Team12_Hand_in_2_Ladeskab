using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab_Class_Library
{
    public class rfidReader : IRFIDReader
    {
        public event EventHandler<RFIDEventArgs> RFIDHandleEvent; //Connectionspoint

        
        public void RFIDValue(int id)
        {
            
            OnRFIDHandle(new RFIDEventArgs(){_ID = id});
            

        }

        private void OnRFIDHandle(RFIDEventArgs e)
        {
            RFIDHandleEvent?.Invoke(this, e); 
        }

       
        

    }
}
