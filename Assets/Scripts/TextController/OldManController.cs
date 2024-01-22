using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManController : BaseMenuController
{
    protected override void Start()
    {
        base.Start();
        menuUI = GameObject.Find("OldManControll");
        menuUI.SetActive(false);
    }
}
