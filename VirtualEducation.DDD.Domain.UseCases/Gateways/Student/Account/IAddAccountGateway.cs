using VirtualEducation.DDD.Domain.Student.Commands.Account;
using VirtualEducation.DDD.Domain.Student.Repositories;

namespace VirtualEducation.DDD.Domain.UseCases.Gateways.Student.Account
{
    public interface IAddAccountGateway
    {
        Task AddAccount(AddAccountCommand command);
    }
}
