using IntermediateLevel.Contract;
using IntermediateLevel.Data;
using IntermediateLevel.Models;
using Microsoft.EntityFrameworkCore;

namespace IntermediateLevel.Repository
{
    public class PayregRepository : IPayregRepository
    {
        private readonly CalculatorContext _calculatorContext;
        public PayregRepository(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }
        public async Task<IEnumerable<Payreg>> FindByPayrollNumberAsync(string payrollNo)
        {
            return await _calculatorContext.Payregs.Where(p => p.PayrollNumber == payrollNo).ToListAsync();
        }
    }
}
