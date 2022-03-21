using System;
using Team12_Hand_in_2_Ladeskab;

class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes

        bool finish = false;
        IDoor _door = null;
        IRFIDReader rfidReader = new rfidReader();


        do
        {
            string input;
            System.Console.WriteLine("Indtast E, O, C, R: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            switch (input[0])
            {
                case 'E':
                    finish = true;
                    break;

                case 'O':
                    _door.OnDoorOpen();
                    break;

                case 'C':
                    _door.OnDoorClosed();
                    break;

                case 'R':
                    System.Console.WriteLine("Indtast RFID id: ");
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
}