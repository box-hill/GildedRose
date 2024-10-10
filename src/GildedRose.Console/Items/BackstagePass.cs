namespace GildedRose.Console.Items
{
    public class BackstagePass : UpdatableItem
    {
        public override void UpdateItem()
        {
            if (SellIn <= 0) 
            {
                Quality = 0; // Set Quality to 0 for expired passes
                SellIn--;
                return;
            }

            // Quality should increase based on SellIn
            Quality++;
            if (SellIn < 11) Quality++;
            if (SellIn < 6) Quality++;

            // Quality cannot exceed 50
            if (Quality > 50) Quality = 50;
            SellIn--;
        }
    }
}
