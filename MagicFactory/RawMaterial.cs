using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class RawMaterial : InventoryItem
    {
        public RawMaterial(string name) : base(name)
        {
            Name = name;
        }
    }
}
