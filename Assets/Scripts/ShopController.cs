using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShopController : BaseMenuController
{
    protected override void Start()
    {
        base.Start();
        menuUI = GameObject.Find("InventoryShop");
        menuUI.SetActive(false);
    }
}
