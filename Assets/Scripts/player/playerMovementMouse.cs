using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementMouse : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    public SwapWeapon swapWeapon;

    Vector2 movement;
    Vector2 mousePos;

    private bool isShooting;
    private bool isMeleeAttacking;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        bool isWalking = movement.x != 0 || movement.y != 0;
        animator.SetBool("isWalking", isWalking);

        if (swapWeapon != null && swapWeapon.animator != null)
        {
            if (swapWeapon.GetIndex() == 0)
            {
                // Activa la animación Melee solo al hacer clic con el ratón
                if (Input.GetMouseButtonDown(0))
                {
                    animator.SetBool("isMelee", true);
                    isMeleeAttacking = true;
                }
            }
            else
            {
                animator.SetBool("isMelee", false);
                isMeleeAttacking = false;
            }
        }

        if (isShooting)
        {
            StartCoroutine(ResetIsShooting());
        }

        if (isMeleeAttacking)
        {
            StartCoroutine(ResetIsMelee());
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 5f;
        rb.rotation = angle;
    }

    IEnumerator ResetIsShooting()
    {
        yield return new WaitForSeconds(0.22f + 0.1f);
        SetIsShooting(false);
    }

    IEnumerator ResetIsMelee()
    {
        // Ajusta el tiempo según la duración de la animación Melee
        yield return new WaitForSeconds(1f + 0.1f);
        animator.SetBool("isMelee", false);
        isMeleeAttacking = false;
    }

    public void SetIsShooting(bool value)
    {
        if (animator != null)
        {
            animator.SetBool("isShooting", value);
            isShooting = value;
        }
    }

    public bool IsMeleeAttacking()
    {
        return isMeleeAttacking;
    }
}
