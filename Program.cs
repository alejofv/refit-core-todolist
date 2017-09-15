using System;
using System.Threading.Tasks;
using System.Linq;
using Refit;

namespace TodoClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiClient = RestService.For<Services.ITodoService>("http://localhost:59944");

            do
            {
                Console.WriteLine("Reading TodoItems from the Api...");
                Console.WriteLine();

                var items = await apiClient.GetAll();

                var index = 0;
                var numberedItems = items
                    .Select(
                        i => new {
                            Number = ++index,
                            Item = i,
                        })
                    .ToList();

                foreach(var item in numberedItems)
                    Console.WriteLine($"{item.Number, 3}: {item.Item}");

                Console.WriteLine();
                
                var isKeyValid = false;
                do
                {
                    Console.WriteLine($"What do you want to do? ([C]reate a new item, [M]ark item as complete, [Q]uit) ");
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.C:
                            isKeyValid = true;

                            Console.Write("Item Title: ");
                            var title = Console.ReadLine();

                            var newItemId = await apiClient.Create(title);
                            Console.WriteLine("Created new item: " + newItemId);

                            break;
                        
                        case ConsoleKey.M:
                            isKeyValid = true;

                            Console.Write("Item no: ");
                            var number = int.Parse(Console.ReadLine());

                            var item = numberedItems
                                .FirstOrDefault(i => i.Number == number);

                            if (item != null)
                            {
                                await apiClient.Complete(item.Item.Id);
                                Console.WriteLine("Marked as Complete");
                            }
                            else
                            {
                                Console.WriteLine("Item not found");
                            }

                            break;
                        
                        case ConsoleKey.Q:
                            return;
                    }
                }
                while(!isKeyValid);

                await Task.Delay(2000);
                Console.Clear();
            }
            while(true);
        }
    }
}
