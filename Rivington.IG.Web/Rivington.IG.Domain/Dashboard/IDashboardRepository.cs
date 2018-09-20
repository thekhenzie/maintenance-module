using Rivington.IG.Domain.Models.Dashboard;
using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rivington.IG.Domain.Dashboard
{
    public interface IDashboardRepository : IRepository<InspectionStatusGroupingsView>
    {
        IQueryable<InspectionStatusGroupingsView> Retrieve(string Inspector);
        IQueryable<MitigationStatusCountView> RetrieveMitigationStatusCount(string Inspector);
        int RetrieveSentToInsuredStatusCount(string Inspector);
    }
}

