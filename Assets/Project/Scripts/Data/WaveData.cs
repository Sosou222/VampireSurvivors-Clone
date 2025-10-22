using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Wave", fileName = "Wave")]
public class WaveData : ScriptableObject
{
    public string WaveName;
    public List<EnemyGroupData> EnemyGroups;
    public float SpawnInterval;
}

[System.Serializable]
public class EnemyGroupData
{
    public int EnemyCount; //How much spawn this wave
    public GameObject EnemyPrefab;
}