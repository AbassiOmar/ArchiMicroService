using Invocie.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Invocie.Core.Contratcs.Infra
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
