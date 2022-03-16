using System;


    public class RFIDEventArgs : EventArgs
    {
        public bool reader { set; get; }
    }

    public interface IRFIDReader
    {
        // Event triggered on new current value
        event EventHandler<RFIDEventArgs> RFIDHandleEvent;

        void RFIDdetected(int id);
    }


