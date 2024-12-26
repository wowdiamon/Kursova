    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MyStoreNamespace;

    namespace MyStoreNamespace;

    public class AccountRepository: IAccountRepository
    {
         public DbContext Context { get; set; }
         
         public AccountRepository(DbContext Context)
         {
             this.Context = Context;
         }
         
         public void Create(Account account)
             {
                 Context.Accounts.Add(account);
             }
             
             public Account ReadById(int id)
             {
                 return Context.Accounts.FirstOrDefault(p => p.Id == id);
             }

             public void Update(int playerId, string newName,string newPassword)
             {
                 var existingAccountIndex = Context.Accounts.FindIndex(p => p.Id == playerId);
                 var existingAccount = Context.Accounts[existingAccountIndex];
                 Account.ReleaseId(existingAccount.Id);
                 int id = existingAccount.Id;
                 decimal Balance = existingAccount.Balance;
                 Delete(playerId);

                 Account updatedAccount = new Account(newName, newPassword);

                 updatedAccount.Id = id;
                 updatedAccount.Balance = Balance;

                 Create(updatedAccount);
             }
             
             public void Delete(int id)
             {
                 var account = ReadById(id);
                 if (account != null)
                 {
                     Context.Accounts.Remove(account);
                 }
             }

             public int FindIDByUsername(string username)
             {
                 var player = Context.Accounts.FirstOrDefault(p => p.UserName == username);
                 return player?.Id ?? -1;
             }
    }




