using System;
using Infrastructure;

namespace ReportGeneratorService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReportGenerator");

            Runner.Run<InvoiceCreated, ReportGenerator>(new MessageBroker());
        }
    }
}
