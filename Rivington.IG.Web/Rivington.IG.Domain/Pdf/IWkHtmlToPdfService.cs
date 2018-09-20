using System;
using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain.Pdf
{
    public interface IWkHtmlToPdfService
    {
	    byte[] GeneratePdf(Guid id, string webHost);
    }
}