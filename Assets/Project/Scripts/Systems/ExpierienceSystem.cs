using System;
using UnityEngine;

public class ExpierienceSystem : Singleton<ExpierienceSystem>
{
    public int Level = 1;
    public int MaxLevel = 20;
    public int CurrentExp = 0;
    public int ExpToNextLv = 100;

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
        ExpChanged?.Invoke();
        if (CurrentExp >= ExpToNextLv)
        {
            CurrentExp -= ExpToNextLv;
            LevelUp();
        }
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
