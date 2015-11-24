using System.Collections.Generic;
using Infrastructure;
using Newtonsoft.Json;


namespace BookingPriceGiverService
{
    public class BookingPriceGiver : BaseService<BookingReadyForInvoicing>
    {
        public override void Handle(BookingReadyForInvoicing @event)
        {
            Logger.Log(JsonConvert.SerializeObject(@event));

            BookingPriced bookingPricedEvent = new BookingPriced
            {
                Id = @event.Id,
                Items = new List<BookingPriceItem>
                {
                    new BookingPriceItem { Text = "Studio Rent", Amount = 230 }
                }
            };
            // Go to a datastore and do stuff

            Events.Add(bookingPricedEvent);
        }
    }
}
