using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ladeskab_Class_Library
{
     public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private IRFIDReader _reader;
        private IDisplay _display;
        private LogFile _log;

        
        private string logFile = "logfile.txt"; // Navnet på systemets log-fil
        
        public StationControl(IRFIDReader rfidReader, IDoor door, IDisplay display, IChargeControl chargeControl, LogFile logFile )
        {
            _reader = rfidReader;
            _door = door;
            _display = display;
            _charger = chargeControl;
            _log = logFile;
            
            _reader.RFIDHandleEvent += RfidDetected;
            door.DoorStateHandleEvent += DoorStateHandleEvent;

        }

        private void DoorStateHandleEvent(object sender, DoorEventArgs e)
        {
            switch (e.isDoorOpen)
            {
                case true:
                    _display.ViewConnectPhone();
                    break;
                case false:
                    _display.ViewReadID();
                    break;
            }
        }


        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(object s, RFIDEventArgs e)
        {
            if (_door.lockState == false && _door.doorState == false)
            {
                
                switch (_state)
                {
                    case LadeskabState.Available:
                        // Check for ladeforbindelse
                        if (_charger.Connected)
                        {
                            _door.LockDoor();
                            _charger.StartCharge();
                            _oldId = e._ID;
                           
                            
                            _state = LadeskabState.Locked;
                            _log.LogDoorLocked(_oldId);
                            _display.ViewLockDoor();
                        }
                        else
                        {
                            _display.ViewFailedConnection();
                        }

                        break;

                    case LadeskabState.DoorOpen:
                        // Ignore
                        break;

                    case LadeskabState.Locked:
                        // Check for correct ID
                        if (e._ID == _oldId)
                        {
                            _charger.StopCharge();
                            _door.UnlockDoor();
                            _log.LogDoorUnlocked(_oldId);

                            _display.ViewRemovePhone();
                            _state = LadeskabState.Available;
                        }
                        else
                        {
                            _display.ViewFailRFID();
                        }

                        break;
                }
            }
        }

    }
}

