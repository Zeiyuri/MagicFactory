using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicFactory
{
    class Warehouse : StoragePlace
    {
        public Warehouse() : base()
        {
            inventoryItems = new List<InventoryItem>
            {
                new RawMaterial("Rubber"),
                new RawMaterial("Rubber"),
                new RawMaterial("Steel"),
                new RawMaterial("Steel"),
                new RawMaterial("Steel"),
                new RawMaterial("Steel"),
                new RawMaterial("Steel"),
                new ProducedItems("Wheel"),
                new ProducedItems("Wheel"),
                new ProducedItems("Wheel")


            };
        }
    }
}
