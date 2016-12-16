using System;
using Jango.CMS.Domain.Aggregate;

namespace Jango.CMS.Domain.Model
{
    public class ValueObject:IValueObject
    {
        public Guid Id
        {
            get
            {
                var id = Guid.NewGuid();
                return id;
            }
        }
    }
}