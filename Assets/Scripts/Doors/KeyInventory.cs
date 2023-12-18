using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public PlayerKeys playerKeys;


    private void Awake()
    {
        playerKeys.keys = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key +1");

            playerKeys.keys++;

            collision.gameObject.SetActive(false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && playerKeys.keys > 0)
        {
            Debug.Log("Key -1");

            playerKeys.keys--;

            collision.gameObject.SetActive(false);

        }
    }
}
