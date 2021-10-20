using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class ProducedItems : InventoryItem
    {
        public ProducedItems(string name) : base(name)
        {
            Name = name;
        }
    }
}
