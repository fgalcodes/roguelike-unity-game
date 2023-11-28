using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private Healthbar healthBar;

    public BloodEffect bloodEffectPrefab;
    public float bloodDuration = 60f;

    private GameObject playerObject;

    // Referencia al Animator del enemigo
    private Animator animator;

    // Estados de animación
    private bool isWalking = false;
    private bool isAttacking = false;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Healthbar>();
        animator = GetComponent<Animator>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth);
        }
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        // Determinar si el enemigo está caminando o atacando
        if (movement.magnitude > 0)
        {
            isWalking = true;
            isAttacking = false;
        }
        else
        {
            isWalking = false;
            isAttacking = false; // Ajusta esto según tu lógica de ataque
        }

        // Actualiza los booleanos en el Animator
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isAttacking", isAttacking);
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si la colisión es con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiamos el estado a atacando
            isAttacking = true;

            // Actualizamos el booleano en el Animator
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Verificamos si la colisión con el jugador ha terminado
        if (collision.gameObject.CompareTag("Player"))
        {
            // Cambiamos el estado a no atacando
            isAttacking = false;

            // Actualizamos el booleano en el Animator
            animator.SetBool("isAttacking", isAttacking);
        }
    }

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
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
            // Instancia la imagen de sangre en la posición del enemigo
            BloodEffect blood = Instantiate(bloodEffectPrefab, transform.position, Quaternion.identity);
            blood.ShowBloodEffect(transform.position, bloodDuration);
        }

        Destroy(gameObject);
    }
}