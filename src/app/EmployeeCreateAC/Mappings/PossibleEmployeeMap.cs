using FluentNHibernate.Mapping;

namespace EmployeeCreateAC.Mappings
{
    public class PossibleEmployeeMap : ClassMap<PossibleEmployee>
    {
        public PossibleEmployeeMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}