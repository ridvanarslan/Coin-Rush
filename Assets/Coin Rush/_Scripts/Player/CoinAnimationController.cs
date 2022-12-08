using UnityEngine;

namespace CoinRush.Player
{
    public class CoinAnimationController : MonoBehaviour
    {
        private Animator _coinAnimator;

        private void Awake() => _coinAnimator = GetComponent<Animator>();

        private static int CoinCollected = Animator.StringToHash("CoinCollected");
        private static int FallAnimation = Animator.StringToHash("FallAnimation");
        
        public void CollectAnimation() => _coinAnimator.Play(CoinCollected);
        public void CoinFallAnimation() => _coinAnimator.Play(FallAnimation);
    }
}
