using IntermediateLevel.Contract;
using IntermediateLevel.Data;
using IntermediateLevel.Models;
using Microsoft.EntityFrameworkCore;

namespace IntermediateLevel.Repository
{
    public class TimeAttendanceRepository:ITimeAttendanceRepository
    {
        private readonly CalculatorContext _calculatorContext;

        public async Task<IEnumerable<TimeAttendance>> GetAllTimeAttendanceAsync()
        {
            return await _calculatorContext.TimeAttendances.ToListAsync();
        }
    }
}
