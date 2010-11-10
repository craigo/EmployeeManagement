using System;
using System.Collections;
using NHibernate.Context;
using NHibernate.Engine;

namespace EmployeeCreateAC
{
    public class EmployeeCreateACSessionContext : MapBasedSessionContext
    {
        [ThreadStatic] private static IDictionary map;

        public EmployeeCreateACSessionContext(ISessionFactoryImplementor factory) : base(factory)
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