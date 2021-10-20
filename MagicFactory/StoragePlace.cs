using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    abstract class StoragePlace
    {
        protected List<InventoryItem> inventoryItems;
        protected List<InventoryItem> itemsToSend;

        public StoragePlace()
        {
            itemsToSend = new List<InventoryItem>();
        }
        public void AddItem(InventoryItem itemToAdd)
        {
            inventoryItems.Add(itemToAdd);
        }
        public void AddItems(List<InventoryItem> itemsToAdd)
        {
            for (int i = 0; i < itemsToAdd.Count; i++)
            {
                AddItem(itemsToAdd[i]);
            }
        }
        public void RemoveItem(InventoryItem itemToRemove)
        {
            if (inventoryItems.Contains(itemToRemove))
            {
                inventoryItems.Remove(itemToRemove);

            }

        }
        public void RemoveItems(List<InventoryItem> itemsToRemove)
        {
            for (int i = 0; i < itemsToRemove.Count; i++)
            {
                RemoveItem(itemsToRemove[i]);
            }
        }
        public void MoveToSend(InventoryItem addToSend)
        {
            if (inventoryItems.Any(x=>x.Name == addToSend.Name)) 
            {
                itemsToSend.Add(addToSend);
                var itemToRemove = inventoryItems.First(r => r.Name == addToSend.Name);
                inventoryItems.Remove(itemToRemove);
            }
                
        }
        public void MoveAllToSend()
        {
            itemsToSend.AddRange(inventoryItems);
            inventoryItems.Clear();
        }
        public List<InventoryItem> SendItems()
        {
            List<InventoryItem> temp = new List<InventoryItem>(itemsToSend);
            itemsToSend.Clear();
            return temp;
        }
        public void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine($"Current {this.GetType().Name} Inventory");
            foreach (InventoryItem item in inventoryItems)
            {
                Console.WriteLine($"{item.Name}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Items ready for transfer: ");
            foreach (InventoryItem item in itemsToSend)
            {
                Console.WriteLine($"{item.Name} ");
                
            }
            Console.WriteLine("--------------------------------");

        }

    }
}
