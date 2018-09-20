using System;
using System.Collections.Generic;
using System.Text;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain.InspectionNotes
{
    public class InspectionOrderNotesService : IInspectionOrderNotesService
    {
        public IInspectionOrderNotesRepository inspectionOrderNotesRepository;
        public InspectionOrderNotesService(IInspectionOrderNotesRepository inspectionOrderNotesRepository)
        {
            this.inspectionOrderNotesRepository = inspectionOrderNotesRepository;
        }
        
    }
}
