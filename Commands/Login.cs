namespace MyStoreNamespace;

public class Login : ICommands
{
    private readonly AccountService _accountService;

    public Login(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Login ===");

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        int id = _accountService.FindIDByUsername(username);

        Console.Write("Enter your password: ");
        string password = _accountService.ReadPassword();

        var account = _accountService.Authenticate(id, password);
        if (account != null)
        {
            if (account.LoggedIn)
            {
                Console.WriteLine("This account is already logged in. Please log out first.");
                Console.ReadKey();
                return;
            }

            account.Login();
            Program.currentLoggedInUser = account;
            Console.WriteLine($"Welcome, {account.UserName}!");
        }
        else
        {
            Console.WriteLine("Invalid credentials. Please try again.");
            Console.ReadKey();
        }
    }

    public string GetInfo()
    {
        return "Login to your account";
    }

}