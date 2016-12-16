using System;

namespace Jango.CMS.Domain.Aggregate
{
    public interface IValueObject
    {
        Guid Id { get; }
    }
}