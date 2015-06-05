using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Infrastructure;
using Models;
using Models.Response;

namespace TimesheetClient
{
    public partial class FormTodayStatus : Form
    {
        private static readonly Server Server = new Server(TimesheetSettings.Settings);

        public FormTodayStatus()
        {
            InitializeComponent();
        }

        private void ReceiveData()
        {
            uploadDataToolStripMenuItem.Enabled = false;

            if (TimesheetSettings.Settings.Url != "")
            {
                linkLabel1.Text = TimesheetSettings.Settings.Url;

                status.Text = @"Connection to " + TimesheetSettings.Settings.Url;

                if (Server.Login())
                {
                    status.Text = @"Authentication successful";

                    Container container = Server.GetContainer();

                    dayTypeBindingSource.DataSource = container.DayTypes.Values.ToList();

                    dataGridView1.DataSource = container.Employees;

                    status.Text = @"Data received";

                    uploadDataToolStripMenuItem.Enabled = true;
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

        private void SendData()
        {
            status.Text = @"Send data to server";

            if (Server.UploadEmployees(dataGridView1.DataSource as List<Employee>))
            {
                status.Text = @"Data successfully sent";

                ReceiveData();
            }
            else
            {
                status.Text = @"Sending of data is failed";
            }
        }

        private void FormTodayStatus_Load(object sender, EventArgs e)
        {
            ReceiveData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(TimesheetSettings.Settings.Url);
        }

        private void retryReceiveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveData();
        }

        private void uploadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendData();
        }

    }



}
