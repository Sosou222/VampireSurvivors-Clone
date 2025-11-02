using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSystem : MonoBehaviour
{
    private class EnemyGroup
    {
        public int AmountToSpawn;
        public GameObject EnemyPrefab;
        public SpawnEnemyPattern Pattern;
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
                EnemyPrefab = data.EnemyPrefab,
                Pattern = data.Pattern
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
            }
        }

        if(possibleEnemies.Count > 0)
        {
            EnemyGroup group = possibleEnemies[Random.Range(0,possibleEnemies.Count-1)];
            group.AmountToSpawn--;

            Vector3 pos = GetPositionOutsideCameraView(group.Pattern);

            GameObject enemy = Instantiate(group.EnemyPrefab,pos,Quaternion.identity);
            if(enemy.TryGetComponent(out Enemy e))
            {
                SetEnemyMovement(group.Pattern, e);
            }
        }
        else
        {
            spawnTimer.Stop();
        }
    }

    private void SetEnemyMovement(SpawnEnemyPattern pattern,Enemy enemy)
    {
        if (pattern == SpawnEnemyPattern.Random)
        {
            enemy.SetTargetPoint(new TargetPointPlayer());
        }
        if (pattern == SpawnEnemyPattern.Circle)
        {
            TargetPointStatic s = new TargetPointStatic();

            s.SetPoint(PlayerInfoSystem.Instance.GetPosition());
            enemy.SetTargetPoint(s);
        }
        if(pattern == SpawnEnemyPattern.Left)
        {
            TargetPointStatic s = new TargetPointStatic();
            Vector3 walk = new Vector3(20, 0, 0);

            s.SetPoint(enemy.transform.position + walk);
            enemy.SetTargetPoint(s);
        }
        if (pattern == SpawnEnemyPattern.Right)
        {
            TargetPointStatic s = new TargetPointStatic();
            Vector3 walk = new Vector3(-20, 0, 0);

            s.SetPoint(enemy.transform.position + walk);
            enemy.SetTargetPoint(s);
        }
        if (pattern == SpawnEnemyPattern.Down)
        {
            TargetPointStatic s = new TargetPointStatic();
            Vector3 walk = new Vector3(0, 20, 0);

            s.SetPoint(enemy.transform.position + walk);
            enemy.SetTargetPoint(s);
        }
        if (pattern == SpawnEnemyPattern.Up)
        {
            TargetPointStatic s = new TargetPointStatic();
            Vector3 walk = new Vector3(0, -20, 0);

            s.SetPoint(enemy.transform.position + walk);
            enemy.SetTargetPoint(s);
        }
    }

    private Vector3 GetPositionOutsideCameraView(SpawnEnemyPattern pattern)
    {
        Vector3 downLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 upRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        float extraPadding = 1.0f;
        downLeft -= new Vector3(extraPadding, extraPadding, 0);
        upRight += new Vector3(extraPadding, extraPadding, 0);

        Vector3 point = new Vector3(0, 0, 0);
        float range = 2.0f;
        switch (pattern)
        {
            case SpawnEnemyPattern.Random:
            case SpawnEnemyPattern.Circle:
                point = GetPointOutsideRect(downLeft, upRight, range);
                break;

            case SpawnEnemyPattern.Left:
                point = new Vector3(downLeft.x - range, Random.Range(downLeft.y, upRight.y), 0);
                break;

            case SpawnEnemyPattern.Right:
                point = new Vector3(upRight.x + range, Random.Range(downLeft.y, upRight.y), 0);
                break;

            case SpawnEnemyPattern.Up:
                point = new Vector3(Random.Range(downLeft.x, upRight.x), upRight.y + range, 0);
                break;

            case SpawnEnemyPattern.Down:
                point = new Vector3(Random.Range(downLeft.x, upRight.x), downLeft.y - range, 0);
                break;
        }

        return point;
    }


    private Vector3 GetPointOutsideRect(Vector3 downLeft,Vector3 upRight,float range)
    {
        Vector3 point = Vector3.zero;

        int rand = Random.Range(0, 7);

        switch (rand)
        {
            case 0://Left
                point = new Vector3(Random.Range(downLeft.x - range, downLeft.x), Random.Range(downLeft.y,upRight.y), 0);
                break;

            case 1://Right
                point = new Vector3(Random.Range(upRight.x, upRight.x + range), Random.Range(downLeft.y, upRight.y), 0);
                break;

            case 2://Up
                point = new Vector3(Random.Range(downLeft.x, upRight.x), Random.Range(upRight.y, upRight.y + range), 0);
                break;

            case 3://Down
                point = new Vector3(Random.Range(downLeft.x, upRight.x), Random.Range(downLeft.y - range, downLeft.y), 0);
                break;

            case 4://UpLeft
                point = new Vector3(Random.Range(downLeft.x - range, downLeft.x), Random.Range(upRight.y, upRight.y + range), 0);
                break;

            case 5://DownLeft
                point = new Vector3(Random.Range(downLeft.x - range, downLeft.x), Random.Range(downLeft.y - range, downLeft.y), 0);
                break;

            case 6://UpRight
                point = new Vector3(Random.Range(upRight.x, upRight.x + range), Random.Range(upRight.y, upRight.y + range), 0);
                break;

            case 7://DownRight
                point = new Vector3(Random.Range(upRight.x, upRight.x + range), Random.Range(downLeft.y - range, downLeft.y), 0);
                break;
        }

        return point;
    }
}
