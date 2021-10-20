using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class WheelBlueprint : Blueprints
    {
        private Dictionary<string, int> Requirements = new Dictionary<string, int>
        { 
            { "Rubber",1},
            {"Steel",2}
        };

        public override int AmountNeededToCraft { get; }
        public WheelBlueprint()
        {
            AmountNeededToCraft = 3;
        
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
                inputMaterials.Add(new ProducedItems("Wheel"));
                Console.WriteLine("Crafted Wheel");
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
