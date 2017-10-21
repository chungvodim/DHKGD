using System;
using System.Collections.Generic;
using System.Text;

namespace Tearc.Entity
{
    public class BaseEntity
    {
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
