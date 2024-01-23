using System;
using System.Diagnostics;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public RuntimeAnimatorController[] weapon;
    public Animator animator;
    private int index = 0;

    public int GetIndex()
    {
        return index;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        UpdateAnimatorController();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index < weapon.Length - 1)
        {
            UnityEngine.Debug.Log("E");
            index++;
            UpdateAnimatorController();
        }

        if (Input.GetKeyDown(KeyCode.Q) && index > 0)
        {
            UnityEngine.Debug.Log("Q");
            index--;
            UpdateAnimatorController();
        }
    }

    private void UpdateAnimatorController()
    {
        if (animator != null && index >= 0 && index < weapon.Length)
        {
            animator.runtimeAnimatorController = weapon[index];
        }
    }
}
