using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementMouse : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float meleeAttackRange = 2f;
    public LayerMask enemyLayer;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    public SwapWeapon swapWeapon;

    Vector2 movement;
    Vector2 mousePos;

    private bool isShooting;
    private bool isMeleeAttacking;

    public float daño = 10f;

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
                if (Input.GetMouseButtonDown(0) && !isMeleeAttacking)
                {
                    animator.SetBool("isMelee", true);
                    isMeleeAttacking = true;
                    StartCoroutine(ResetIsMelee());
                    HandleMeleeAttack();
                    SetIsShooting(false);
                }
            }
            else
            {
                animator.SetBool("isMelee", false);
                isMeleeAttacking = false;
            }
        }

        if (isShooting && !IsMeleeAttacking())
        {
            StartCoroutine(ResetIsShooting());
        }
    }

    bool IsNearEnemy()
    {
        Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, meleeAttackRange, enemyLayer);

        return hitEnemy != null && hitEnemy.CompareTag("Enemigo");
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
        yield return new WaitForSeconds(0.45f + 0.1f);
        animator.SetBool("isMelee", false);
        isMeleeAttacking = false;
    }

    void HandleMeleeAttack()
    {
        if (IsNearEnemy())
        {
            Collider2D hitEnemy = Physics2D.OverlapCircle(transform.position, meleeAttackRange, enemyLayer);

            if (hitEnemy != null && hitEnemy.CompareTag("Enemigo"))
            {
                EnemiMovement enemyScript = hitEnemy.GetComponent<EnemiMovement>();

                if (enemyScript != null)
                {
                    enemyScript.TomarDaño(daño);
                }
            }
        }

        StartCoroutine(DisableShootForMelee());
    }

    IEnumerator DisableShootForMelee()
    {
        // Desactivar el componente Shoot solo durante la animación Melee
        Shoot shootComponent = GetComponent<Shoot>();
        if (shootComponent != null)
        {
            shootComponent.enabled = false;

            // Agregar un pequeño retraso antes de reactivar el componente Shoot
            yield return new WaitForSeconds(0.01f);

            // Reactivar el componente Shoot
            shootComponent.enabled = true;
        }
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
