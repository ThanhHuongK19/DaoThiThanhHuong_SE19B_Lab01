using BusinessObjects.Models;
using DataAccessObjects;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountById(string accountID) => AccountDAO.GetAccountById(accountID)!;

        public AccountMember GetAccountByEmail(string email) => AccountDAO.GetAccountByEmail(email)!;
    }
}
