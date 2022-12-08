using CoinRush.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoinRush.Abstracts
{
    public abstract class Bonus : MonoBehaviour
    {
        public abstract void GiveBonus(ref PlayerController player);

    }
}
