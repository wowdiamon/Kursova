using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace MyStoreNamespace
{
    public class Program
    {
        public static Account currentLoggedInUser = null;

        public static void Main(string[] args)
        {
            DbContext context = new DbContext();
            AccountRepository repository = new AccountRepository(context);
            AccountService accountService = new AccountService(repository);
            
            ProductRepository productRepository = new ProductRepository(context);
            ProductService productService = new ProductService(productRepository);
            
            OrderRepository orderRepository = new OrderRepository(context);
            OrderService orderService = new OrderService(orderRepository);
            
            bool isRunning = true;

            var mainMenuCommands = new Dictionary<string, ICommands>
            {
                { "1", new RegisterAccount(accountService) },
                { "2", new Login(accountService) }
            };
            var basicMenuCommands = new Dictionary<string, ICommands>
            {
                {"1", new ReplenishAccountBalance(accountService)},
                {"2",new ViewProfile(accountService)},
                {"3",new AddOrder(accountService,orderService,productService)},
                {"4",new UpdateAccount(accountService)},
                {"5",new ShowOrderHistory(accountService,orderService)},
                {"6",new ShowAllProducts(productService)},
                {"7",new Logout(accountService) },
            };
            var AdminMenuCommands = new Dictionary<string, ICommands>
            {
                { "1", new ReplenishAccountBalance(accountService) },
                { "2", new ViewProfile(accountService) },
                { "3", new AddOrder(accountService, orderService, productService) },
                { "4", new UpdateAccount(accountService) },
                { "5", new ShowOrderHistory(accountService, orderService) },
                { "6", new AddProduct(productService) },
                { "7", new ShowAllProducts(productService) },
                { "8", new DeleteProduct(productService) },
                { "9", new UpdateProduct(productService) },
                { "10", new Logout(accountService) },
            };
            while (isRunning)
            {
                Console.Clear();
                if (currentLoggedInUser == null)
                {
                    Console.WriteLine("Welcome to the Store!");
                    Console.WriteLine("=== Main Menu ===");
                    foreach (var option in mainMenuCommands)
                    {
                        Console.WriteLine($"{option.Key}. {option.Value.GetInfo()}");
                    }
                }
                else if (currentLoggedInUser.IsAdmin)
                {
                    Console.WriteLine("=== Admin Menu ===");
                    foreach (var option in AdminMenuCommands)
                    {
                        Console.WriteLine($"{option.Key}. {option.Value.GetInfo()}");
                    }
                }
                else
                {
                    Console.WriteLine("=== User Menu ===");
                    foreach (var option in basicMenuCommands)
                    {
                        Console.WriteLine($"{option.Key}. {option.Value.GetInfo()}");
                    }
                }
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    isRunning = false;
                }
                else if (currentLoggedInUser == null && mainMenuCommands.TryGetValue(choice, out var command))
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.ReadKey();
                    }
                }
                else if (!currentLoggedInUser.IsAdmin && basicMenuCommands.TryGetValue(choice, out var basicCommand))
                {
                    try
                    {
                        basicCommand.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.ReadKey();
                    }

                }
                else if (currentLoggedInUser.IsAdmin && AdminMenuCommands.TryGetValue(choice, out var adminCommand))
                {
                    try
                    {
                        adminCommand.Execute();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.ReadKey();
                }
            }
        }
    }
}