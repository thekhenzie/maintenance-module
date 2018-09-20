using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rivington.IG.Domain.Models.Dashboard
{
    public class MitigationStatusCountView
    {
        public MitigationStatusCountView()
        {

        }

        [Key]
        public string StatusId { get; set; }
        public string Status { get; set; }
        public int StatusCount { get; set; }
    }
}
