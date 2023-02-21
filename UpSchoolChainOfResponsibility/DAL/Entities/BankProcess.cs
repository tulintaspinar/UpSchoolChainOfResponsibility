
namespace UpSchoolChainOfResponsibility.DAL.Entities
{
    public class BankProcess
    {
        public int BankProcessID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
}
