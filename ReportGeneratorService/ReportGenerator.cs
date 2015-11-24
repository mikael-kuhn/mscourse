using Infrastructure;
using Newtonsoft.Json;

namespace ReportGeneratorService
{
    public class ReportGenerator : BaseService<InvoiceCreated>
    {
        public override void Handle(InvoiceCreated @event)
        {
            Logger.Log(JsonConvert.SerializeObject(@event));
            Events.Add(new InvoiceReportCreated { Id = @event.Id});
        }
    }
}
