using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogIt;
using PriceGiver;

namespace Gui
{
    public class Controller
    {
        public void BookingReadyForInvoicing(int id)
        {
            Logger.Log("BookingReadyForInvoicing");

            BookingPriceGiver priceGiver = new BookingPriceGiver();
            priceGiver.AssignPrice(new BookingReadyForInvoicing { Id = id});
        }
    }
}
