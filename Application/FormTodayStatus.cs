using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Infrastructure;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TimesheetClient
{
    public partial class FormTodayStatus : Form
    {
        private CookieAwareWebClient _webClient;

        public FormTodayStatus()
        {
            InitializeComponent();
        }

        private void SetWebClient()
        {
            _webClient = new CookieAwareWebClient();

            if (TimesheetSettings.Settings.Proxy != "")
            {
                WebProxy wp = new WebProxy(TimesheetSettings.Settings.Proxy);
                _webClient.Proxy = wp;
            }

            _webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            _webClient.Headers.Add("content-type", "application/json; charset=UTF-8");
        }

        private bool Login()
        {
            string json = "{\"username\":\"" + TimesheetSettings.Settings.Username + "\", \"password\":\"" + TimesheetSettings.Settings.Password + "\"}";

            string responsebytes = _webClient.UploadString(TimesheetSettings.Settings.Url + "/login", json);

            LoginResult result = JsonConvert.DeserializeObject<LoginResult>(responsebytes);

            return result.Success;
        }

        private Container GetContainer()
        {
            Stream data = _webClient.OpenRead(TimesheetSettings.Settings.Url + "/model");
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return JsonConvert.DeserializeObject<Container>(s);
        }

        private void FormTodayStatus_Load(object sender, EventArgs e)
        {
            if (TimesheetSettings.Settings.Url != "")
            {
                linkLabel1.Text = TimesheetSettings.Settings.Url;

                SetWebClient();

                status.Text = @"Connection to " + TimesheetSettings.Settings.Url;

                if (Login())
                {
                    status.Text = @"Authentication successful";

                    Container container = GetContainer();

                    dayTypeBindingSource.DataSource = container.DayTypes.Values.ToList();

                    dataGridView1.DataSource = container.Employees;

                    status.Text = @"Data received";

                    /*
                    Stream data = _webClient.OpenRead(TimesheetSettings.Settings.Url + "/model");
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();

                    dynamic stuff = JObject.Parse(s);

                    Dictionary<int, DayType> dayTypes = JsonConvert.DeserializeObject<Dictionary<int, DayType>>(stuff.dayTypes.ToString());

                    dayTypeBindingSource.DataSource = dayTypes.Values.ToList();

                    dataGridView1.DataSource = JsonConvert.DeserializeObject<List<Employee>>(stuff.employees.ToString());
                     */

                }
                else
                {
                    status.Text = @"Authentication is failed";
                }
            }
            else
            {
                status.Text = @"Settings are invalid";
            }

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(TimesheetSettings.Settings.Url);
        }

    }



}
