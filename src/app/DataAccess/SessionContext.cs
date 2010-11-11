using System;
using System.Collections;
using NHibernate.Context;
using NHibernate.Engine;

namespace EmployeeCreateAC.DataAccess
{
    public class SessionContext : MapBasedSessionContext
    {
        [ThreadStatic] private static IDictionary map;

        public SessionContext(ISessionFactoryImplementor factory) : base(factory)
        {}

        protected override IDictionary GetMap()
        {
            return map;
        }

        protected override void SetMap(IDictionary value)
        {
            map = value;
        }
    }
}