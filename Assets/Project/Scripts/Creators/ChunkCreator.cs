using UnityEngine;

public class ChunkCreator : Singleton<ChunkCreator>
{
    [SerializeField] private TerrainChunk chunkPrefab;

    public TerrainChunk CreateChunk(Vector3 position)
    {
        TerrainChunk chunk = Instantiate(chunkPrefab, position, Quaternion.identity);
        return chunk;
    }
}
