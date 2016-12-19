
using System;
using System.Collections.Generic;
using Jango.CMS.Domain.Repository;

namespace Jango.CMS.Repository
{
//    public class EFRepositoryContext:RepositoryContext
//    {
//        protected readonly SalesOrdersModelContainer orderdbcontext =SalesOrderDBContextFactory.Create();
//        public DbContext SalesOrderDBContext { get { return orderdbcontext; } }
//        public override void RegisterCreate<TAggreateRoot>(TAggreateRoot aggreateroot)
//        {
//            orderdbcontext.Set<TAggreateRoot>().Add(aggreateroot);
//            Committed = false;
//        }
//        public override void RegisterCreateDTO<TDTO, TAggreateRoot>(TDTO tdto
//            , Action<TDTO> processdto)
//        {
//            if (processdto != null)
//                processdto(tdto);
//            var aggreateroot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
//            RegisterCreate(aggreateroot);
//        }
//
//        public override void RegisterUpdate<TAggreateRoot>(TAggreateRoot aggreateroot)
//        {
//            orderdbcontext.Entry<TAggreateRoot>(aggreateroot).State =
//                System.Data.Entity.EntityState.Modified;
//            Committed = false;
//        }
//
//        public override void RegisterUpdateDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> processdto)
//        {
//            if (processdto != null)
//                processdto(tdto);
//            var aggreateroot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
//            RegisterUpdate(aggreateroot);
//        }
//
//        public override void RegisterRemove<TAggreateRoot>(TAggreateRoot aggreateroot
//            , IEnumerable<object> objs)
//        {
//            orderdbcontext.Set<TAggreateRoot>().Remove(aggreateroot);
//            foreach(var obj in objs)
//            {
//                orderdbcontext.Entry(obj).State =
//                    System.Data.Entity.EntityState.Deleted;
//            }
//            Committed = false;
//        }
//
//        public override void RegisterRemoveDTO<TDTO, TAggreateRoot>(TDTO tdto, Action<TDTO> processdto)
//        {
//            if (processdto != null)
//                processdto(tdto);
//            var aggreateroot = Mapper.Map<TDTO, TAggreateRoot>(tdto);
//            //RegisterRemove(aggreateroot);
//        }
//
//        public override void Commit()
//        {
//            if (!Committed)
//                orderdbcontext.SaveChanges();
//            Committed = true;
//
//        }
//
//        public override void RollBack()
//        {
//            Committed = false;
//        }
//
//        public override void Dispose()
//        {
//            if (!Committed)
//                Commit();
//            orderdbcontext.Dispose();
//            orderdbcontext.Dispose();
//            base.Dispose();
//        }
//    }
}