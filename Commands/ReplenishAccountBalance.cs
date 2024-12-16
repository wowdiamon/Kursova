namespace MyStoreNamespace;

public class ReplenishAccountBalance : ICommands
{
    private readonly AccountService _accountService;

    public ReplenishAccountBalance(AccountService accountService)
    {
        _accountService = accountService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Replenish Account ===");
        int amount;
        Console.Write("Enter amount you wanna add to balance: ");
        string input = Console.ReadLine();

        while (!int.TryParse(input, out amount) || amount < 0)
        {
            Console.WriteLine("Invalid input. Please enter a non-negative integer:");
            input = Console.ReadLine();
        }
        Program.currentLoggedInUser.Balance += amount;
        Console.WriteLine("Balance updated successfully.");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Replenish account balance";
    }
}