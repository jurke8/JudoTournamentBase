using JudoTournamentBase.Enums;
using JudoTournamentBase.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace JudoTournamentBase.Utils
{
    public class ReportUtils
    {
        public MemoryStream GenerateReport(string categoryId, string clubId)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var competitors = db.Competitors.ToList();

                // Filtering
                if (!String.IsNullOrEmpty(categoryId))
                {
                    competitors = competitors.Where(c => categoryId.Equals(c.CategoryId.ToString())).ToList();
                }
                if (!String.IsNullOrEmpty(clubId))
                {
                    competitors = competitors.Where(c => clubId.Equals(c.ClubId.ToString())).ToList();
                }

                var package = new ExcelPackage();
                var ws = CreateSheet(package, Resources.Localization.Details, 1);

                //Header
                ws.Cells[1, 1].Value = Resources.Localization.FirstName;
                ws.Cells[1, 2].Value = Resources.Localization.LastName;
                ws.Cells[1, 3].Value = Resources.Localization.Gender;
                ws.Cells[1, 4].Value = Resources.Localization.DateOfBirth;
                ws.Cells[1, 5].Value = Resources.Localization.Category;
                ws.Cells[1, 6].Value = Resources.Localization.Club;
                ws.Cells[1, 7].Value = Resources.Localization.Country;

                ws.Cells[1, 1].Style.Font.Bold = true;
                ws.Cells[1, 2].Style.Font.Bold = true;
                ws.Cells[1, 3].Style.Font.Bold = true;
                ws.Cells[1, 4].Style.Font.Bold = true;
                ws.Cells[1, 5].Style.Font.Bold = true;
                ws.Cells[1, 6].Style.Font.Bold = true;
                ws.Cells[1, 7].Style.Font.Bold = true;

                //Body
                var n = 2;

                foreach (var c in competitors)
                {
                    var gender = c.Gender.GetDisplayName();

                    ws.Cells[n, 1].Value = c.FirstName;
                    ws.Cells[n, 2].Value = c.LastName;
                    ws.Cells[n, 3].Value = "Female".Equals(gender) ? Resources.Localization.Female : Resources.Localization.Male;
                    ws.Cells[n, 4].Value = c.DateOfBirth;
                    ws.Cells[n, 4].Style.Numberformat.Format = "dd.MM.yyyy";
                    ws.Cells[n, 5].Value = c.Category.Name;
                    ws.Cells[n, 6].Value = c.Club.Name;
                    ws.Cells[n, 7].Value = c.Country;

                    n++;
                }

                //Cells style
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                ws.Cells[ws.Dimension.Address].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells[ws.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                var fileStream = new MemoryStream();
                package.SaveAs(fileStream);
                fileStream.Position = 0;
                return fileStream;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName, int sheetId)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[sheetId];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet
            return ws;
        }
    }
}