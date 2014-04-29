using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MirthDotNet.Model
{
    public enum MetaDataSearchOperator
    {
        EQUAL,
        NOT_EQUAL,
        LESS_THAN,
        LESS_THAN_OR_EQUAL,
        GREATER_THAN,
        GREATER_THAN_OR_EQUAL,
        CONTAINS,
        STARTS_WITH,
        ENDS_WITH,
    }
}
