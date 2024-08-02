using System.ComponentModel.DataAnnotations;

namespace IntermediateLevel.Models
{
    public class Payreg
    {
        [Key]
        public int Id { get; set; }
        public string PayrollNumber { get; set; }
    }
}
