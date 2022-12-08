using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CoinRush_Chunk
{
    public class Chunk : MonoBehaviour
    {
        [Header(" SETTINGS ")]
        [SerializeField] private Vector3 size;

        [Header(" ELEMENTS ")]
        [SerializeField] private Transform chunkEndPoint;
        [SerializeField] private Transform chunkStartPoint;

        public Transform GetEndPoint() => chunkEndPoint;
        public Transform GetStartPoint() => chunkStartPoint;
        public float ChunkSize() => size.z;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position,size);
        }
    }
}


