using Infrastructure;

namespace GuiApplication
{
    public class Controller
    {
        public void BookingReadyForInvoicing(int id)
        {
            Logger.Log("BookingReadyForInvoicing");

            /*BookingPriceGiver priceGiver = new BookingPriceGiver();
            priceGiver.AssignPrice(new BookingReadyForInvoicing { Id = id});*/
        }
    }
}
