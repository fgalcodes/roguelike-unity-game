using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        //Instantiate(bullet, controladorDisparo.position, controladorDisparo.rotation);

        GameObject bulletPrefab = ObjectPool.instance.GetPoolObject();

        if (bulletPrefab != null)
        {
            bulletPrefab.transform.position = controladorDisparo.position;
            bulletPrefab.transform.rotation = controladorDisparo.rotation;
            bulletPrefab.SetActive(true);
        }
    }
}
