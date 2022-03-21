using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Team12_Hand_in_2_Ladeskab
{
     class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
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
            
            rfidReader.RFIDHandleEvent += RfidDetected;
            door.DoorStateHandleEvent += DoorStateHandleEvent;

        }

        private void DoorStateHandleEvent(object sender, DoorEventArgs e)
        {
            switch (e.isDoorOpen)
            {
                case true:
                    _display.
                    break;
                case false:
                    display.
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
                        if (_charger.Connected())
                        {
                            _door.LockDoor();
                            _charger.StartCharge();
                            _oldId = id;
                            using (var writer = File.AppendText(logFile))
                            {
                                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                            }

                            Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                            _state = LadeskabState.Locked;
                        }
                        else
                        {
                            Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                        }

                        break;

                    case LadeskabState.DoorOpen:
                        // Ignore
                        break;

                    case LadeskabState.Locked:
                        // Check for correct ID
                        if (id == _oldId)
                        {
                            _charger.StopCharge();
                            _door.UnlockDoor();
                            using (var writer = File.AppendText(logFile))
                            {
                                writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                            }

                            Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                            _state = LadeskabState.Available;
                        }
                        else
                        {
                            Console.WriteLine("Forkert RFID tag");
                        }

                        break;
                }
            }
        }

    }
}

