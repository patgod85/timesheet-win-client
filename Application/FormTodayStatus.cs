using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Export;
using Infrastructure;
using Models;
using Models.Response;

namespace TimesheetClient
{
    public partial class FormTodayStatus : Form
    {
        private static readonly Server Server = new Server(TimesheetSettings.Settings);

        private Container _container;

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

                LoginResult loginResult = Server.Login();

                if (loginResult.Success)
                {
                    status.Text = @"Authentication successful";

                    _container = Server.GetContainer();

                    dayTypeBindingSource.DataSource = _container.DayTypes.Values.ToList();

                    dataGridView1.DataSource = _container.HomeEmployees;

                    comboBoxTeams.DataSource = _container.Teams;

                    labelTeamName.Text = _container.HomeTeam.Name;

                    labelLoggedAs.Text = loginResult.User.FullName;

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
            saveFileDialog1.InitialDirectory = TimesheetSettings.Settings.ExportFolder;

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

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "timesheet-" + dateTimePicker1.Value.ToString("yyyy-MM-") + ((Team)comboBoxTeams.SelectedValue).Code + ".xlsx";

            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Excel excel = new Excel();

            excel.DropMonthToFile(dateTimePicker1.Value, comboBoxTeams.SelectedValue as Team, _container, saveFileDialog1.FileName);
        }

    }



}
