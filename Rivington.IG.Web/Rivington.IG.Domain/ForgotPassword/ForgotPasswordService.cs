using System;
using System.Collections.Generic;
using System.Text;
using Rivington.IG.Domain.Models;

namespace Rivington.IG.Domain
{
    public class ForgotPasswordService : IForgotPasswordService
    {
        private IForgotPasswordRepository ForgotPasswordRepository;
        public ForgotPasswordService(IForgotPasswordRepository ForgotPasswordRepository)
        {
            this.ForgotPasswordRepository = ForgotPasswordRepository;
        }

        public ForgotPassword Save(Guid id, ForgotPassword forgotPassword)
        {
            ForgotPassword result;
            forgotPassword.DateModified = DateTime.Now;
            result = ForgotPasswordRepository.Create(forgotPassword);
            return result;
        }
    }
}
