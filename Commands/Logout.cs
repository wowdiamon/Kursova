namespace MyStoreNamespace;

public class Logout : ICommands
{
    private readonly AccountService _accountService;

    public Logout(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        var account = _accountService.Authenticate(Program.currentLoggedInUser.Id, Program.currentLoggedInUser.Password);
        if (account != null)
        {
            account.Logout();
            Program.currentLoggedInUser = null;
        }
    }

    public string GetInfo()
    {
        return "Logout account";
    }
}