using VirtualEducation.DDD.Domain.Student.Entities;
using VirtualEducation.DDD.Domain.Student.ValueObjects.Account;

namespace VirtualEducation.DDD.Domain.Student.Repositories
{
    public interface IAccountRepository
    {
        Task AddAccount(AccountStudent account);
        Task UpdateAccountDetail(AccountID accountID, AccountDetail accountDetail);
    }
}
