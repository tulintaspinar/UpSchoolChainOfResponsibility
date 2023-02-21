using UpSchoolChainOfResponsibility.DAL.Entities;

namespace UpSchoolChainOfResponsibility.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }
        public abstract void ProcessRequest(WithDrawModel p);
    }
}
