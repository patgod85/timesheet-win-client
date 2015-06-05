
using System.Collections.Generic;

namespace Models.Response
{
    public class Container
    {
        public Dictionary<int, DayType> DayTypes { get; private set; }

        public List<Employee> Employees { get; private set; }

        public Container(Dictionary<int, DayType> dayTypes, List<Employee> employees)
        {
            DayTypes = dayTypes;
            Employees = employees;
        }
    }
}
