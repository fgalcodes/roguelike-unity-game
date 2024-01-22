using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MerchantChoise : MonoBehaviour
{
    GameObject merchantUI;

    void Start()
    {
        merchantUI = GameObject.Find("InventoryMerchant");
        merchantUI.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToggleMerchant(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ToggleMerchant();
    }

    private void ToggleMerchant(int a = 0)
    {
        if (a == 1)
        {
            merchantUI.SetActive(true);
        }
        else
        {
            merchantUI.SetActive(false);
        }
    }
}
