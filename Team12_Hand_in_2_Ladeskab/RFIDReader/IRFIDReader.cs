using System;


    public class RFIDEventArgs : EventArgs
    {
        public int _ID { set; get; }
    }

    public interface IRFIDReader
    {
        // Event triggered on new current value
        event EventHandler<RFIDEventArgs> RFIDHandleEvent;

        void RFIDDetected(int id);
    }


