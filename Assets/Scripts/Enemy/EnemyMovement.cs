using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMovement : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [SerializeField] private Healthbar healthBar;

    public BloodEffect bloodEffectPrefab;
    public float bloodDuration = 60f;

    private GameObject playerObject;

    private Animator animator;

    private bool isAttacking = false;

    public enum States
    {
        Run,
        Attack,
        Die
    }
    public States currentState;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.GetComponentInChildren<Healthbar>();
        animator = GetComponent<Animator>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth);
        }
    }

    private void Update()
    {
        healthBar.transform.rotation = Quaternion.Euler(Vector3.zero);
        
        switch (currentState)
        {
            case States.Attack:
                if (!isAttacking)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isAttacking", true);
                    isAttacking = true;
                }
                break;
            case States.Run:
                if (movement.magnitude > 0 && !isAttacking)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isAttacking", false);
                }
                break;
            case States.Die:
                animator.SetBool("isDead", true);
                break;
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }
    private void FixedUpdate()
    {
        if (currentState == States.Run)
        {
            moveCharacter(movement);
        }
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentState = States.Attack;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAttacking = false;
            currentState = States.Run;
        }
    }

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
            currentState = States.Die;
            DestroyEnemy();
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + daño);
        }
    }
    void DestroyEnemy()
    {

        if (bloodEffectPrefab != null)
        {
            BloodEffect blood = Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
            blood.ShowBloodEffect(transform.position, bloodDuration);
        }

        Destroy(gameObject);
    }
}