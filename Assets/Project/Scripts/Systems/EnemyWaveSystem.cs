using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    private class EnemyGroup
    {
        public int AmountToSpawn;
        public GameObject EnemyPrefab;

        public override string ToString()
        {
            return "EC:" + AmountToSpawn + " EnemyPefab:" + EnemyPrefab.name;
        }
    }

    [SerializeField] private List<WaveData> waves;
    private int currentWaveIndex = 0;
    private List<EnemyGroup> enemiesToSpawn = new();
    private Timer spawnTimer = new();

    private void Start()
    {
        BeginWave();
    }

    private void Update()
    {
        spawnTimer.Update(Time.deltaTime);
    }

    private void NextWave()
    {
        if(currentWaveIndex < waves.Count - 1)
        {
            currentWaveIndex++;
        }
    }

    private void BeginWave()
    {
        enemiesToSpawn.Clear();

        WaveData waveData = waves[currentWaveIndex];
        foreach(EnemyGroupData data in waveData.EnemyGroups)
        {
            EnemyGroup enemyGroup = new EnemyGroup()
            {
                AmountToSpawn = data.EnemyCount,
                EnemyPrefab = data.EnemyPrefab
            };
            enemiesToSpawn.Add(enemyGroup);
        }

        spawnTimer = new Timer(waves[currentWaveIndex].SpawnInterval,false);
        spawnTimer.Timeout += SpawnEnemies;
        spawnTimer.Start();
    }

    private void SpawnEnemies()
    {
        List<EnemyGroup> possibleEnemies = new();
        foreach(EnemyGroup group in enemiesToSpawn)
        {
            if(group.AmountToSpawn > 0)
            {
                possibleEnemies.Add(group);
                Debug.Log(group);
            }
        }

        if(possibleEnemies.Count > 0)
        {
            EnemyGroup group = possibleEnemies[Random.Range(0,possibleEnemies.Count-1)];
            group.AmountToSpawn--;

            Vector3 pos = GetPositionOutsideCameraView();

            Instantiate(group.EnemyPrefab,pos,Quaternion.identity);
        }
        else
        {
            spawnTimer.Stop();
        }
    }

    private Vector3 GetPositionOutsideCameraView()
    {
        Vector3 downLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 upRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        float extraPadding = 1.0f;
        downLeft -= new Vector3(extraPadding, extraPadding, 0);
        upRight += new Vector3(extraPadding, extraPadding, 0);

        //TODO

        return new Vector3(Random.Range(downLeft.x,upRight.x), Random.Range(downLeft.y,upRight.y),1.0f);
    }
}
