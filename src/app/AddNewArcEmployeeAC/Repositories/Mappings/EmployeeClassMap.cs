using FluentNHibernate.Mapping;

namespace AddNewArcEmployeeAC.Repositories.Mappings
{
    public class EmployeeClassMap : ClassMap<Employee>
    {
        public EmployeeClassMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.StartDate);
        }
    }
}