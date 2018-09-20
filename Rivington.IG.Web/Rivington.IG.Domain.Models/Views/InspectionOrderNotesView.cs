using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.Views
{
    [Table("vwInspectionOrderNotesList")]
    public class InspectionOrderNotesView
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateModified { get; set; }
        public string Notes { get; set; }
        public string Subject { get; set; }
        public string UserName { get; set; }
        public string ModifiedBy { get; set; }
        public Guid InspectionOrderId { get; set; }
    }
}
