using Rivington.IG.Domain.Models.OrderManagement;
using System;

namespace Rivington.IG.Domain
{
    public interface IPolicyService
    {
        Policy Save(Guid id, Policy policy);
    }
}