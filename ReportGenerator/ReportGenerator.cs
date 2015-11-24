using InvoiceCreator;
using LogIt;

namespace ReportGenerator
{
    public class ReportGenerator
    {
        public void GenerateReport(InvoiceCreated @event)
        {
            Logger.Log("GenerateReport");

        }
    }
}
