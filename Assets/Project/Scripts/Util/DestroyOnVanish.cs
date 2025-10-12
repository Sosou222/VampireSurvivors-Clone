using UnityEngine;

public class DestroyOnVanish : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    private Timer timer;
    private void Start()
    {
        timer = new Timer(1.0f);
        timer.Timeout += DestroySelectedObject;
    }
    private void Update()
    {
        timer.Update(Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        timer.Start();
    }

    private void OnBecameVisible()
    {
        timer.Stop();
    }

    private void DestroySelectedObject()
    {
        Destroy(objectToDestroy);
    }
}
