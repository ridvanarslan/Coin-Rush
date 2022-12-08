using CoinRush.Abstracts;
using CoinRush.Player;

namespace CoinRush.Bonuses
{
    public class LifeBonus : Bonus
    {
        public override void GiveBonus(ref PlayerController player)
        {
            player.AddExtraLife();
            this.gameObject.SetActive(false);
        }
    }
}
