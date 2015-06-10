using System;
using System.Configuration;

namespace Infrastructure
{
    public class TimesheetSettings : ConfigurationSection
    {
        private static TimesheetSettings _settings = ConfigurationManager.GetSection("TimesheetSettings") as TimesheetSettings;

        public static TimesheetSettings Settings
        {
            get
            {
                return _settings;
            }
        }


        [ConfigurationProperty("username")]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("url")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("proxy")]
        public string Proxy
        {
            get { return (string)this["proxy"]; }
            set { this["proxy"] = value; }
        }

        [ConfigurationProperty("exportFolder")]
        public string ExportFolder
        {
            get { return (string)this["exportFolder"]; }
            set { this["exportFolder"] = value; }
        }
    }
}
