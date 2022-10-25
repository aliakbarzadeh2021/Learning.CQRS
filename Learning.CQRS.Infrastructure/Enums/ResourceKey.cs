using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CQRS.Infrastructure.Enums
{
    public enum ResourceKey
    {
        ValueCannotBeNull,
        InputLenghtIsNotInRange,
        ObjectHasBeenRegistered,
        ObjectCanNotBeRemoved,
        ObjectCanNotBeUpdated,
        ObjectCanNotBeFind,
        UserNameIsDuplicate,
        InvalidUserNameOrPassword,
        IsDuplicate,
        InvalidValue,
        Unknown
    }
}
