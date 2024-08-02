namespace IntermediateLevel.Contract
{
    public interface IOvertimeCalculationService
    {
        Task<Stream> CalculateAndExportOvertimeAsync(string payrollNo);
    }
}
