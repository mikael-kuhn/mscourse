using System.Linq;
using PriceGiver;
using LogIt;

namespace InvoiceCreator
{
    public class InvoiceCreator
    {
        public void CreateInvoice(BookingPriced @event)
        {
            Logger.Log("CreateInvoice");


            InvoiceCreated invoiceCreated = new InvoiceCreated
            {
                Id = 1,
                Lines = @event.Items.Select(i => new InvoiceLine {Amount = i.Amount, Text = i.Text})
            };


            ReportGenerator.ReportGenerator generator = new ReportGenerator.ReportGenerator();
            generator.GenerateReport(invoiceCreated);
        }
    }
}
