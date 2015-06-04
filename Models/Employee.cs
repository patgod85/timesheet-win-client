using System;
using System.Collections.Generic;

namespace Models
{
    public class Employee
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string TeamCode { get; private set; }

        public int TeamId { get; private set; }

        public string WorkStart { get; private set; }

        public string WorkEnd { get; private set; }

        public Dictionary<string, int> Days { get; private set; }

        public Employee(int id, string name, string surname, string teamCode, int teamId, string workStart, string workEnd, Dictionary<string, int> days)
        {
            Id = id;
            Name = name;
            Surname = surname;
            TeamCode = teamCode;
            TeamId = teamId;
            WorkStart = workStart;
            WorkEnd = workEnd;
            Days = days;
        }

        public int LastDayType
        {
            get
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");

                var type = 0;

                foreach (KeyValuePair<string, int> day in Days)
                {
                    if (day.Key == today)
                    {
                        type = day.Value;
                    }
                }

                return type;
            }

            set
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");

                var type = 0;

                if (Days.ContainsKey(today))
                {
                    Days[today] = value;
                }
            }
        }

        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
    }
}
