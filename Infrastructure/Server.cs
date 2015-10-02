using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Models;
using Models.Response;
using Newtonsoft.Json;
using Models.Request;

namespace Infrastructure
{
    public class Server
    {
        private CookieAwareWebClient _webClient;

        private readonly TimesheetSettings _settings;

        public Server(TimesheetSettings settings)
        {
            _settings = settings;

            SetWebClient();
        }

        private void SetWebClient()
        {
            _webClient = new CookieAwareWebClient();

            if (_settings.Proxy != "")
            {
                _webClient.Proxy = new WebProxy(_settings.Proxy);
            }

        }

        private void SetHeaders()
        {
            _webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            _webClient.Headers.Add("content-type", "application/json; charset=UTF-8");
        }

        public LoginResult Login()
        {
            SetHeaders();

            string json = JsonConvert.SerializeObject(
                new Login(_settings.Username, _settings.Password) 
            );

            _webClient.UploadString(_settings.Url + "/app/login", json);

            Stream data = _webClient.OpenRead(_settings.Url + "/app/whoami");

            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return JsonConvert.DeserializeObject<LoginResult>(s);
        }

        public Container GetContainer()
        {
            Stream data = _webClient.OpenRead(_settings.Url + "/app/model");
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return JsonConvert.DeserializeObject<Container>(s);
        }

        public bool UploadEmployees(List<Employee> employees)
        {
            SetHeaders();

            List<Day> days = (
                from employee in employees 
                where employee.LastDayType != 0 
                select new Day(
                    employee.Id,
                    DateTime.Now.ToString("yyyy-MM-dd"), 
                    employee.LastDayType)
            ).ToList();

            string responsebytes = _webClient.UploadString(_settings.Url + "/app/set-type", JsonConvert.SerializeObject(days));

            BooleanResult result = JsonConvert.DeserializeObject<BooleanResult>(responsebytes);

            return result.Success;
        }
    }
}
