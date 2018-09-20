using Rivington.IG.Domain;
using Rivington.IG.Domain.Models;
using System;

namespace Rivington.IG.Infrastructure.Persistence.Repositories
{
    public class ForgotPasswordRepository : RepositoryBase<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(IRivingtonContext context)
            : base(context)
        {

        }
        public bool CheckIfForgotPasswordIdExist(Guid id)
        {
            return Retrieve(id) != null;
        }
    }
}
