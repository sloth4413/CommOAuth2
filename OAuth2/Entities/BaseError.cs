using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth2.Entities
{
    public abstract class BaseError
    {
        public abstract bool IsSuccess();
    }
}
