using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class InventoryItem
    {
        public string Name { get; protected set; }

        protected InventoryItem(string name)
        {
            Name = name;
        }

    }
}
