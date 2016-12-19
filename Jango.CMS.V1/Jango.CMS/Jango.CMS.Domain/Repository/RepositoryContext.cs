using System;
using System.Collections.Generic;
using System.Threading;
using Jango.CMS.Domain.Aggregate;

namespace Jango.CMS.Domain.Repository
{
    public abstract class RepositoryContext:IRepositoryContext,IDisposable
    {
        private readonly ThreadLocal<Dictionary<Guid, object>> _localcreatedics =new ThreadLocal<Dictionary<Guid, object>>();
        private readonly ThreadLocal<Dictionary<Guid, object>> _localupdatedics =new ThreadLocal<Dictionary<Guid, object>>();
        private readonly ThreadLocal<Dictionary<Guid, object>> _localremovedics =new ThreadLocal<Dictionary<Guid, object>>();
        private readonly ThreadLocal<bool> _localcommitted = new ThreadLocal<bool>(() => false);

        public virtual void RegisterCreate<TAggregateRoot>(TAggregateRoot aggregateroot) where TAggregateRoot :class, IAggregateRoot
        {
            if (aggregateroot.Id.Equals(Guid.Empty))
                throw new ArgumentException("聚合根ID不能为空");
            if (_localcreatedics.Value.ContainsKey(aggregateroot.Id))
                throw new InvalidOperationException("新创建的领域对象已经存在在集合中");
            _localcreatedics.Value.Add(aggregateroot.Id, aggregateroot);
            _localcommitted.Value = false;
        }

        public abstract void RegisterCreateDTO<TDTO, TAggregateRoot>(TDTO tdto, Action<TDTO> processdto)where TAggregateRoot : class, IAggregateRoot;

        public virtual void RegisterUpdate<TAggregateRoot>(TAggregateRoot aggregateroot) where TAggregateRoot :class, IAggregateRoot
        {
            if (aggregateroot.Id.Equals(Guid.Empty))
                throw new ArgumentException("聚合根ID不能为空");
            if (_localupdatedics.Value.ContainsKey(aggregateroot.Id))
                throw new InvalidOperationException("更新的领域对象已经存在在集合中");
            if (_localremovedics.Value.ContainsKey(aggregateroot.Id))
                throw new InvalidOperationException("领域对象正在被删除，不能更新");
            _localupdatedics.Value.Add(aggregateroot.Id, aggregateroot);
            _localcommitted.Value = false;
        }

        public abstract void RegisterUpdateDTO<TDTO, TAggregateRoot>(TDTO tdto, Action<TDTO> processdto)where TAggregateRoot : class, IAggregateRoot;

        public virtual void RegisterRemove<TAggregateRoot>(TAggregateRoot aggregateroot, IEnumerable<object> objs) where TAggregateRoot :class, IAggregateRoot
        {
            if (aggregateroot.Id.Equals(Guid.Empty))
                throw new ArgumentException("聚合根ID不能为空");
            if (_localremovedics.Value.ContainsKey(aggregateroot.Id))
                throw new InvalidOperationException("删除的领域对象已经存在在集合中");
            if (_localupdatedics.Value.ContainsKey(aggregateroot.Id))
                throw new InvalidOperationException("领域对象正在被更新，不能删除");
            _localremovedics.Value.Add(aggregateroot.Id, aggregateroot);
            _localcommitted.Value = false;
        }

        public abstract void RegisterRemoveDTO<TDTO, TAggregateRoot>(TDTO tdto, Action<TDTO> processdto)where TAggregateRoot : class, IAggregateRoot;
        public Guid ContextID => Guid.NewGuid();

        public abstract void Commit();


        public bool Committed
        {
            get { return _localcommitted.Value; }
            set { _localcommitted.Value = value; }
        }

        public virtual void Dispose()
        {
            _localcreatedics.Dispose();
            _localupdatedics.Dispose();
            _localremovedics.Dispose();
            _localcommitted.Dispose();
        }

        public abstract void RollBack();
    }
}