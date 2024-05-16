using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using ReportProject.Models;

namespace ReportProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly StoreContext _context;
        public ReportController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult GeneratePdf()
        {
            var employees = _context.Employees.ToList();
            byte[] pdf = GeneratePdfReport(employees);
            return File(pdf, "application/pdf", "EmployeesReport.pdf");
        }
        private byte[] GeneratePdfReport(List<Employees> employees)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                document.Add(new Paragraph("Employees Report"));
                var table = new Table(4, true);
                table.AddCell("Id");
                table.AddCell("Name");
                table.AddCell("Position");
                table.AddCell("Salary");
                foreach (var employee in employees)
                {
                    table.AddCell(employee.EmployeeID.ToString());
                    table.AddCell(employee.FirstName);
                    table.AddCell(employee.LastName);
                    table.AddCell(employee.Address);
                }
                document.Add(table);
                document.Close();
                return stream.ToArray();
            }
        }

    }
}
