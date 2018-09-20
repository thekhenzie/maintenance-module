using Rivington.IG.Domain.Models.InspectionOrderLog;
using Rivington.IG.Domain.Models.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rivington.IG.Domain.InspectionOrderLog
{
    public interface IInspectionOrderLog : IRepository<InspectionOrderLogs>
    {
        void SaveIOLog(string Action, string ActionDescription, Guid id);
        Task<InspectionOrder> RetrieveIO(Guid id);
        void UpdateInspectionOrder(InspectionOrder ent);
        IQueryable<InspectionOrderLogs> GetIOLogs(Guid id);
    }
}
