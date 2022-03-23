using System;
using Team12_Hand_in_2_Ladeskab;

public class Program
{
    public static void Main()
    {
        // Assemble your system here from all the classes

        bool finish = false;
        IDoor _door = new Door();
        IRFIDReader rfidReader = new rfidReader();
        USBCharger _charger = new USBCharger();
        IDisplay _display = new Display();
        IChargeControl _chargecontrol = new ChargeControl(_charger, _display);


        System.Console.WriteLine("Options: e(Exit), o(Open door), c (Close door), p(Plug phone) r(Read RFID): \n Open door. ");


        do
        {
            string input;
            
            
            input = Console.ReadLine();
           

            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'e':
                case 'E':
                    finish = true;
                    break;

                case 'o':
                case 'O':
                    _door.OnDoorOpen();
                    Console.WriteLine("Plug phone.");
                    break;
                case 'p':
                case 'P':

                    _charger.SimulateConnected(true);
                    Console.WriteLine("Close door.");
                    break;

                case 'c':
                case 'C':
                    _door.OnDoorClosed();
                    Console.WriteLine("Read RFID");
                    break;

                case 'r':
                case 'R':
                    
                    System.Console.WriteLine("Type RFID id: ");
                    string idString = System.Console.ReadLine();
                    int id = Convert.ToInt32(idString);
                    rfidReader.RFIDValue(id);
                    
                    break;

                default:
                    break;
            }

        } while (!finish);
    }
}
