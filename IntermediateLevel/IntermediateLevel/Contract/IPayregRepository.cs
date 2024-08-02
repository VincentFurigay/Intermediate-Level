using IntermediateLevel.Models;

namespace IntermediateLevel.Contract
{
    public interface IPayregRepository
    {
        Task<IEnumerable<Payreg>> FindByPayrollNumberAsync(string payrollNo);
    }
}
