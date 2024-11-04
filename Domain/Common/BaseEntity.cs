using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? LastModified { get; private set; }
        public string LastModifiedBy { get; private set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;
        }
    }
}
