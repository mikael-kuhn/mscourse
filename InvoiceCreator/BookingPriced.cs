using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceGiver
{
    public class BookingPriced
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
