using Rivington.IG.Domain.Models;
using System;

namespace Rivington.IG.Domain
{
    public interface IForgotPasswordRepository : IRepository<ForgotPassword>
    {
        bool CheckIfForgotPasswordIdExist(Guid id);
    }
}