using System;
using Infrastructure;

namespace GuiApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gui");
            while (true)
            {
                string input = Console.ReadLine();
                int id = 0;
                if (int.TryParse(input, out id))
                {
                    MessageBroker broker = new MessageBroker();
                    broker.Write(new BookingReadyForInvoicing {Id = id});
                }
                else
                {
                    Console.WriteLine("Done");
                    Console.ReadKey();
                }
            }
        }
    }
}
