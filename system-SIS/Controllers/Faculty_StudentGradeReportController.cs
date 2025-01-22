using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using System.IO;

namespace system_SIS.Controllers
{
    public class FacultyStudentGradeReportController : Controller
    {
        public IActionResult GeneratePdfGrade()
        {
            var student = new
            {
                LRN = "563786535809",
                Name = "Cuerdo, Joshua",
                Age = "15",
                Sex = "Male",
                Grade = "7",
                Section = "Araling Panlipunan",
                SchoolYear = "2023-2024",
                Subjects = new[] {
                    new { Name = "Filipino", QuarterGrades = new[] { 82, 81, 93, 92 }, FinalGrade = 87, Remarks = "Passed" },
                    new { Name = "English", QuarterGrades = new[] { 86, 91, 91, 93 }, FinalGrade = 90, Remarks = "Passed" },
                    new { Name = "Mathematics", QuarterGrades = new[] { 85, 90, 92, 94 }, FinalGrade = 90, Remarks = "Passed" },
                    new { Name = "Science", QuarterGrades = new[] { 88, 89, 87, 89 }, FinalGrade = 88, Remarks = "Passed" },
                    new { Name = "Araling Panlipunan (AP)", QuarterGrades = new[] { 86, 90, 87, 88 }, FinalGrade = 88, Remarks = "Passed" },
                    new { Name = "Edukasyon sa Pagpapakatao (EsP)", QuarterGrades = new[] { 82, 90, 91, 92 }, FinalGrade = 89, Remarks = "Passed" },
                    new { Name = "Technology and Livelihood Education (TLE)", QuarterGrades = new[] { 87, 90, 91, 92 }, FinalGrade = 90, Remarks = "Passed" },
                    new { Name = "MAPEH", QuarterGrades = new[] { 90, 91, 92, 93 }, FinalGrade = 92, Remarks = "Passed" }
                },
                GeneralAverage = 89
            };

            // Create PDF
            var pdf = new PdfDocument();
            var page = pdf.AddPage();
            var graphics = XGraphics.FromPdfPage(page);
            var titleFont = new XFont("Arial", 16, XFontStyle.Bold);
            var boldFont = new XFont("Arial", 12, XFontStyle.Bold);
            var font = new XFont("Arial", 10, XFontStyle.Regular);

            // Add Logo
            string logoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "logo.png");
            double logoHeight = 0;
            if (System.IO.File.Exists(logoPath))
            {
                var logo = XImage.FromFile(logoPath);
                var logoWidth = 100;
                logoHeight = (logo.PixelHeight / (double)logo.PixelWidth) * logoWidth;
                graphics.DrawImage(logo, (page.Width - logoWidth) / 2, 30, logoWidth, logoHeight);
            }

            // Header Texts
            double headerStartY = 30 + logoHeight + 10; // Position below the logo
            graphics.DrawString("Jose Rizal High School", titleFont, XBrushes.Black, new XRect(0, headerStartY, page.Width, 30), XStringFormats.TopCenter);
            graphics.DrawString("Junior High School", font, XBrushes.Black, new XRect(0, headerStartY + 20, page.Width, 20), XStringFormats.TopCenter);
            graphics.DrawString("LEARNER'S PROGRESS REPORT CARD", font, XBrushes.Black, new XRect(0, headerStartY + 40, page.Width, 20), XStringFormats.TopCenter);

            // Add Margin Above the Name Section
            double marginAboveName = 30;

            // Student Info Table
            double infoStartY = headerStartY + 70 + marginAboveName;
            double rowHeight = 20;
            double tableWidth = 400; // Approximate width of the table
            double centerX = (page.Width - tableWidth) / 2;

            graphics.DrawString("Name:", boldFont, XBrushes.Black, new XPoint(centerX, infoStartY));
            graphics.DrawString(student.Name, font, XBrushes.Black, new XPoint(centerX + 80, infoStartY));
            graphics.DrawString("Age:", boldFont, XBrushes.Black, new XPoint(centerX + 250, infoStartY));
            graphics.DrawString(student.Age, font, XBrushes.Black, new XPoint(centerX + 300, infoStartY));

            graphics.DrawString("Grade:", boldFont, XBrushes.Black, new XPoint(centerX, infoStartY + rowHeight));
            graphics.DrawString(student.Grade, font, XBrushes.Black, new XPoint(centerX + 80, infoStartY + rowHeight));
            graphics.DrawString("Sex:", boldFont, XBrushes.Black, new XPoint(centerX + 250, infoStartY + rowHeight));
            graphics.DrawString(student.Sex, font, XBrushes.Black, new XPoint(centerX + 300, infoStartY + rowHeight));

            graphics.DrawString("School Year:", boldFont, XBrushes.Black, new XPoint(centerX, infoStartY + 2 * rowHeight));
            graphics.DrawString(student.SchoolYear, font, XBrushes.Black, new XPoint(centerX + 80, infoStartY + 2 * rowHeight));
            graphics.DrawString("Section:", boldFont, XBrushes.Black, new XPoint(centerX + 250, infoStartY + 2 * rowHeight));
            graphics.DrawString(student.Section, font, XBrushes.Black, new XPoint(centerX + 300, infoStartY + 2 * rowHeight));

            graphics.DrawString("LRN:", boldFont, XBrushes.Black, new XPoint(centerX, infoStartY + 3 * rowHeight));
            graphics.DrawString(student.LRN, font, XBrushes.Black, new XPoint(centerX + 80, infoStartY + 3 * rowHeight));

            // Grades Table
            double gradesStartY = infoStartY + 4 * rowHeight + 40; // Increased margin above the table

            // Adjust column widths for better presentation
            double learningAreaWidth = 180; // Wider space for the "Learning Areas" column
            double quarterWidth = 60; // Narrower columns for quarters
            double finalGradeWidth = 80; // Wider space for "Final Grade"
            double remarksWidth = 100; // Wider space for "Remarks"
            double totalTableWidth = learningAreaWidth + 4 * quarterWidth + finalGradeWidth + remarksWidth; // Total width

            // Table Header with lines (First Row)
            graphics.DrawRectangle(XPens.Black, centerX, gradesStartY, totalTableWidth, rowHeight * 2); // Double height for the header
            graphics.DrawString("Learning Areas", boldFont, XBrushes.Black, new XRect(centerX, gradesStartY, learningAreaWidth, rowHeight * 2), XStringFormats.Center);
            graphics.DrawString("Quarter", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth, gradesStartY, 4 * quarterWidth, rowHeight), XStringFormats.Center); // Span quarters over 4 columns
            graphics.DrawString("Final Grade", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth + 4 * quarterWidth, gradesStartY, finalGradeWidth, rowHeight), XStringFormats.Center);
            graphics.DrawString("Remarks", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth + 4 * quarterWidth + finalGradeWidth, gradesStartY, remarksWidth, rowHeight), XStringFormats.Center);

            // Draw lines for the first row (Learning Areas and Quarter)
            graphics.DrawLine(XPens.Black, centerX, gradesStartY + rowHeight * 2, centerX + totalTableWidth, gradesStartY + rowHeight * 2); // Horizontal line under the header
            graphics.DrawLine(XPens.Black, centerX, gradesStartY, centerX, gradesStartY + rowHeight * 2); // Left line for the first column
            graphics.DrawLine(XPens.Black, centerX + totalTableWidth, gradesStartY, centerX + totalTableWidth, gradesStartY + rowHeight * 2); // Right line for the last column

            // Draw vertical lines between each column in the header
            for (int i = 1; i <= 5; i++) // 5 divisions (Learning Areas, Quarter 1-4, Final Grade, Remarks)
            {
                double xPosition = centerX + i * quarterWidth;
                if (i == 1) xPosition = centerX + learningAreaWidth; // Adjust the first quarter line after the learning area
                if (i == 5) xPosition = centerX + learningAreaWidth + 4 * quarterWidth; // Adjust after the quarters
                graphics.DrawLine(XPens.Black, xPosition, gradesStartY, xPosition, gradesStartY + rowHeight * 2);
            }

            // Quarter labels (Second Row, underneath "Quarter" label)
            graphics.DrawString("1st", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth, gradesStartY + rowHeight, quarterWidth, rowHeight), XStringFormats.Center);
            graphics.DrawString("2nd", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth + quarterWidth, gradesStartY + rowHeight, quarterWidth, rowHeight), XStringFormats.Center);
            graphics.DrawString("3rd", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth + 2 * quarterWidth, gradesStartY + rowHeight, quarterWidth, rowHeight), XStringFormats.Center);
            graphics.DrawString("4th", boldFont, XBrushes.Black, new XRect(centerX + learningAreaWidth + 3 * quarterWidth, gradesStartY + rowHeight, quarterWidth, rowHeight), XStringFormats.Center);

            double currentY = gradesStartY + rowHeight * 2; // Start drawing rows after the header row

            // Draw rows for each subject
            foreach (var subject in student.Subjects)
            {
                // Draw the rows with lines
                graphics.DrawRectangle(XPens.Black, centerX, currentY, totalTableWidth, rowHeight);
                graphics.DrawString(subject.Name, font, XBrushes.Black, new XRect(centerX, currentY, learningAreaWidth, rowHeight), XStringFormats.CenterLeft);

                // Draw quarter grades inline under each quarter label
                for (int i = 0; i < subject.QuarterGrades.Length; i++)
                {
                    graphics.DrawString(subject.QuarterGrades[i].ToString(), font, XBrushes.Black, new XRect(centerX + learningAreaWidth + i * quarterWidth, currentY, quarterWidth, rowHeight), XStringFormats.Center);
                }

                graphics.DrawString(subject.FinalGrade.ToString(), font, XBrushes.Black, new XRect(centerX + learningAreaWidth + 4 * quarterWidth, currentY, finalGradeWidth, rowHeight), XStringFormats.Center);
                graphics.DrawString(subject.Remarks, font, XBrushes.Black, new XRect(centerX + learningAreaWidth + 4 * quarterWidth + finalGradeWidth, currentY, remarksWidth, rowHeight), XStringFormats.Center);

                // Draw the lines around each row
                graphics.DrawLine(XPens.Black, centerX, currentY + rowHeight, centerX + totalTableWidth, currentY + rowHeight); // Bottom line for each row
                graphics.DrawLine(XPens.Black, centerX, currentY, centerX, currentY + rowHeight); // Left line for the first cell
                graphics.DrawLine(XPens.Black, centerX + totalTableWidth, currentY, centerX + totalTableWidth, currentY + rowHeight); // Right line for the last cell

                // Draw vertical lines between each column in the rows (skip the line between Learning Areas and the first quarter)
                for (int i = 1; i <= 4; i++) // 4 quarters and Final Grade + Remarks
                {
                    graphics.DrawLine(XPens.Black, centerX + learningAreaWidth + i * quarterWidth, currentY, centerX + learningAreaWidth + i * quarterWidth, currentY + rowHeight);
                }
                graphics.DrawLine(XPens.Black, centerX + learningAreaWidth + 4 * quarterWidth, currentY, centerX + learningAreaWidth + 4 * quarterWidth, currentY + rowHeight); // Line after the 4th Quarter
                graphics.DrawLine(XPens.Black, centerX + learningAreaWidth + 4 * quarterWidth + finalGradeWidth, currentY, centerX + learningAreaWidth + 4 * quarterWidth + finalGradeWidth, currentY + rowHeight); // Line after the Final Grade column
                currentY += rowHeight;
            }

            // Save the document to a MemoryStream
            using (var ms = new MemoryStream())
            {
                pdf.Save(ms);
                return File(ms.ToArray(), "application/pdf", "StudentGradeReport.pdf");
            }
        }
    }
}
