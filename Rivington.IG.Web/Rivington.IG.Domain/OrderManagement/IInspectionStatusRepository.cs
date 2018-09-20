using Rivington.IG.Domain;
using Rivington.IG.Domain.Models.Dashboard;
using Rivington.IG.Domain.Models.OrderManagement;
using System.Linq;

namespace Rivington.IG.Domain.OrderManagement
{
    public interface IInspectionStatusRepository: IRepository<InspectionStatus>
    {
    }
}