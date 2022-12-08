using CoinRush.Helpers;
using CoinRush_Chunk;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CoinRush.Managers
{
    public class ChunkManager : Singleton<ChunkManager>
    {
        [Header(" SETTINGS ")]
        [SerializeField][Range(2, 20)] private int maximumChunkToCreate;

        [Header(" ELEMENTS ")]
        [SerializeField] private Chunk startChunk;
        [SerializeField] private Chunk endChunk;
        [SerializeField] private Chunk[] chunkPrefabs;
        [SerializeField] private Transform chunksParent;

        private List<Chunk> _createdChunks = new List<Chunk>();

        private void Awake()
        {
            RandomLevel();
        }

        [ContextMenu("Create Random Level")]
        private void RandomLevel()
        {
            _createdChunks.Clear();  
            CreateStartChunk();
            for (int i = 0; i < RandomChunkAmount(); i++)
            {
                var createdChunk = Instantiate(chunkPrefabs[RandomChunkPrefab()], chunksParent);
                createdChunk.transform.position = SetPosition(createdChunk, _createdChunks[^1].GetEndPoint());
                _createdChunks.Add(createdChunk);
            }
            CreateEndChunk();
        }
        private void CreateStartChunk()
        {
            var createdChunk = Instantiate(startChunk, chunksParent);
            _createdChunks.Add(createdChunk);
        }

        private void CreateEndChunk()
        {
            var createdChunk = Instantiate(endChunk, chunksParent);
            createdChunk.transform.position = SetPosition(createdChunk, _createdChunks[^1].GetEndPoint());
            _createdChunks.Add(createdChunk);
        }
        private int RandomChunkAmount() => Random.Range(2, maximumChunkToCreate);
        private int RandomChunkPrefab() => Random.Range(0, chunkPrefabs.Length);
        
        private Vector3 SetPosition(Chunk createdChunk, Transform lastChunkEndPoint)
        {
            return new Vector3(
                createdChunk.transform.position.x,
                createdChunk.transform.position.y,
                Mathf.Abs(createdChunk.GetStartPoint().position.z) + lastChunkEndPoint.position.z);
        }

        public Transform EndPosition() => _createdChunks[^1].transform;

    }
}
