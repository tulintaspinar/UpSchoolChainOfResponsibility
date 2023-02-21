using System;
using UpSchoolChainOfResponsibility.DAL;
using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(WithDrawModel req)
        {
            if (req.Amount <= 40000)
            {
                using(var context = new Context())
                {
                    BankProcess bank = new BankProcess();
                    bank.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bank.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi veznedar tarafından gerçekleştirildi.";
                    bank.Amount = req.Amount;
                    bank.CustomerName= req.CustomerName;
                    context.BankProcesses.Add(bank);
                    context.SaveChanges();
                }
            }
            else if (NextApprover != null)
            {
                using (var context = new Context())
                {
                    BankProcess bank = new BankProcess();
                    bank.EmployeeName = "Veznedar - Ayşenur Yıldız";
                    bank.Description = "Müşterinin talep ettiği tutar yetkim dahilinde olmadığı için şube müdür yardımcısına yönlendirildi";
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
