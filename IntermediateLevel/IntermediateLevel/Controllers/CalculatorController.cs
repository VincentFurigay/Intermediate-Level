using IntermediateLevel.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntermediateLevel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IOvertimeCalculationService _overtimeCalculationService;
        public CalculatorController(IOvertimeCalculationService overtimeCalculationService)
        {
            _overtimeCalculationService = overtimeCalculationService;
        }

        [HttpGet("Export")]
        public async Task <IActionResult> ExportOvertime([FromQuery] string PayrollNo)
        {
            var stream = await _overtimeCalculationService.CalculateAndExportOvertimeAsync(PayrollNo);

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet\", \"OvertimeReport.xlsx")
        }
    }
}
