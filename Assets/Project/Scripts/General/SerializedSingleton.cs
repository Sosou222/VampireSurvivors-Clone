using Sirenix.OdinInspector;
using UnityEngine;

public abstract class SerializedSingleton<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this as T;
    }

    protected virtual void OnApplicationQuit()
    {
        Instance = null;
        Destroy(gameObject);
    }
}

public abstract class SerializedPersistentSingleton<T> : Singleton<T> where T : SerializedMonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
}
