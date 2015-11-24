using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCreator
{
    public class InvoiceCreated
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
