using System;

namespace Team12_Hand_in_2_Ladeskab
{

    public class RFIDEventArgs : EventArgs
    {
        public int _ID { set; get; }
    }

    public interface IRFIDReader
    {
        // Event triggered on new current value
        event EventHandler<RFIDEventArgs> RFIDHandleEvent; //Connectionpoint for observers

        void RFIDValue(int id);
    }
}


