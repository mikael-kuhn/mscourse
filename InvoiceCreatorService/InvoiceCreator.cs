using System.Linq;
using Infrastructure;
using Newtonsoft.Json;

namespace InvoiceCreatorService
{
    public class InvoiceCreator : BaseService<BookingPriced>
    {
        public override void Handle(BookingPriced @event)
        {
            Logger.Log(JsonConvert.SerializeObject(@event));


            InvoiceCreated invoiceCreated = new InvoiceCreated
            {
                Id = 1,
                Lines = @event.Items.Select(i => new InvoiceLine {Amount = i.Amount, Text = i.Text})
            };

            Events.Add(invoiceCreated);
        }
    }
}
