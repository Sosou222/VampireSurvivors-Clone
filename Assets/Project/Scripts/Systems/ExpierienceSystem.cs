using System;
using UnityEngine;

public class ExpierienceSystem : Singleton<ExpierienceSystem>
{
    public int Level { get; private set; } = 1;
    public int MaxLevel { get; private set; } = 20;
    public int CurrentExp { get; private set; } = 0;
    public int ExpToNextLv { get; private set; } = 100;

    public event Action<int> LeveledUp;
    public event Action ExpChanged;

    public void Setup()
    {
        Level = 1;
        CurrentExp = 0;
    }

    public void AddExp(int exp)
    {
        if(Level >= MaxLevel)
        {
            return;
        }
        CurrentExp += exp;
        if (CurrentExp >= ExpToNextLv)
        {
            CurrentExp -= ExpToNextLv;
            LevelUp();
        }

        ExpChanged?.Invoke();
    }

    public float Normalize()
    {
        return (float)CurrentExp / (float) ExpToNextLv;
    }

    private void LevelUp()
    {
        Level++;
        LeveledUp?.Invoke(Level);
    }
}
