using System;

namespace Jango.CMS.Domain.Aggregate
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}