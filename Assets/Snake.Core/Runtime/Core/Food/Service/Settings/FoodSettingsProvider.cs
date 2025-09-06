namespace Snake.Core
{
    public class FoodSettingsProvider : IFoodSettingsProvider
    {
        private static readonly int POINTS_PER_FOOD = 10;
        public int GetFoodScore()
        {
            return 10;
        }
    }
}