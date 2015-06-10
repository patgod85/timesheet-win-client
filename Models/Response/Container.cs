
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Models.Response
{
    public class Container
    {
        public Dictionary<int, DayType> DayTypes { get; private set; }

        public List<Employee> Employees { get; private set; }

        public List<Employee> HomeEmployees { get; private set; }

        public List<Team> Teams { get; private set; }

        public Team HomeTeam { get; private set; }

        public Dictionary<string, PublicHoliday> PublicHolidays { get; private set; }

        [JsonProperty(PropertyName = "home_team_id")]
        public int HomeTeamId { get; private set; }

        public Container(Dictionary<int, DayType> dayTypes, List<Employee> employees, List<Team> teams, Dictionary<string, PublicHoliday> publicHolidays, int homeTeamId)
        {
            DayTypes = dayTypes;
            Employees = employees;
            Teams = teams;
            PublicHolidays = publicHolidays;
            HomeTeamId = homeTeamId;

            foreach (Team team in Teams.Where(team => team.Id == HomeTeamId))
            {
                HomeTeam = team;
                break;
            }

            HomeEmployees = Employees.Where(employee => employee.TeamId == HomeTeamId).ToList();
        }

        public List<Employee> GetEmployeesOfTeam(Team team)
        {
            return Employees.Where(employee => employee.TeamId == team.Id).ToList();
        }
    }
}
