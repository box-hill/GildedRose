namespace GildedRose.Console.Items
{
    public class BackstagePass : UpdatableItem
    {
        public override void UpdateItem()
        {
            if (SellIn <= 0) // Past concert
            {
                Quality = 0;
                SellIn--;
                return;
            }

            Quality++;
            if (SellIn < 11) Quality++;
            if (SellIn < 6) Quality++;

            // Quality cannot exceed 50
            if (Quality > 50) Quality = 50;
            SellIn--;
        }
    }
}
