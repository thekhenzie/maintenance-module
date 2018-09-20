using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rivington.IG.Domain.Models.Dashboard
{
    public class InspectionStatusGroupingsView
    {
        public InspectionStatusGroupingsView()
        {

        }

        [Key]
        public string StatusId { get; set; }
        public string Status { get; set; }
        public int ZeroToNineteenDays { get; set; }
        public int TwentyToThirtyNineDays { get; set; }
        public int FortyToFiftyNineDays { get; set; }
    }
}
