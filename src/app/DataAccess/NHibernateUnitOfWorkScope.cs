using System;
using NHibernate;
using NHibernate.Context;

namespace EmployeeCreateAC.DataAccess
{
    public class NHibernateUnitOfWorkScope : IUnitOfWorkScope
    {
        private readonly bool ownsSession;
        private ISessionFactory sessionFactory;
        private bool completeSucceeded;
        private readonly ISession session;

        public NHibernateUnitOfWorkScope(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            ownsSession = !CurrentSessionContext.HasBind(sessionFactory);
            if (ownsSession)
            {
                session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                return;
            }

            session = sessionFactory.GetCurrentSession();
        }

        public void Dispose()
        {
            try
            {
                if (!ownsSession) return;

                CurrentSessionContext.Unbind(sessionFactory);
                var tx = session.Transaction;
                if (ownsSession && !completeSucceeded && tx.IsActive && !tx.WasRolledBack)
                {
                    tx.Rollback();
                }
                //            session.Dispose();
            }
            catch (Exception ex)
            {
//                Log.Error("Error disposing session: ", ex);
                throw;
            }
        }

        public void Complete()
        {
            try
            {
                var tx = session.Transaction;
                if (!ownsSession || tx.WasRolledBack) return;

                if (tx.IsActive)
                {
                    tx.Commit();
                }
                completeSucceeded = true;
            }
            catch (Exception ex)
            {
//                Log.Error("Error disposing session: ", ex);
                throw;
            }
        }

        public void Rollback()
        {
            var tx = session.Transaction;
            if (tx.IsActive)
            {
                tx.Rollback();
            }
        }
    }
}