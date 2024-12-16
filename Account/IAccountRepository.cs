namespace MyStoreNamespace
{
    public interface IAccountRepository
    {
        void Create(Account account);
        Account ReadById(int id);
        void Update(int playerId,string newName,string NewPassword);
        void Delete(int id);
        int FindIDByUsername(string username);
    }
}