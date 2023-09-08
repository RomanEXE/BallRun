using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChunksGenerator : MonoBehaviour
{
    [SerializeField] private List<Chunk> _spawnedChunks;
    [SerializeField] private Chunk[] _chunksPrefabs;
    [SerializeField] private Chunk _firstChunk;

    private void Start()
    {
        _spawnedChunks.Add(_firstChunk);
    }

    private void Update()
    {
        if (Player.Instance.transform.position.z > _spawnedChunks[^1]._endPoint.position.z - 150f)
            SpawnChunk();
    }

    private void SpawnChunk()
    {
        var spawnedChunk = Instantiate(_chunksPrefabs[Random.Range(0, _chunksPrefabs.Length)]);
        spawnedChunk.transform.position = _spawnedChunks[^1]._endPoint.position - spawnedChunk._startPoint.position;
        _spawnedChunks.Add(spawnedChunk);
        
        if (_spawnedChunks.Count > 3)
            DestroyChunk();
    }

    private void DestroyChunk()
    {
        Destroy(_spawnedChunks[0].gameObject);
        _spawnedChunks.RemoveAt(0);
    }
}