using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
