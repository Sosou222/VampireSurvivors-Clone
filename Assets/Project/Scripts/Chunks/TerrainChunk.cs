using System.Collections.Generic;
using UnityEngine;

public class TerrainChunk : MonoBehaviour
{
    [SerializeField] private List<Sprite> propSpritesList;
    [SerializeField] private List<SpriteRenderer> spriteRenderers;
    private void Start()
    {
        AssignSprites();
    }

    public void AssignSprites()
    {
        foreach (var renderer in spriteRenderers)
        {
            renderer.sprite = propSpritesList[Random.Range(0,propSpritesList.Count-1)];
        }
    }
}
