using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODI.DataLayer.Common
{
    public   enum ResponseStatus
    {
        Created = 201,
        Deleted,
        Updated,
        Success,
        DataBaseException,
        CodeException,
        AlreadyExists
    }
}
