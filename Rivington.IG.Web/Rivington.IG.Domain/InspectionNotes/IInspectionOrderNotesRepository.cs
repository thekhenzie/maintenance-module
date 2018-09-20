using ART.DynamicLinq;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Domain.InspectionNotes
{
    public interface IInspectionOrderNotesRepository : IRepository<InspectionOrderNote>
    {
        RetrieveResult<InspectionOrderNotesView> RetrieveView(DataSourceRequest request, Guid orderId);
        void CreateOrUpdate(InspectionOrderNote ent);
    }
}
