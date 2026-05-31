using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class AccountDAO
    {
        public static AccountMember? GetAccountById(string accountID)
        {
            using var db = new MyStoreContext();
            return db.AccountMembers.FirstOrDefault(c => c.MemberId != null && c.MemberId == accountID);
        }

        public static AccountMember? GetAccountByEmail(string email)
        {
            using var db = new MyStoreContext();
            return db.AccountMembers.FirstOrDefault(c => c.EmailAddress != null && c.EmailAddress == email);
        }
    }
}
