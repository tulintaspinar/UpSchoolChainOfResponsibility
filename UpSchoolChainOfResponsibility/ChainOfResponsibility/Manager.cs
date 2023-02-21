using UpSchoolChainOfResponsibility.DAL;
using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
        public override void ProcessRequest(WithDrawModel req)
        {
            if (req.Amount <= 150000)
            {
                using (var context = new Context())
                {
                    BankProcess bank = new BankProcess();
                    bank.EmployeeName = "Şube Müdürü  - Hakan Kayalı";
                    bank.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi şube müdürü gerçekleştirildi.";
                    bank.Amount = req.Amount;
                    bank.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bank);
                    context.SaveChanges();
                }
            }
            else if (NextApprover != null)
            {
                using (var context = new Context())
                {
                    BankProcess bank = new BankProcess();
                    bank.EmployeeName = "Şube Müdürü  - Hakan Kayalı";
                    bank.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için bölge müdürüne yönlendirildi.";
                    bank.Amount = req.Amount;
                    bank.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bank);
                    context.SaveChanges();
                    NextApprover.ProcessRequest(req);
                }
            }
        }
    }
}
