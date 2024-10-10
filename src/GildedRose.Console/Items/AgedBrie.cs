using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Items
{
    public class AgedBrie : UpdatableItem
    {
        public override void UpdateItem()
        {
            SellIn--;

            // Increase Quality 
            Quality = SellIn < 0 ? Quality + 2 : Quality + 1;

            // Quality cannot exceed 50
            if (Quality > 50) Quality = 50; 
        }
    }
}
