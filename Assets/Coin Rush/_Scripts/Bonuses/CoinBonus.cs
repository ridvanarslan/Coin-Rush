using CoinRush.Abstracts;
using CoinRush.Player;

namespace CoinRush.Bonuses
{
    public class CoinBonus : Bonus
    {
        public override void GiveBonus(ref PlayerController player)
        {
            player.AddExtraCoin();
            this.gameObject.SetActive(false);
        }
    }
}
