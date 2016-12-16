using System;
using System.Collections.Generic;
using Jango.CMS.Domain.Aggregate;

namespace Jango.CMS.Domain.Repository
{
    public interface IRepositoryContext:IUnitOfWork,IDisposable
    {
        void RegisterCreate<TAggreateRoot>(TAggreateRoot aggreateroot) where TAggreateRoot :class, IAggregateRoot;
        void RegisterCreateDTO<TDTO,TAggreateRoot>(TDTO tdto,Action<TDTO> processdto) where TAggreateRoot :  class, IAggregateRoot;
        void RegisterUpdate<TAggreateRoot>(TAggreateRoot aggreateroot) where TAggreateRoot : class, IAggregateRoot;
        void RegisterUpdateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> processdto) where TAggreateRoot : class, IAggregateRoot;
        void RegisterRemove<TAggreateRoot>(TAggreateRoot aggreateroot , IEnumerable<object> objs) where TAggreateRoot : class, IAggregateRoot;
        void RegisterRemoveDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> processdto) where TAggreateRoot : class, IAggregateRoot;
        Guid ContextID { get; }
    }
}