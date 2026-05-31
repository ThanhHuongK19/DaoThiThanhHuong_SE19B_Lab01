using BusinessObjects.Models;

namespace Repositories.Interfaces
{
    public interface IAccountRepository
    {
        AccountMember GetAccountById(string accountID);
        AccountMember GetAccountByEmail(string email);
    }
}
