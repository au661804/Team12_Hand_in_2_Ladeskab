using System;
using Team12_Hand_in_2_Ladeskab;

class Program
{
    static void Main(string[] args)
    {
        // Assemble your system here from all the classes

        bool finish = false;
        IDoor _door = new Door();
        IRFIDReader rfidReader = new rfidReader();



        do
        {
            string input;
            System.Console.WriteLine("Indtast e, o, c, r: ");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;

            switch (input[0])
            {
                case 'e':
                    finish = true;
                    break;

                case 'o':
                    _door.OnDoorOpen();
                    break;

                case 'c':
                    _door.OnDoorClosed();
                    break;

                case 'r':
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
