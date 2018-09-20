using System;
using Rivington.IG.Domain.Models.OrderManagement;

namespace Rivington.IG.Domain
{
    public class UtilityService : IUtilityService
    {
        private IUtilityRepository _utilityRepository;
        
        public UtilityService(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }
    }
}