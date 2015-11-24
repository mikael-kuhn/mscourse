using System;
using Infrastructure;

namespace BookingPriceGiverService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BookingPriceGiver");

            Runner.Run<BookingReadyForInvoicing, BookingPriceGiver>();
        }
    }
}
