using System.Collections.Generic;
using Infrastructure;

namespace InvoiceCreatorService
{
    public class InvoiceCreated : Event
    {
        public int Id { get; set; }
        public IEnumerable<InvoiceLine> Lines { get; set; }
    }

    public class InvoiceLine
    {
        public decimal Amount { get; set; }
        public string Text { get; set; }
    }
}
