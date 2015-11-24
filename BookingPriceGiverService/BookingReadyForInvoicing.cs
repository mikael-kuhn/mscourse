using Infrastructure;

namespace BookingPriceGiverService
{
    public class BookingReadyForInvoicing : Event
    {
        public int Id  { get; set; }
    }
}
