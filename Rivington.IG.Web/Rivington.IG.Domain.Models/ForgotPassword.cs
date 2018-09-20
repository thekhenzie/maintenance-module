using System;
using System.ComponentModel.DataAnnotations;

namespace Rivington.IG.Domain.Models
{
    public class ForgotPassword
    {
        [Key]
        public Guid ForgotID { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateModified { get; set; }
    }
}
