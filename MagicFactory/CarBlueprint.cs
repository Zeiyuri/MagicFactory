using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class CarBlueprint : Blueprints
    {
        private Dictionary<string, int> Requirements = new Dictionary<string, int>
        {
            { "Steel",3},
            {"Wheel",4}
        };
        public override int AmountNeededToCraft { get; }
        public CarBlueprint()
        {
            AmountNeededToCraft = 7;

        }
        public override List<InventoryItem> ProduceItem(List<InventoryItem> inputMaterials)
        {
            bool ItemIsCraftable = IsCraftable(inputMaterials);
            if (ItemIsCraftable)
            {
                foreach (var item in Requirements)
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        inputMaterials.Remove(inputMaterials.First(r => r.Name == item.Key));
                    }
                }
                inputMaterials.Add(new ProducedItems("Car"));
                Console.WriteLine("Crafted Car");
                return inputMaterials;

            }
            else
            {
                return inputMaterials;
            }

        }
        public override bool IsCraftable(List<InventoryItem> inputMaterials)
        {
            foreach (var item in Requirements)
            {
                bool isCraftable = inputMaterials.FindAll(x => x.Name == item.Key).Count < item.Value;
                if (isCraftable)
                {
                    return false;
                }
            }
            return true;


        }
    }
}
