using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaminEducationClone.Domain.Commons
{
    public class BaseResponse<T>
    {
        public T Data;
        public ErrorModel Error;
    }
}
