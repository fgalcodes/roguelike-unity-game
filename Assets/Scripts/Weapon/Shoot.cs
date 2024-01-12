using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject bullet;
    [SerializeField] private playerMovementMouse playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<playerMovementMouse>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();

            if (playerMovement != null)
            {
                playerMovement.SetIsShooting(true);
            }
        }
    }

    private void Shooting()
    {
        GameObject bulletPrefab = ObjectPool.instance.GetPoolObject();

        if (bulletPrefab != null)
        {
            bulletPrefab.transform.position = controladorDisparo.position;
            bulletPrefab.transform.rotation = controladorDisparo.rotation;
            bulletPrefab.SetActive(true);
        }
    }
}
