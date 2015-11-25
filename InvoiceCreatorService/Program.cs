using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace InvoiceCreatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("InvoiceCreator");

            Runner.Run<BookingPriced, InvoiceCreator>(new MessageBroker());
        }
    }
}
