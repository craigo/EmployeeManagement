using System;
using NHibernate;
using NHibernate.Context;

namespace EmployeeCreateAC
{
    public static class UnitOfWork
    {
        public static IUnitOfWorkScope Start()
        {
            return GetCurrentScope();
        }

        private static IUnitOfWorkScope GetCurrentScope()
        {
            try
            {
                return new NHibernateUnitOfWorkScope(IOC.GetImplementationOf<ISessionFactoryRegistration>().SessionFactory());
            }
            catch (InvalidOperationException e)
            {
                return new NullUnitOfWorkScope();
            }
        }
    }

    public interface ISessionFactoryRegistration
    {
        void Register(ISessionFactory sessionFactory);
        ISessionFactory SessionFactory();
    }

    public class SessionFactoryRegistration : ISessionFactoryRegistration
    {
        private ISessionFactory sessionFactory;

        public void Register(ISessionFactory sessionFactory)
        {
            this.sessionFactory= sessionFactory;
        }

        public ISessionFactory SessionFactory()
        {
            return sessionFactory;
        }

        public ISession CurrentSession()
        {
            var session = SessionFactory().GetCurrentSession();
            
            if (!session.Transaction.IsActive) session.BeginTransaction();
            return session;
        }
    }

    public interface IUnitOfWorkScope : IDisposable
    {
        void Complete();
        void Rollback();
    }

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

    public class NullUnitOfWorkScope : IUnitOfWorkScope
    {
        public void Dispose()
        {
        }

        public void Complete()
        {
        }

        public void Rollback()
        {
        }
    }
}