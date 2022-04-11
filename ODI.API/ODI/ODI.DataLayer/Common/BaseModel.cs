using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Common
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
         
    }
}
