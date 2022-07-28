using System;
using System.Collections.Generic;
using System.Text;

namespace Invocie.Core.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string name, object key)
             : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
