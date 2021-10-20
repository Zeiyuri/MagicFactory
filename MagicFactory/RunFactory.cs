using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    static class RunFactory
    {
        public static void Run()
        {
            List<InventoryItem> listOfItems = new List<InventoryItem>()
            {
                new RawMaterial("Rubber"),
                new RawMaterial("Steel"),
                new ProducedItems("Wheel"),
                new ProducedItems("Car")
            };
            Warehouse myWarehouse = new Warehouse();
            Factory myFactory = new Factory();
            while (true)
            {
                PrintOptions();

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Write an item to add");
                        string itemToAdd = Console.ReadLine();
                        if (listOfItems.Any(x => x.Name.Equals(itemToAdd, StringComparison.OrdinalIgnoreCase)))
                        {
                            myWarehouse.AddItem(listOfItems.Find(x => x.Name.Equals(itemToAdd, StringComparison.OrdinalIgnoreCase)));
                        }

                        
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        myWarehouse.PrintInventory();

                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Choose an item to transfer:");
                        string addedToTransferList = Console.ReadLine();
                        if (listOfItems.Any(x => x.Name.Equals(addedToTransferList, StringComparison.OrdinalIgnoreCase)))
                        {
                            myWarehouse.MoveToSend(listOfItems.Find(x => x.Name.Equals(addedToTransferList, StringComparison.OrdinalIgnoreCase)));
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                        myWarehouse.MoveAllToSend();
                        Console.Clear();
                        break;
                    case ConsoleKey.D5:

                        Console.Clear();
                        List<InventoryItem> temp = new List<InventoryItem>(myWarehouse.SendItems());
                        Console.WriteLine("Items below have been sent to factory:");
                        foreach(InventoryItem item in temp)
                        {
                            Console.WriteLine($"{item.Name} ");
                        }
                        myFactory.AddItems(temp);
                        myFactory.ProduceItems();
                        myFactory.MoveAllToSend();
                        myWarehouse.AddItems(myFactory.SendItems());

                        break;

                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            }

        }
        static void PrintOptions()
        {
            Console.WriteLine("Choose what you want to do:");
            Console.WriteLine("1. Add items to inventory");
            Console.WriteLine("2. List items in inventory");
            Console.WriteLine("3. Add specific item to estimated delivery");
            Console.WriteLine("4. Add all items to estimated delivery");
            Console.WriteLine("5. Send Chosen Items to Factory");
        }

    }
}
