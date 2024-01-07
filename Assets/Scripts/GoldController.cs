using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldController : MonoBehaviour
{

    public int coins = 0;
    public AudioClip collectedSound;
    GameObject texto;

    void Start()
    {
        texto = GameObject.Find("NumberCoints");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coins++;
            AudioSource.PlayClipAtPoint(collectedSound, transform.position);
            texto.GetComponent<TextMeshProUGUI>().SetText(coins + "");
            Destroy(collision.gameObject);
        }
    }
}
