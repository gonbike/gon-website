using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Jango.CMS.Domain.Aggregate;

namespace Jango.CMS.Domain.Repository
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot:class ,IAggregateRoot
    {
        void Create(TAggregateRoot aggregateRoot);
        void Create<TDTO>(TDTO tdto);
        TAggregateRoot GetByID(Guid guid);
        TDTO GetByID<TDTO>(Guid guid);
        
        List<TAggregateRoot> GetByCondition(Expression<Func<TAggregateRoot, bool>> condition,
            Expression<Func<TAggregateRoot,bool>> definecondition);
        List<TAggregateRoot> GetByConditionPages(Expression<Func<TAggregateRoot, bool>> condition,
            Expression<Func<TAggregateRoot, bool>> definecondition,
            RequestPage request, out int totalcount);
        List<TAggregateRoot> GetByConditionPages(List<Jango.CMS.Infrastructure.LamdaFilterConvert.Conditions>condition, Expression<Func<TAggregateRoot, bool>> definecondition,
            RequestPage request, out int totalcount);
        List<TDTO> GetByCondition<TDTO>(Expression<Func<TAggregateRoot, bool>> condition,
            Expression<Func<TAggregateRoot, bool>> definecondition);
        List<TDTO> GetByConditionPages<TDTO>(Expression<Func<TAggregateRoot, bool>> condition,
            Expression<Func<TAggregateRoot, bool>> definecondition,
            RequestPage request, out int totalcount);
        List<TDTO> GetByConditionPages<TDTO>(List<List<Jango.CMS.Infrastructure.LamdaFilterConvert.Conditions>> condition, Expression<Func<TAggregateRoot, bool>> definecondition,
            RequestPage request, out int totalcount);


        void Update(TAggregateRoot aggreateroot);
        void Update<TDTO>(TDTO tdto);
        void Remove(TAggregateRoot aggreateroot, IEnumerable<object> objs);
        void Remove<TDTO>(TDTO tdto);
        void RemoveByID(Guid id);

        void Remove(TAggregateRoot aggreateroot);

    }
}