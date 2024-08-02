using IntermediateLevel.Contract;
using IntermediateLevel.Models;
using OfficeOpenXml;

namespace IntermediateLevel.Services
{
    public class OvertimeCalculationService : IOvertimeCalculationService
    {
        private readonly ITimeAttendanceRepository _timeAttendanceRepository;
        private readonly IPayregRepository _payregRepository;

        public OvertimeCalculationService(ITimeAttendanceRepository timeAttendanceRepository, IPayregRepository payregRepository)
        {
            _timeAttendanceRepository = timeAttendanceRepository;
            _payregRepository = payregRepository;
        }

        public async Task<Stream> CalculateAndExportOvertimeAsync(string payrollNo)
        {
            var timeAttendances = await _timeAttendanceRepository.GetAllTimeAttendanceAsync();
            var payRegs = await _payregRepository.FindByPayrollNumberAsync(payrollNo);

            var data = timeAttendances
            .Where(t => payRegs.Any(p => p.PayrollNumber == payrollNo))
            .Select(t => new
            {
                t.EmpId,
                t.LastName,
                t.FirstName,
                t.AttDeduction,
                Overtime = CalculateOvertime(t, 1.00m)
            })
            .ToList();

            return ExportToExcel(data);

        }

        private decimal CalculateOvertime(TimeAttendance t, decimal premiumRate)
        {
            decimal hourlyRate;
            if (t.Paytype == "Daily")
            {
                hourlyRate = t.DailyRate / 8;
            }
            else if(t.Paytype == "Monthy")
            {
                hourlyRate = t.MonthlySalary / 22 / 8;
            }
            else
            {
                throw new InvalidOperationException("Unknown Paytype");
            }

            int overtimeHours = t.HoursWorked;
            decimal overtimeAmount = hourlyRate * premiumRate * overtimeHours;

            return overtimeAmount;
        }

        private Stream ExportToExcel(IEnumerable<dynamic> data)
        {
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("OTREG");
                workSheet.Cells[1, 1].Value = "Employee Id #";
                workSheet.Cells[1, 2].Value = "LAST NAME";
                workSheet.Cells[1, 3].Value = "FIRST NAME";
                workSheet.Cells[1, 4].Value = "ATT DEDUCTION";
                workSheet.Cells[1, 5].Value = "OVERTIME";

                int row = 2;
                foreach(var item in data)
                {
                    workSheet.Cells[row, 1].Value = item.EmpId;
                    workSheet.Cells[row, 2].Value = item.LastName;
                    workSheet.Cells[row, 3].Value = item.FirstName;
                    workSheet.Cells[row, 4].Value = item.AttDeduction;
                    workSheet.Cells[row, 5].Value = item.Overtime;
                }

                package.Save();
            }
            stream.Position = 0;
            return stream;
        }
    }
}
