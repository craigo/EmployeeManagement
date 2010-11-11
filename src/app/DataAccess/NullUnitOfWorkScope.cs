namespace EmployeeCreateAC.DataAccess
{
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