using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryController : BaseMenuController
{
    protected override void Start()
    {
        base.Start();
        menuUI = GameObject.Find("History");
        menuUI.SetActive(false);
    }
}
