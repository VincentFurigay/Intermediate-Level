using IntermediateLevel.Models;

namespace IntermediateLevel.Contract
{
    public interface ITimeAttendanceRepository
    {
        Task <IEnumerable<TimeAttendance>> GetAllTimeAttendanceAsync();
     }
}
