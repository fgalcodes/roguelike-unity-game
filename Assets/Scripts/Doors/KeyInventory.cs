using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyInventory : MonoBehaviour
{
    public PlayerKeys playerKeys;
    public TMP_Text numberKeyText;


    private void Awake()
    {
        playerKeys.keys = 0;
        UpdateKeyText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key +1");

            playerKeys.keys++;
            UpdateKeyText();

            collision.gameObject.SetActive(false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && playerKeys.keys > 0)
        {
            Debug.Log("Key -1");

            playerKeys.keys--;
            UpdateKeyText();

            collision.gameObject.SetActive(false);

        }
    }
    
    private void UpdateKeyText()
    {
        if (numberKeyText != null)
        {
            numberKeyText.text = playerKeys.keys.ToString();
        }
        else
        {
            Debug.Log("No se ha asignado el texto para mostrar las llaves en el canvas.");
        }
    }
}
