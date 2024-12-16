using MyStoreNamespace;
using System;
using System.Collections.Generic;

namespace MyStoreNamespace
{
    public class AccountService : IAccountService
    {
        public AccountRepository Repository { get; set; }

        public AccountService(AccountRepository repository)
        {
            this.Repository = repository;
        }
        
        public Account GetAccountById(int id)
        {
            var account = Repository.ReadById(id);
            if (account == null)
            {
                throw new ArgumentException($"Account with ID {id} not found.");
            }
            return account;
        }

        public void AddAccount(Account account)
        {
            var checkUserName =FindIDByUsername(account.UserName);
            if (checkUserName == null)
            {
                Repository.Create(account);
            }
        }

        public void UpdateAccount(int playerId,string newName,string NewPassword)
        {
            Repository.Update(playerId,newName, NewPassword);
        }

        public void DeleteAccount(int id)
        {
            Repository.Delete(id);
        }

        public string ReadPassword()
        {
            
            string password = string.Empty;
            int charCount = 0;  
            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b"); 
                    password = password[0..^1]; 
                    charCount--; 
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    if (char.IsWhiteSpace(keyInfo.KeyChar)) 
                    {
                        Console.Write("\b \b"); 
                        Console.WriteLine("\nSpaces are not allowed in the password.");
                    }
                    else
                    {
                        Console.Write("*"); 
                        password += keyInfo.KeyChar; 
                        charCount++; 
                    }
                }

            } while (key != ConsoleKey.Enter ); 

            Console.WriteLine(); 

            if (charCount < 8)
            {
                Console.WriteLine("Password must be more than 8 characters.");
                return ReadPassword(); 
            }
            return password;
        }


        public Account Authenticate(int AccountId, string password)
        {
            var account = Repository.ReadById(AccountId);

            return account != null && account.Password == password
                    ? account
                    : null;
        }


        public int FindIDByUsername(string username)
        {
            return Repository.FindIDByUsername(username);
        }
    }
}

