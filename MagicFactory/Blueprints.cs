using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    abstract class Blueprints
    {
        //private Dictionary<string, int> Requirements;
        public abstract int AmountNeededToCraft { get; }
        public abstract List<InventoryItem> ProduceItem(List<InventoryItem> inputMaterials);
        public abstract bool IsCraftable(List<InventoryItem> inputMaterials);
    }
}
