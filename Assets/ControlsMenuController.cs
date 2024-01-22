using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenuController : BaseMenuController
{
    protected override void Start()
    {
        base.Start();
        menuUI = GameObject.Find("Controls");
        menuUI.SetActive(false);
    }
}
