using System;
using UnityEngine;

public class ExpierienceSystem : Singleton<ExpierienceSystem>
{
    private int level = 1;
    private int maxLevel = 20;
    private int currentExp = 0;
    private int expToNextLv = 100;

    public event Action<int> LeveledUp;
    public void Setup()
    {
        level = 1;
        currentExp = 0;
    }

    public void AddExp(int exp)
    {
        if(level >= maxLevel)
        {
            return;
        }
        currentExp += exp;
        if(currentExp >= expToNextLv)
        {
            currentExp -= expToNextLv;
            LevelUp();
        }
    }

    public float Normalize()
    {
        return (float)currentExp / (float) expToNextLv;
    }

    private void LevelUp()
    {
        level++;
        LeveledUp?.Invoke(level);
    }
}
