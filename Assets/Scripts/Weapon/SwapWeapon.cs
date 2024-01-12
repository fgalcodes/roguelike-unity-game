using System;
using UnityEditor.Animations;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public AnimatorController[] weapon;
    private Animator animator;

    private int index = 0;

    public bool isMelee = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !(index > weapon.Length -1))
        {
            Debug.Log("E");
            animator.runtimeAnimatorController = weapon[index];
            index++;
        }

        if (Input.GetKeyDown(KeyCode.Q) && !(index < 0))
        {
            Debug.Log("Q");

            animator.runtimeAnimatorController = weapon[index];
            index--;
        }

        if (index == 0)
        {
            isMelee = true;
        }
        if (index > weapon.Length -1) index--;
        if (index < 0 ) index++;
    }
}