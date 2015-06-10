
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Models;
using Models.Response;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Export
{
    public class Excel
    {
        public void CreateExample(string path)
        {
            ExcelPackage pck = new ExcelPackage();
            //Add the Content sheet
            var ws = pck.Workbook.Worksheets.Add("Content");

            ws.Cells["B1"].Value = "Name";
            ws.Cells["C1"].Value = "Size";
            ws.Cells["D1"].Value = "Created";
            ws.Cells["E1"].Value = "Last modified";
            ws.Cells["B1:E1"].Style.Font.Bold = true;

            Stream stream = File.Create(path);

            pck.SaveAs(stream);
            stream.Close();
        }

        public void DropMonthToFile(DateTime date, Team team, Container container, string path)
        {
            int originalMonthNumber = date.Month;

            ExcelPackage pck = new ExcelPackage();
            var ws = pck.Workbook.Worksheets.Add("Default");

            ws.Cells["B4"].Value = "Year";
            ws.Cells["B5"].Value = "Month";
            ws.Cells["B6"].Value = "Working scheme";
            ws.Cells["B7"].Value = "Working days";

            ws.Cells["B4:B7"].Style.Font.Bold = true;

            ws.Cells["C4"].Value = date.ToString("yyyy");
            ws.Cells["C5"].Value = date.ToString("MMMM");
            ws.Cells["C6"].Value = "5/2";

            ws.Cells["C4:C7"].Style.Font.Bold = true;

            ws.Cells["B9"].Value = "Employee";
            ws.Cells["C9"].Value = "Position";
            ws.Cells["D9"].Value = "ОТГУЛЫ";

            date = new DateTime(date.Year, date.Month, 1);

            int employeeNumber = 0;

            List<Employee> employees = container.GetEmployeesOfTeam(team);

            foreach (Employee employee in employees)
            {
                ws.Cells[10 + employeeNumber, 2].Value = employee.FullName;

                employeeNumber++;
            }

            for (int i = 0; i < 31; i++)
            {
                if (date.Month != originalMonthNumber)
                {
                    break;
                }

                string format = date.ToString("yyyy-MM-dd");

                ws.Cells[9, 5 + i].Value = i + 1;

                ws.Column(5 + i).Width = 4;
                ws.Column(5 + i).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                employeeNumber = 0;

                foreach (Employee employee in employees)
                {
                    int type = 0;

                    if (employee.Days.ContainsKey(format))
                    {
                        type = employee.Days[format];
                    }
                    else if (container.PublicHolidays.ContainsKey(format))
                    {
                        type = 3;
                    }
                    else if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        type = 2;
                    }

                    if (container.DayTypes.ContainsKey(type))
                    {
                        DayType dayType = container.DayTypes[type];

                        ws.Cells[10 + employeeNumber, 5 + i].Value = dayType.Title;
                        ws.Cells[10 + employeeNumber, 5 + i].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        ws.Cells[10 + employeeNumber, 5 + i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        ws.Cells[10 + employeeNumber, 5 + i].Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#" + dayType.BackgroundColor.ToString()));
                        ws.Cells[10 + employeeNumber, 5 + i].Style.Font.Color.SetColor(ColorTranslator.FromHtml("#" + dayType.Color.ToString()));
                    }

                    employeeNumber++;
                }

                date = date.AddDays(1);
            }

            Stream stream = File.Create(path);

            pck.SaveAs(stream);
            stream.Close();
        }
    }

    
}
