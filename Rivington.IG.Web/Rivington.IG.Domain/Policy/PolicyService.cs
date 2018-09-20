using Rivington.IG.Domain.Models.OrderManagement;
using Rivington.IG.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain
{
    public class PolicyService : IPolicyService
    {
        public IPolicyRepository policyRepository;
        public PolicyService(IPolicyRepository policyRepository)
        {
            this.policyRepository = policyRepository;
        }
        public Policy Save(Guid id, Policy policy)
        {
            Policy result = null;
            var existing = policyRepository.Retrieve(id);
            if (existing == null)
            {
                result = policyRepository.Create(policy);
            }
            else
            {
                result = policyRepository.Update(id, policy);
            }
            return result;
        }
    }
}
