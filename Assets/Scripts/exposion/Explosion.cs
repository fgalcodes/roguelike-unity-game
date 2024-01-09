using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Invoke("AutoDestroy", 1f);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
