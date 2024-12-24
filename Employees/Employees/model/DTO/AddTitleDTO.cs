namespace Employees.model.DTO
{
    public class AddTitleDTO
    {
        public int EmpNo { get; set; }
        public string TitleName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
