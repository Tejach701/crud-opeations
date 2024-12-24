namespace Employees.model.DTO
{
    public class AddSalaryDTO
    {
        public int EmpNo { get; set; }
        public int SalaryAmount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
