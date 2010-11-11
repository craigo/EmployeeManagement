using System;

namespace EmployeeCreateAC.DataAccess
{
    public interface IUnitOfWorkScope : IDisposable
    {
        void Complete();
        void Rollback();
    }
}