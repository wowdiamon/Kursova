namespace MyStoreNamespace;

public class UpdateAccount : ICommands
{
    private readonly AccountService _accountService;

    public UpdateAccount(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Update Account ===");

        var account = Program.currentLoggedInUser;
        
        Console.Write("Enter new username: ");
        string newUsername = Console.ReadLine();

        Console.Write("Enter new password: ");
        string newPassword = _accountService.ReadPassword();

        _accountService.UpdateAccount(account.Id, newUsername, newPassword);
        Console.WriteLine("Account updated successfully.");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Update account";
    }
}