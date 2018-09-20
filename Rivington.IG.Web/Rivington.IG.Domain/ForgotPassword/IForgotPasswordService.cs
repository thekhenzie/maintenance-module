using System;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.Domain
{
    public interface IForgotPasswordService
    {
        ForgotPassword Save(Guid id, ForgotPassword forgotPassword);
    }
}