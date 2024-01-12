using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeToExplode(1f));
    }

   IEnumerator TimeToExplode(float duration)
    {
        yield return new WaitForSeconds(duration);

        Destroy(gameObject);
    }
}
