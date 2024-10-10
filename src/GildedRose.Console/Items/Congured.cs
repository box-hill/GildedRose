namespace GildedRose.Console.Items
{
    public class Congured : UpdatableItem
    {
        public override void UpdateItem()
        {
            SellIn--;

            // Decrease Quality based on SellIn
            Quality = SellIn < 0 ? Quality - 4 : Quality - 2;

            // Quality cannot be negative
            if (Quality < 0) Quality = 0; 
        }
    }
}
