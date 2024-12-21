namespace MyStoreNamespace;

public class RegisterAccount : ICommands
{
    private readonly AccountService _accountService;

    public RegisterAccount(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Registration form ===");

        Console.Write("Enter a nickname : ");
        string UserName = Console.ReadLine();
        
        Console.Write("Password cannot contain spaces and password need to be at least 8 characters long\n");
        Console.Write("Enter password: ");
        string password = _accountService.ReadPassword();

        string passwordCheck;
        bool passwordsMatch = false;

        do
        {
            Console.Write("\nConfirm your password: ");
            passwordCheck = _accountService.ReadPassword();

            if (passwordCheck != password)
            {
                Console.WriteLine("\nPasswords do not match. Please try again.");
            }
            else
            {
                passwordsMatch = true;
            }
        } while (!passwordsMatch);

        Account newAccount = new Account(UserName, password);


        _accountService.AddAccount(newAccount);
        Console.WriteLine($"\n{UserName} has been added successfully.");
        Console.ReadKey();
        
    }

    public string GetInfo()
    {
        return "Register account";
    }
    
    
}