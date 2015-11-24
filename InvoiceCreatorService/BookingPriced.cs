using System.Collections.Generic;
using Infrastructure;

namespace InvoiceCreatorService
{
    public class BookingPriced : Event
    {
        public int Id { get; set; }
        public IEnumerable<BookingPriceItem> Items { get; set; }
    }

    public class BookingPriceItem
    {
        public string Text { get; set; }
        public decimal Amount { get; set; }
    }
}
