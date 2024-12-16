using System;
using System.Collections.Generic;

using MyStoreNamespace;

namespace MyStoreNamespace;

public interface IAccountService
{
        void AddAccount(Account account);
        Account GetAccountById(int id);
        void UpdateAccount(int playerId,string newName,string newPassword);
        void DeleteAccount(int id);
        int FindIDByUsername(string username);
}
