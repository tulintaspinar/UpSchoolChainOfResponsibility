using UpSchoolChainOfResponsibility.DAL;
using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(WithDrawModel req)
        {
            Context c = new Context();
            if (req.Amount <= 250000)
            {
                BankProcess bank = new BankProcess();
                bank.EmployeeName = "Bölge Müdürü - Nazlı Siyah";
                bank.Description = "Müşteriye talep etmiş olduğu tutarın ödemesi bölge müdürü gerçekleştirildi.";
                bank.Amount = req.Amount;
                bank.CustomerName = req.CustomerName;
                c.BankProcesses.Add(bank);
                c.SaveChanges();
            }
            else
            {
                BankProcess bank = new BankProcess();
                bank.EmployeeName = "Bölge Müdürü - Nazlı Siyah";
                bank.Description = "Müşterinin talep ettiği tutar banka limitlerinin günlük çekim limitleri üzerinde olduğu için müşteriye ödeme yapılamadı.";
                bank.Amount = req.Amount;
                bank.CustomerName = req.CustomerName;
                c.BankProcesses.Add(bank);
                c.SaveChanges();
            }
        }
    }
}
