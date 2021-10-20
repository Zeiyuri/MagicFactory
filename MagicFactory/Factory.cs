using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class Factory : StoragePlace
    {
        private List<Blueprints> _craftableBlueprints = new List<Blueprints>()
        {
            new WheelBlueprint(),
            new CarBlueprint()
        };
        public Factory() : base()
        {
            inventoryItems = new List<InventoryItem>();
        }

        public void ProduceItems()
        {
            _craftableBlueprints = SortBlueprints();
            foreach (Blueprints item in _craftableBlueprints)
            {
                inventoryItems = item.ProduceItem(inventoryItems);
            }
        }
        public List<Blueprints> SortBlueprints()
        {
            List<Blueprints> SortedList = _craftableBlueprints.OrderByDescending(o => o.AmountNeededToCraft).ToList();
            Console.WriteLine("Print of sorted list for testing purpose");
            foreach (var item in SortedList)
            {
                Console.WriteLine(item.GetType());
            }
            return SortedList;
        }
    }
}
