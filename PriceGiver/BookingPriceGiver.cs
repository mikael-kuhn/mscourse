using System.Collections.Generic;
using Gui;
using LogIt;

namespace PriceGiver
{
    public class BookingPriceGiver
    {
        public void AssignPrice(BookingReadyForInvoicing @event)
        {
            BookingPriced bookingPricedEvent = new BookingPriced
            {
                Id = @event.Id,
                Items = new List<BookingPriceItem>
                {
                    new BookingPriceItem { Text = "Studio Rent", Amount = 230 }
                }
            };
            Logger.Log("AssignPrice");
            // Go to a datastore and do stuff

            InvoiceCreator.InvoiceCreator creator = new InvoiceCreator.InvoiceCreator();
            creator.CreateInvoice(bookingPricedEvent);
        }
    }
}
