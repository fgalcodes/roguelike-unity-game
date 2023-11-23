using System;
using UnityEditor.Animations;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public AnimatorController[] weapon;
    public Animator animator;

    enum Weapons
    {
        Gun = 0,
        Knife = 1,
        Shotgun = 2,
        Sniper = 3
    }
    private void Awake()
    {
        animator.GetComponent<Animator>();
    }

    public void ChangeController()
    {
    }
}