namespace MyStoreNamespace;

public class ViewProfile : ICommands
{
    private readonly AccountService _accountService;

    public ViewProfile(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        var user = _accountService.GetAccountById(Program.currentLoggedInUser.Id);

        if (user == null)
        {
            Console.WriteLine("User not found.");
        }
        else
        {

            Console.Clear();
            Console.WriteLine("=== User Profile ===");
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Name: {user.UserName}");
            Console.WriteLine($"Balance: {user.Balance}");
        }

        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "View profile";
    }
}