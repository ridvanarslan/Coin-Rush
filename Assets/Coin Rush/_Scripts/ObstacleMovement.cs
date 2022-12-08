using UnityEngine;
using DG.Tweening;
using CoinRush.Enums;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CoinRush.Obstacle
{
    public class ObstacleMovement : MonoBehaviour
    {
        [SerializeField] private MovementType movementType;

        [Header("-> ROTATE SETTINGS")]
        [SerializeField][Range(0.1f, 5f)] private float rotateTime;
        [SerializeField] private Vector3 rotateDirection;

        [Header("-> YOYO SETTINGS")]
        [SerializeField][Range(0.1f, 5f)] private float yoyoTime;
        [SerializeField] private Vector3 yoyoRange;



        private void Start()
        {
            StartRotate();
            StartYoyoMovement();
        }

        private void StartRotate()
        {
            if (movementType == MovementType.YoYo) return;
            transform.DORotate(rotateDirection, rotateTime).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }

        private void StartYoyoMovement()
        {
            if (movementType == MovementType.Rotate) return;
            transform.DOMove(transform.position + yoyoRange, yoyoTime, false).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}

