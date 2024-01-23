using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision involves a specific tag
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You win!");
        }
    }
}