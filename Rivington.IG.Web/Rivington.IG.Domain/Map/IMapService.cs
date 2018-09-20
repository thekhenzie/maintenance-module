using Rivington.IG.Domain.Models;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain
{
    public interface IMapService
    {
        TempPolicy GetAddressGeocode(TempPolicy addresss);
        Policy GetAddressGeocode(Policy policy);
    }
}