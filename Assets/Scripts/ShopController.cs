using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    GameObject shopUI;

    void Start()
    {
        shopUI = GameObject.Find("InventoryShop");
        shopUI.SetActive(false);
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToggleShop(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ToggleShop();
    }

    private void ToggleShop(int a = 0)
    {
        if (a == 1)
        {
            //Debug.log("Se abre la tienda");
            shopUI.SetActive(true);
        }
        else
        {
            //Debug.log("Se cierra la tienda");
            shopUI.SetActive(false);
        }
    }
}
