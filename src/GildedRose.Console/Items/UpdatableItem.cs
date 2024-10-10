using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Items
{
    public class UpdatableItem : Item
    {
        public virtual void UpdateItem()
        {
            // Default behavior for normal items
            SellIn--;

            // Decrease Quality based on SellIn
            Quality = SellIn < 0 ? Quality - 2 : Quality - 1;

            // Quality cannot be negative
            if (Quality < 0) Quality = 0; 
        }
    }
}
