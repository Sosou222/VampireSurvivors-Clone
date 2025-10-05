using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    private Dictionary<Vector2, TerrainChunk> chunks = new();
    private Vector2 chunkSize = new Vector2(20, 20);
    private List<Vector2> lastChunkIDLoad = new();

    private void Start()
    {
        UpdateChunks();
    }

    private void Update()
    {
        UpdateChunks();
    }

    private void UpdateChunks()
    {
        float radius = 30.0f;
        Vector3 playerPosition = PlayerInfoSystem.Instance.GetPosition();
        List<Vector2> chunksIDS = GetChunkPointsWithinRadius(new Vector2(playerPosition.x, playerPosition.y), radius,chunkSize);
        List<Vector2> newChunkIDLoad = new();
        foreach (var chunk in chunksIDS)
        {
            newChunkIDLoad.Add(chunk/chunkSize);
        }
        if(!lastChunkIDLoad.DoesCointainSame(newChunkIDLoad))
        {
            List<Vector2> toUnload = lastChunkIDLoad.Except(newChunkIDLoad).ToList();
            foreach (var chunk in toUnload)
            {
                UnLoadChunk(chunk);
            }
            foreach (var chunk in newChunkIDLoad)
            {
                LoadChunk(chunk);
            }
            lastChunkIDLoad.Clear();
            lastChunkIDLoad.AddRange(newChunkIDLoad);
        }
        
    }

    List<Vector2> GetChunkPointsWithinRadius(Vector2 center, float radius, Vector2 step)
    {
        List<Vector2> result = new List<Vector2>();

        Vector2Int steps = new Vector2Int(Mathf.CeilToInt(radius / step.x), Mathf.CeilToInt(radius / step.y));

        for (int x = -steps.x; x <= steps.x; x++)
        {
            for (int y = -steps.y; y <= steps.y; y++)
            {
                Vector2 point = new Vector2(
                    Mathf.Round(center.x / step.x) * step.x + x * step.x,
                    Mathf.Round(center.y / step.y) * step.y + y * step.y
                );

                if (Vector2.Distance(center, point) <= radius)
                {
                    result.Add(point);
                }
            }
        }

        return result;
    }

    private void LoadChunk(Vector2 chunkID)
    {
        if(chunks.ContainsKey(chunkID))
        {
            chunks[chunkID].gameObject.SetActive(true);
        }
        else
        {
            Vector3 chunkPos = chunkSize * chunkID;
            TerrainChunk chunk = ChunkCreator.Instance.CreateChunk(chunkPos);
            chunk.gameObject.transform.parent = transform;
            chunks[chunkID] = chunk;
        }
    }

    private void UnLoadChunk(Vector2 chunkID)
    {
        if (chunks.ContainsKey(chunkID))
        {
            chunks[chunkID].gameObject.SetActive(false);
        }
    }
}
