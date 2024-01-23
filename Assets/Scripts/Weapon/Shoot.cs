using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private playerMovementMouse playerMovement;

    [SerializeField] private AudioSource pistolSound;
    [SerializeField] private AudioSource rifleSound;
    [SerializeField] private AudioSource shotgunSound;
    [SerializeField] private AudioSource meleeSound;

    private bool primerDisparo = false;

    private void Start()
    {
        playerMovement = GetComponent<playerMovementMouse>();
        DesactivarPlayOnAwake();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playerMovement.IsMeleeAttacking())
        {
            if (!primerDisparo)
            {
                ActivarSonidos();
                primerDisparo = true;
            }
            Shooting();
            playerMovement?.SetIsShooting(true);
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

            PlayWeaponSound();
        }
    }

    private void PlayWeaponSound()
    {
        if (primerDisparo && playerMovement != null)
        {
            int weaponIndex = playerMovement.GetWeaponIndex();
            AudioSource currentWeaponSound = null;

            switch (weaponIndex)
            {
                case 1: currentWeaponSound = pistolSound; break;
                case 2: currentWeaponSound = rifleSound; break;
                case 3: currentWeaponSound = shotgunSound; break;
            }

            currentWeaponSound?.Play();
        }
    }

    private void PlayMeleeSound()
    {
        meleeSound?.PlayOneShot(meleeSound.clip);
    }

    private void ActivarSonidos()
    {
        ActivarPlayOnAwake();
    }

    private void ActivarPlayOnAwake()
    {
        pistolSound?.Play();
        rifleSound?.Play();
        shotgunSound?.Play();
        meleeSound?.Play();
    }

    private void DesactivarPlayOnAwake()
    {
        if (pistolSound != null)
        {
            pistolSound.playOnAwake = false;
        }

        if (rifleSound != null)
        {
            rifleSound.playOnAwake = false;
        }

        if (shotgunSound != null)
        {
            shotgunSound.playOnAwake = false;
        }

        if (meleeSound != null)
        {
            meleeSound.playOnAwake = false;
        }
    }
}
